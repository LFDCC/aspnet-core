using System;
using System.ComponentModel;
namespace MyProject.Roles.Dtos
{
    [Serializable]
    public class CreateRoleDto
    {
        public string RoleName { get; set; }
    }
}