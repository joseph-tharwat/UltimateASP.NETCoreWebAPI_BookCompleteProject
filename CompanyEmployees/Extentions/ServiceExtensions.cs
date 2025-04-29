using Contracts.IRepositoy;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;
using Service.Contract;
using Service;
using Contracts.Logger;
using LoggerService;

namespace CompanyEmployees.Extentions
{
    public static  class ServiceExtensions
    {
        public static void configureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, MyLogger>();
        }

        public static void configureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void configureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<RepositoryContext>(configuration.GetConnectionString("Default"));
            //services.AddDbContext<RepositoryContext>(options =>
            //{ options.UseSqlServer(configuration.GetConnectionString("Default")); });
        }

        public static void confiureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }


    }
}
