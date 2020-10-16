using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using MyProject.UserRoles;

using Volo.Abp.Domain.Entities.Auditing;

namespace MyProject.Roles
{
    public class Role : FullAuditedEntity<Guid>
    {
        public string RoleName { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        protected Role()
        {
        }

        public Role(
            Guid id, 
            string roleName
        ) : base(id)
        {
            RoleName = roleName;
            UserRoles = new Collection<UserRole>();
        }
    }
}
