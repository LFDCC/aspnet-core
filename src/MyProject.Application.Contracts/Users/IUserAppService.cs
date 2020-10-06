using System.Threading.Tasks;

using MyProject.Users.Dtos;

using Volo.Abp.Application.Services;

namespace MyProject.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<UserDto> Login(LoginDto loginDto);

    }
}