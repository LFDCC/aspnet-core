using System;
using System.Collections.Generic;
using System.Text;

using MyProject.Roles;
using MyProject.Users;

using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace MyProject.UserRoles
{
    public class UserRole : Entity
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { UserId, RoleId };
        }

        protected UserRole()
        {
        }

        public UserRole(

            Guid userId,
            Guid roleId
        )
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
