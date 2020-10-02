using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.JwtSetttings
{
    public interface ITokenService
    {
        Token GetToken(Guid userId, string userName, string userRole);
        string ValidateRefreshToken(string refresh_token);
    }
}
