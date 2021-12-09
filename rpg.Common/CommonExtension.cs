using Microsoft.Extensions.DependencyInjection;
using rpg.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.Common
{
    public static class CommonExtension
    {
        public static IServiceCollection AddCommonExtension(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
