using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PersonnelInfo.Application;
using PersonnelInfo.Application.Interfaces;
using PersonnelInfo.Application.Interfaces.Entities;
using PersonnelInfo.Application.Services;
using PersonnelInfo.Core.Entities;
using PersonnelInfo.Core.Interfaces;
using PersonnelInfo.Infrastructure.Data.Repositories;
using PersonnelInfo.Infrastructure.Services;

namespace PersonnelInfo.Infrastructure.Configuration;
public class ProjectModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<RSAESEncryption>().AsSelf().SingleInstance(); 
        builder.RegisterType<DatabaseContext>().As<DbContext>().AsSelf().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
        builder.RegisterType<StartLeaveHistoryRepository>().As<IStartLeaveHistoryRepository>().InstancePerLifetimeScope();
        builder.RegisterType<BankNameRepository>().As<IBankNameRepository>().InstancePerLifetimeScope();
        //builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerLifetimeScope();
        builder.RegisterType<JobTitleRepository>().As<IJobTitleRepository>().InstancePerLifetimeScope();

        builder.RegisterType<EmployeeServices>().As<IEmployeeServices>().InstancePerLifetimeScope();
        builder.RegisterType<GlobalExceptionMiddleware>().AsSelf().InstancePerLifetimeScope();
    }
}
