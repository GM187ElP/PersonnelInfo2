using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Core.Entities;

namespace PersonnelInfo.Infrastructure.Data.Repositories.EmployeeRepositories;
public partial class EmployeeRepository
{
    public async Task<Employee?> GetByIdAsync(long id, QueryProvider queryProvider, CancellationToken cancellationToken = default)
    {
        var queryRawSql = $"""
            SELECT E.*, CPN.*, SLH.*, BA.* FROM [Employee] AS E
            LEFT JOIN [ChequePromissionaryNotes] AS CPN ON CPN.EmployeeId=E.Id
            LEFT JOIN [StartLeftHistories] AS SLH ON SLH.EmployeeId=E.Id
            LEFT JOIN [BankAccounts] AS BA ON BA.EmployeeId=E.Id
            WHERE E.Id={id}
            """;

        var queryDapper = $"""
            SELECT E.*, CPN.*, SLH.*, BA.* FROM [Employee] AS E
            LEFT JOIN [ChequePromissionaryNotes] AS CPN ON CPN.EmployeeId=E.Id
            LEFT JOIN [StartLeftHistories] AS SLH ON SLH.EmployeeId=E.Id
            LEFT JOIN [BankAccounts] AS BA ON BA.EmployeeId=E.Id
            WHERE E.Id= $id
            """;

        var result = new PagedResult<Employee>();
        Employee? employee = new();

        switch (queryProvider)
        {
            case QueryProvider.LinqMethod:
                await _dbSet
               .AsNoTracking()
               .Include(e => e.ChequePromissionaryNotes)
               .Include(e => e.StartLeftHistories)
               .Include(e => e.BankAccounts)
               .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

                break;

            case QueryProvider.LinqQuery:
                var a =
                    from e in _dbSet
                    where e.Id == id
                    join cpn in _context.Set<ChequePromissionaryNote>()
                    on e.Id equals cpn.EmployeeId
                    into cpnGroup
                    from cpn in cpnGroup.DefaultIfEmpty()

                    join slh in _context.Set<StartLeaveHistory>()
                    on e.Id equals slh.EmployeeId
                    into slhGroup
                    from slh in slhGroup.DefaultIfEmpty()

                    join ba in _context.Set<BankAccount>()
                    on e.Id equals ba.EmployeeId
                    into baGroup
                    from ba in baGroup.DefaultIfEmpty()

                    select new
                    {
                        employee = e,
                        chequePromissionaryNotes = cpnGroup,
                        bankAccounts = baGroup,
                        startLeaveHistories = slhGroup
                    };

                var result1 = await a.AsNoTracking()
                    .FirstOrDefaultAsync();

                Employee employee1 = result1.employee ?? new();
                employee1.ChequePromissionaryNotes = result1.chequePromissionaryNotes.ToList();
                employee1.BankAccounts = result1.bankAccounts.ToList();
                employee1.StartLeftHistories = result1.startLeaveHistories.ToList();



                break;

            case QueryProvider.EfCoreFromSql:
                employee = await _dbSet.FromSqlRaw(queryRawSql)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                break;

            default:
                var connectionString = _context.Database.GetConnectionString();
                var employeeDictionary = new Dictionary<long, Employee>();
                await using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync(cancellationToken);

                    var employees = await connection.QueryAsync<Employee, ChequePromissionaryNote, BankAccount, StartLeaveHistory, Employee>(
                        queryDapper, (employee, cheque, bankAccount, startLeave) =>
                        {
                            if (!employeeDictionary.TryGetValue(employee.Id, out var empEntry))
                            {
                                empEntry = employee;
                                empEntry.ChequePromissionaryNotes = new List<ChequePromissionaryNote>();
                                empEntry.BankAccounts = new List<BankAccount>();
                                empEntry.StartLeftHistories = new List<StartLeaveHistory>();
                            }

                            if (cheque is not null && empEntry.ChequePromissionaryNotes.Any(c => c.Id == cheque.Id))
                                empEntry.ChequePromissionaryNotes.Add(cheque);

                            if (bankAccount is not null && empEntry.BankAccounts.Any(c => c.Id == cheque.Id))
                                empEntry.BankAccounts.Add(bankAccount);

                            if (startLeave is not null && empEntry.StartLeftHistories.Any(c => c.Id == cheque.Id))
                                empEntry.StartLeftHistories.Add(startLeave);

                            return empEntry;
                        }, param: new { id }, splitOn: "Id,Id,Id"
                        );
                    employee = employees.FirstOrDefault();
                }
                break;
        }

        return employee;
    }
}