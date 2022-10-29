using Application.Features.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
