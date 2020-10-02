using System;
using System.ComponentModel;
namespace MyProject.Users.Dtos
{
    [Serializable]
    public class CreateUserDto
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string RoleName { get; set; }
    }
}