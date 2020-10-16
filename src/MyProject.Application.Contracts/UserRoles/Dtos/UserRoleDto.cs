using System;

using MyProject.Roles.Dtos;
using MyProject.Users.Dtos;

using Volo.Abp.Application.Dtos;

namespace MyProject.UserRoles.Dtos
{
    [Serializable]
    public class UserRoleDto : EntityDto
    {
        public Guid UserId { get; set; }

        public UserDto User { get; set; }

        public Guid RoleId { get; set; }

        public RoleDto Role { get; set; }
    }
}