using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelInfo.Infrastructure.Data.Repositories;

public enum QueryProvider
{
    LinqMethod,         // Method-chaining LINQ
    LinqQuery,          // Query-expression LINQ
    Dapper,             // Lightweight ORM
    EfCoreFromSql       // Raw SQL via EF Core
    //AdoNet,             // Classic low-level database access
}