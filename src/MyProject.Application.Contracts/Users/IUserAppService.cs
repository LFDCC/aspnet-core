using System.Threading.Tasks;

using MyProject.HttpResult;
using MyProject.Users.Dtos;

using Volo.Abp.Application.Services;

namespace MyProject.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<Result<UserInfoDto>> GetInfo();

    }
}