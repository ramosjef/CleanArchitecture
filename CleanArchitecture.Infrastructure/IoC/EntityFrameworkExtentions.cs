using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Infrastructure.EntityFrameworkDataAccess;
using CleanArchitecture.Infrastructure.EntityFrameworkDataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.IoC
{
    public static class EntityFrameworkExtentions
    {
        public static IServiceCollection AddEntityFrameworkRepositories(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
