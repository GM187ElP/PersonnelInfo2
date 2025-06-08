using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using System.Data;
using static Dapper.SqlMapper;

namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository
{
    public async Task<PagedResult<Employee>> GetAllAsync(
     int page,
     int pageSize,
     GetTypeEnum getType,
     QueryProvider queryProvider,
     CancellationToken cancellationToken = default)
    {
        var parameters = new
        {
            Offset = (page - 1) * pageSize,
            PageSize = pageSize
        };

        var countRawSql = $"""
        SELECT COUNT(*) FROM [Employee] AS E 
        {IncludeFilterForSql(getType, "E.IsDeleted")}
        """;

        var itemsRawSqlEfCore = $"""
        SELECT * FROM [Employee] AS E 
        {IncludeFilterForSql(getType, "E.IsDeleted")}
        ORDER BY E.Id
        OFFSET {parameters.Offset} ROWS 
        FETCH NEXT {parameters.PageSize} ROWS ONLY
        """;

        var itemsRawSqlDapper = $"""
        SELECT * FROM [Employee] AS E 
        {IncludeFilterForSql(getType, "E.IsDeleted")}
        ORDER BY E.Id
        OFFSET @Offset ROWS 
        FETCH NEXT @PageSize ROWS ONLY
        """;

        var result = new PagedResult<Employee>();

        switch (queryProvider)
        {
            case QueryProvider.LinqMethod:
                result.TotalCount = await _dbSet.CountAsync(cancellationToken);
                result.Items = await _dbSet
                    .AsNoTracking()
                    .Where(IncludeFilter(getType))
                    .Skip(parameters.Offset)
                    .Take(parameters.PageSize)
                    .ToListAsync(cancellationToken);
                break;

            case QueryProvider.LinqQuery:
                var queryable = from e in _dbSet.AsNoTracking().Where(IncludeFilter(getType))
                                orderby e.Id
                                select e;

                result.TotalCount = await queryable.CountAsync(cancellationToken);
                result.Items = await queryable
                    .Skip(parameters.Offset)
                    .Take(parameters.PageSize)
                    .ToListAsync(cancellationToken);
                break;

            case QueryProvider.EfCoreFromSql:
                var countResult = await _context.Set<CountResult>()
                    .FromSqlRaw(countRawSql)
                    .AsNoTracking()
                    .FirstAsync(cancellationToken);

                result.TotalCount = countResult.TotalCount;
                result.Items = await _dbSet
                    .FromSqlRaw(itemsRawSqlEfCore)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                break;

            default:
                var connectionString = _context.Database.GetConnectionString();
                await using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync(cancellationToken);

                    result.TotalCount = await connection.ExecuteScalarAsync<long>(
                        new CommandDefinition(countRawSql, parameters, cancellationToken: cancellationToken));

                    var items = await connection.QueryAsync<Employee>(
                        new CommandDefinition(itemsRawSqlDapper, parameters, cancellationToken: cancellationToken));

                    result.Items = items.ToList();
                }
                break;
        }

        return result;
    }
}