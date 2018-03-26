using HotleConvenience.Lib.Cache;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotleConvenience.Api.Extensions.IServiceCollectionExtensions
{
    public static class IOCExtensions
    {
        public static IServiceCollection AddRegisterIoc(this IServiceCollection services) {
            return services.AddSingleton<ICache, CustomMemoryCache>();
        }
    }
}
