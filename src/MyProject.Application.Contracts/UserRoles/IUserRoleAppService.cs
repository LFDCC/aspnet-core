using System;
using MyProject.UserRoles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyProject.UserRoles
{
    public interface IUserRoleAppService :
        ICrudAppService< 
            UserRoleDto, 
            UserRoleKey, 
            PagedAndSortedResultRequestDto,
            CreateUserRoleDto,
            UpdateUserRoleDto>
    {

    }
}