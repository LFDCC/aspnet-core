using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyProject.HttpResult;
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

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<Result<Token>> Login([FromBody] LoginDto loginDto)
        {
            var result = new Result<Token>();
            var user = await _userAppService.Login(loginDto);
            if (user != null)
            {
                var token = _tokenService.GetToken(user.Id, user.UserName, user.UserRoles.Select(t => t.Role.RoleName).ToArray());
                result.Code = ResultCode.Success;
                result.Data = token;
                return result;
            }
            else
            {
                result.Code = ResultCode.Fail;
                result.Message = "用户名或密码错误";
            }
            return result;
        }
    }
}
