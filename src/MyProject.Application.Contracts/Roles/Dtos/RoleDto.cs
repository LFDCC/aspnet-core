using System;
using Volo.Abp.Application.Dtos;

namespace MyProject.Roles.Dtos
{
    [Serializable]
    public class RoleDto : FullAuditedEntityDto<Guid>
    {
        public string RoleName { get; set; }
    }
}