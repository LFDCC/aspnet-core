using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.JwtSetttings
{
    /// <summary>
    /// jwt配置
    /// </summary>
    public class JwtSetting
    {
        public string Secret { get; set; }     //Configuration.GetSection("JwtSetting").Get<JwtSetting>() {get;set;}必须要

        public string Issuer { get; set; }

        public string AccessAudience { get; set; }

        public int AccessExpiration { get; set; }

        public string RefreshAudience { get; set; }

        public int RefreshExpiration { get; set; }
    }

    public class Token
    {
        public AccessToken Access_Token { get; set; }
        public RefreshToken Refresh_Token { get; set; }
    }
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
