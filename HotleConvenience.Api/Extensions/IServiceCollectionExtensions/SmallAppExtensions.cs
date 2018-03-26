using HotleConvenience.Lib.WeSmallApp;
using HotleConvenience.Model.SmallAppModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotleConvenience.Api.Extensions.IServiceCollectionExtensions
{
    public static class SmallAppExtensions
    {
        public static IServiceCollection AddSmallApp(this IServiceCollection services)
        {
            return services.AddSmallAppSettingMapping()
                           .AddSmallAppClient();
        }

        private static IServiceCollection AddSmallAppSettingMapping(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            services.Configure<SmallApp_Setting>(config.GetSection("SmallApp_Setting"));
            return services;
        }

        private static IServiceCollection AddSmallAppClient(this IServiceCollection services)
        {
            return services.AddTransient<SmallAppClient>();
        }
    }
}
