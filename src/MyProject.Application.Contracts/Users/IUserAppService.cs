using System;
using System.Threading.Tasks;
using MyProject.Users.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.Users
{
    public interface IUserAppService :
        ICrudAppService< 
            UserDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUserDto,
            UpdateUserDto>
    {
        Task<UserDto> Login(LoginDto loginDto);

    }
}