using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.JwtSetttings
{
    public interface ITokenService
    {
        Token GetToken(Guid userId, string userName, string[] userRoles);
        string ValidateRefreshToken(string refresh_token);
    }
}
