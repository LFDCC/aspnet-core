using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MyProject.HttpResult;
using MyProject.Users.Dtos;

using Volo.Abp;
using Volo.Abp.Security.Claims;
using Volo.Abp.Security.Encryption;
using Volo.Abp.Users;

namespace MyProject.Users
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserAppService : MyProjectAppService, IUserAppService
    {
        private readonly IUserRepository _repository;
        private readonly IStringEncryptionService _stringEncryptionService;
        public UserAppService(IUserRepository repository, IStringEncryptionService stringEncryptionService)
        {
            _repository = repository;
            _stringEncryptionService = stringEncryptionService;
        }

        [AllowAnonymous]
        [RemoteService(false)]
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var password = _stringEncryptionService.Encrypt(loginDto.PassWord);
            var user = await _repository.FindAsync(t => t.UserName == loginDto.UserName && t.PassWord == password);

            return ObjectMapper.Map<User, UserDto>(user);
        }
        [HttpGet]
        [Route("info")]
        public async Task<Result<UserInfoDto>> GetInfo()
        {
            var user = await _repository.FindAsync(t => t.Id == CurrentUser.Id);
            var userinfo = new UserInfoDto
            {
                Name = user.RealName,
                Roles = CurrentUser.Roles,
                Avatar = "",
                Introduction = ""
            };
            var result = new Result<UserInfoDto>
            {
                Code = ResultCode.Success,
                Data = userinfo
            };
            return result;
        }

    }
}
