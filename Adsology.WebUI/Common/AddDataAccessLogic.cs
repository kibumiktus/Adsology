using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adsology.Dal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adsology.WebUI.Common
{
    public static class DataAccessLogicExtension
    {
        public static IServiceCollection AddDataAccessLogic(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AdsologyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AdsologyDatabase")));

            services.AddScoped<IAdsologyDbContext>(provider => provider.GetService<AdsologyDbContext>());

            return services;
        }
    }
}
