using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Infrastructure.MongoDbDataAccess;
using CleanArchitecture.Infrastructure.MongoDbDataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CleanArchitecture.Infrastructure.IoC
{
    public static class MongoDbExtentions
    {
        public static IServiceCollection AddMongoDbRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddSingleton<IMongoClient>(s => new MongoClient(configuration.GetConnectionString("MongoDb")));

            services.AddScoped(s => new Context(s.GetRequiredService<IMongoClient>(), configuration["DbName"]));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
