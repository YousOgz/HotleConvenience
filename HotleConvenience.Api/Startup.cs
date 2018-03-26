using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotleConvenience.Api.Extensions.IServiceCollectionExtensions;
using HotleConvenience.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HotleConvenience.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //基础Ioc注册
            services.AddRegisterIoc();

            //权限认证
            services.AddCustomAuthentication();

            //小程序
            services.AddSmallApp();

            services.AddMvc(options => {
                options.Filters.Add<CustomResultFilter>();
                options.Filters.Add<ExceptionResultFilter>();
                options.Filters.Add<AuthorizationResultFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
