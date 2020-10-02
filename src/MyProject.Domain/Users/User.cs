using System;

using MyProject.Roles;

using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace MyProject.Users
{

    public class User : FullAuditedEntity<Guid>
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string RoleName { get; set; }


        protected User()
        {
        }

        public User(
            Guid id, 
            string userName, 
            string passWord, 
            string realName, 
            string email, 
            string phone, 
            string roleName
        ) : base(id)
        {
            UserName = userName;
            PassWord = passWord;
            RealName = realName;
            Email = email;
            Phone = phone;
            RoleName = roleName;
        }
    }
}
