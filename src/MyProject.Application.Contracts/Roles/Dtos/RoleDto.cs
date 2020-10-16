using System;
using System.Collections.Generic;

using MyProject.UserRoles.Dtos;

using Volo.Abp.Application.Dtos;

namespace MyProject.Roles.Dtos
{
    [Serializable]
    public class RoleDto : FullAuditedEntityDto<Guid>
    {
        public string RoleName { get; set; }

        public List<UserRoleDto> UserRoles { get; set; }
    }
}