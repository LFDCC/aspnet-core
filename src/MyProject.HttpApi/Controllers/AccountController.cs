using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyProject.JwtSetttings;
using MyProject.Users;
using MyProject.Users.Dtos;

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : MyProjectController
    {
        readonly IUserAppService _userAppService;
        readonly ITokenService _tokenService;
        public AccountController(IUserAppService userAppService, ITokenService tokenService)
        {
            _userAppService = userAppService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<Token> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userAppService.Login(loginDto);
            var token = _tokenService.GetToken(user.Id, user.UserName, user.RoleName);
            return token;
        }
    }
}
