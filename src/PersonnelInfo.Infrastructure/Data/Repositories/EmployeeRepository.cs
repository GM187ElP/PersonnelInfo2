using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Infrastructure;
using PersonnelInfo.Infrastructure.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;

namespace PersonnelInfo.Infrastructure.Data.Repositories;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly DbSet<Employee> _dbSet;
    private readonly DatabaseContext _context;

    public EmployeeRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<Employee>();
    }

    public async Task AddAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        entity.BirthPlaceId = 32;
        entity.DepartmentId = "فروش";
        entity.ShenasnameIssuedPlaceId = 32;

        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            entity.PersonnelCode = await MaxPersonnelCodeAsync(cancellationToken) + 1;
            entity.IsDeleted = true;
            return true;
        }

        return false;
    }

    public async Task<PagedResult<Employee>> GetAllAsync(int page, int pageSize, GetTypeEnum getType, QueryProvider queryProvider, CancellationToken cancellationToken = default)
    {
        PagedResult<Employee> result;
        CountResult countResult;

        var parameters = new
        {
            Offset = (page - 1) * pageSize,
            PageSize = pageSize
        };

        var countRawSql = $"""
                SELECT COUNT(*) FROM [Employee] AS E 
                {IncludeFilterForSql(getType, "E.IsDeleted")}
                """;

        var ItemsRawSql = $"""
                SELECT * FROM [Employee] AS E 
                {IncludeFilterForSql(getType, "E.IsDeleted")}
                ORDER BY E.Id
                OFFSET {parameters.Offset} ROWS 
                FETCH NEXT {parameters.PageSize} ROWS ONLY
                """;

        if (queryProvider == QueryProvider.LinqMethod)
        {
            result = new()
            {
                TotalCount = await _dbSet.CountAsync(cancellationToken),
                Items = await _dbSet
                .AsNoTracking()
                .Where(IncludeFilter(getType))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken)
            };
            return result;
        }
        else if (queryProvider == QueryProvider.LinqQuery)
        {
            var queryable = from e in _dbSet.AsNoTracking().Where(IncludeFilter(getType))
                            orderby e.Id
                            select e;

            result = new()
            {
                TotalCount = await queryable.CountAsync(cancellationToken),
                Items = await queryable
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync(cancellationToken)
            };
            return result;
        }
        else if (queryProvider == QueryProvider.EfCoreFromSql)
        {
            countResult = new();
            countResult = await _context.Set<CountResult>()
               .FromSqlRaw(countRawSql)
               .AsNoTracking()
               .FirstAsync(cancellationToken);

            result = new();
            result.TotalCount = countResult.TotalCount;
            result.Items = await _dbSet.FromSqlRaw(ItemsRawSql)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return result;
        }

        else if (queryProvider == QueryProvider.Dapper)
        {
            var connectionString = _context.Database.GetConnectionString();
            using var connection = new SqlConnection(connectionString);

            result = new();

            result.TotalCount = await connection.ExecuteScalarAsync<long>(new CommandDefinition(countRawSql, cancellationToken: cancellationToken));
            var items = await connection.QueryAsync<Employee>(new CommandDefinition(ItemsRawSql, cancellationToken: cancellationToken));
            result.Items = items.ToList();

            return result;
        }
        else
        {

        }

    }
    public class CountResult
    {
        public long TotalCount { get; set; }
    }


    private static Expression<Func<Employee, bool>> IncludeFilter(GetTypeEnum getType) =>
    getType switch
    {
        GetTypeEnum.All => e => true,
        GetTypeEnum.Deleted => e => !e.IsDeleted,
        _ => e => e.IsDeleted
    };



    private string IncludeFilterForSql(GetTypeEnum getType, string property) => getType switch
    {
        GetTypeEnum.All => "",
        GetTypeEnum.Deleted => $"WHERE {property} = 1",
        _ => $"WHERE {property} = 0"
    };

    public async Task<bool> NationalIdExistAsync(string nationalId, CancellationToken cancellationToken = default) =>
         await _dbSet.AnyAsync(e => e.NationalId == nationalId);

    public async Task<Employee?> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await _dbSet
            .AsNoTracking()
            .Include(e => e.ChequePromissionaryNotes)
            .Include(e => e.StartLeftHistories)
            .Include(e => e.BankAccounts)
            .FirstOrDefaultAsync(e => (e.IsDeleted == false && e.Id == id), cancellationToken);

    public async Task<Employee?> GetByPersonnelCodeAsync(int personnelCode, CancellationToken cancellationToken = default) =>
        await _dbSet
            .AsNoTracking()
            .Include(e => e.ChequePromissionaryNotes)
            .Include(e => e.StartLeftHistories)
            .Include(e => e.BankAccounts)
            .FirstOrDefaultAsync(e => (e.IsDeleted == false && e.PersonnelCode == personnelCode), cancellationToken);

    public async Task<int> MaxPersonnelCodeAsync(CancellationToken cancellationToken = default)
    {
        var employees = await _dbSet
            .Where(e => e.PersonnelCode < 20000)
            .Select(e => e.PersonnelCode)
            .ToListAsync(cancellationToken);

        return employees
             .DefaultIfEmpty(0)
             .Max();
    }


    public async Task UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        var existingEntity = await _dbSet.FindAsync(new object[] { entity.Id }, cancellationToken);
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
    }
}

public enum GetTypeEnum
{
    All, Deleted, NotDeleted
}