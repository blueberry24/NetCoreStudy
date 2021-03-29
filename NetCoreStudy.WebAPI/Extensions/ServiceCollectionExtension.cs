using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCoreStudy.Domain;
using NetCoreStudy.Infrastructure;
using System;

namespace NetCoreStudy.WebAPIProject.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            return services.AddDbContext<StudyDbContext>(optionsAction);
        }

        public static IServiceCollection AddMySqlDoaminContext(this IServiceCollection services, string connectionString)
        {
            return services.AddDataContext(builder =>
            {
                builder.UseMySql(connectionString);
            });
        }

        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StudyDbContextTransactionBehavior<,>));
            return services.AddMediatR(typeof(Subject).Assembly, typeof(Program).Assembly);
        }
    }
}
