using System;
using System.ComponentModel;

namespace MyProject.Roles.Dtos
{
    [Serializable]
    public class UpdateRoleDto
    {
        public string RoleName { get; set; }
    }
}