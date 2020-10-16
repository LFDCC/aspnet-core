using AutoMapper;

using MyProject.Roles;
using MyProject.Roles.Dtos;
using MyProject.Users;
using MyProject.UserRoles;
using MyProject.UserRoles.Dtos;
using MyProject.Users.Dtos;

namespace MyProject
{
    public class MyProjectApplicationAutoMapperProfile : Profile
    {
        public MyProjectApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>(MemberList.Source);
            CreateMap<UpdateUserDto, User>(MemberList.Source);
            CreateMap<Role, RoleDto>();
            CreateMap<CreateRoleDto, Role>(MemberList.Source);
            CreateMap<UpdateRoleDto, Role>(MemberList.Source);
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<CreateUserRoleDto, UserRole>(MemberList.Source);
            CreateMap<UpdateUserRoleDto, UserRole>(MemberList.Source);
        }
    }
}
