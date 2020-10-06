using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Users.Dtos
{
    public class UserInfoDto
    {
        public string Name { get; set; }
        public string[] Roles { get; set; }
        public string Avatar { get; set; }
        public string Introduction { get; set; }

    }
}
