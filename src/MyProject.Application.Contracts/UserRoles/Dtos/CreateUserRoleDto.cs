using System;
using System.ComponentModel;
namespace MyProject.UserRoles.Dtos
{
    [Serializable]
    public class CreateUserRoleDto
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}