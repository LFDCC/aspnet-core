using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Volo.Abp.DependencyInjection;

namespace MyProject.JwtSetttings
{
    public class TokenService : ITokenService, ITransientDependency
    {
        readonly JwtSetting jwtSetting;
        public TokenService(IOptions<JwtSetting> options)
        {
            jwtSetting = options.Value;
        }

        /// <summary>
        /// 创建access_toekn refresh_token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Token GetToken(Guid userId, string userName, string userRole)
        {
            var token = new Token
            {
                Access_Token = GetAccessToken(userId, userName, userRole),
                Refresh_Token = GetRefreshToken(userName)
            };
            return token;
        }
        /// <summary>
        /// 校验RefreshToken
        /// </summary>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        public string ValidateRefreshToken(string refresh_token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var valid = handler.ValidateToken(refresh_token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.Secret)),
                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience = jwtSetting.RefreshAudience,
                }, out SecurityToken securityToken);

                return valid.Identity.Name;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 创建access_token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private AccessToken GetAccessToken(Guid userId, string userName, string userRole)
        {
            var access_token = new AccessToken();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Role,userRole)
            };
            var expires = DateTime.Now.AddMinutes(jwtSetting.AccessExpiration);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(jwtSetting.Issuer, jwtSetting.AccessAudience, claims, expires: expires, signingCredentials: credentials);

            access_token.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            access_token.Expires = expires;
            return access_token;
        }
        /// <summary>
        /// 创建refresh_token
        /// refresh_token 仅用来刷新 access_token claims尽量少放内容，给个用户标识即可
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private RefreshToken GetRefreshToken(string userName)
        {
            var refresh_token = new RefreshToken();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,userName)
            };

            var expires = DateTime.Now.AddMinutes(jwtSetting.RefreshExpiration);
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(jwtSetting.Issuer, jwtSetting.RefreshAudience, claims, expires: expires, signingCredentials: credentials);

            refresh_token.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            refresh_token.Expires = expires;
            return refresh_token;
        }
    }
}
