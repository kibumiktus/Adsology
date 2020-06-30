using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adsology.BusinessLogic
{
    public static class BusinessLogicDependencyExtension
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<OrdersService>();
            return services;
        }
    }
}