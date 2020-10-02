using System;
using System.Collections.Generic;
using System.Text;

using MyProject.Users;

using Volo.Abp.Domain.Entities.Auditing;

namespace MyProject.Roles
{
    public class Role : FullAuditedEntity<Guid>
    {
        public string RoleName { get; set; }


        protected Role()
        {
        }

        public Role(
            Guid id, 
            string roleName
        ) : base(id)
        {
            RoleName = roleName;
        }
    }
}
