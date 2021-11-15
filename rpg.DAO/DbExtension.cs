using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.DAO
{
    public static class DbExtension
    {
        public static IServiceCollection AddDbExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RpgContext>(item =>
            {
                item.UseSqlServer(configuration.GetConnectionString("mssql"));
            });

            return services;
        }
    }
}
