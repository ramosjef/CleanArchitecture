using CleanArchitecture.Application.UseCases;
using CleanArchitecture.Domain.Customers;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.IoC
{
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            //services.AddScoped<IGetCustomersUseCase, GetCustomers>();

            return services;
        }
    }
}
