using HotleConvenience.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotleConvenience.Api.Extensions.IServiceCollectionExtensions
{
    public static class AuthorizeExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            return services.AddAuthorizeConfigMapping()
                           .AddCustomTokenProviderIoc()
                           .AddJwtAuth();
        }

        private static IServiceCollection AddJwtAuth(this IServiceCollection services)
        {
            var config = GetAuthorizeConfig(services);

            var tokenValidationParameters = new TokenValidationParameters()
            {
                NameClaimType = ClaimTypes.Name,
                RoleClaimType = ClaimTypes.Role,
                ValidIssuer = config.Issuer,
                ValidAudience = config.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.Secret))
                /***********************************TokenValidationParameters的参数默认值***********************************/
                // RequireSignedTokens = true,
                // SaveSigninToken = false,
                // ValidateActor = false,
                // 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                // ValidateAudience = true,
                // ValidateIssuer = true, 
                // ValidateIssuerSigningKey = false,
                // 是否要求Token的Claims中必须包含Expires
                // RequireExpirationTime = true,
                // 允许的服务器时间偏移量
                // ClockSkew = TimeSpan.FromSeconds(300),
                // 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                // ValidateLifetime = true
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParameters;
            });
            return services;
        }

        private static IServiceCollection AddAuthorizeConfigMapping(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();

            services.Configure<AuthorizeConfig>(config.GetSection("AuthorizeConfig"));
            return services;
        }

        private static IServiceCollection AddCustomTokenProviderIoc(this IServiceCollection services)
        {
            services.AddTransient<CustomTokenProvider>();
            return services;
        }

        #region 帮助
        private static AuthorizeConfig GetAuthorizeConfig(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            return provider.GetRequiredService<IOptions<AuthorizeConfig>>().Value;
        }

        #endregion

    }
}
