using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using MyProject.Roles;
using MyProject.UserRoles;

using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace MyProject.Users
{

    public class User : FullAuditedEntity<Guid>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        protected User()
        {
        }

        public User(
            Guid id,
            string userName,
            string password,
            string realName,
            string email,
            string phone
        ) : base(id)
        {
            UserName = userName;
            Password = password;
            RealName = realName;
            Email = email;
            Phone = phone;
            UserRoles = new Collection<UserRole>();
        }
    }
}
