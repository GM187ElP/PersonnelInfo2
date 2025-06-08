using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Infrastructure.Configuration;
using System.Linq.Expressions;

namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository : IEmployeeRepository
{
    private readonly DbSet<Employee> _dbSet;
    private readonly DatabaseContext _context;

    public EmployeeRepository(DatabaseContext context)
    {
        _context = context;
        _dbSet = _context.Set<Employee>();
    }

    public class CountResult
    {
        public long TotalCount { get; set; }
    }


    private static  Expression<Func<Employee, bool>> IncludeFilter(GetTypeEnum getType) =>
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
}

public enum GetTypeEnum
{
    All, Deleted, NotDeleted
}