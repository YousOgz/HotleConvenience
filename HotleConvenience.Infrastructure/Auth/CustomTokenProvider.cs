using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotleConvenience.Infrastructure.Auth
{
    public class CustomTokenProvider
    {
        private AuthorizeConfig _authorizeConfig { get; }
        public CustomTokenProvider(IOptions<AuthorizeConfig> option)
        {
            _authorizeConfig = option.Value;
        }

        public CustomToken GetToken(int expiresSeconds = 7200)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var expires = DateTime.UtcNow.AddSeconds(expiresSeconds);
            var tokenDescriptor = GetSecurityTokenDescriptor(expires);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenSH256String = tokenHandler.WriteToken(token);
            return new CustomToken(tokenSH256String, new DateTimeOffset(expires).ToUnixTimeSeconds());
        }

        private SecurityTokenDescriptor GetSecurityTokenDescriptor(DateTime expires)
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = GetClaimsIdentity(),
                Audience = _authorizeConfig.Audience,
                Issuer = _authorizeConfig.Issuer,
                Expires = expires,
                SigningCredentials = GetSigningCredentials(SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }

        /// <summary>
        /// 获取SigningCredentials
        /// </summary>
        /// <param name="securityAlgorithms">加密方式</param>
        /// <returns></returns>
        private SigningCredentials GetSigningCredentials(string securityAlgorithms)
        {
            var secretByte = Encoding.ASCII.GetBytes(_authorizeConfig.Secret);
            var symmetricSecurityKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, securityAlgorithms);
            return signingCredentials;
        }

        private ClaimsIdentity GetClaimsIdentity()
        {
            var cliams = new Claim[2];
            var claimsIdentity = new ClaimsIdentity(cliams);
            return claimsIdentity;
        }
    }
    public class CustomToken
    {

        public CustomToken(string access_token, long expires)
        {
            this.access_token = access_token;
            this.expires = expires;
        }

        public string access_token { get; }

        public long expires { get; }
    }
}
