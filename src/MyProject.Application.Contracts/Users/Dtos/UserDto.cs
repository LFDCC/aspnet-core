using System;
using Volo.Abp.Application.Dtos;

namespace MyProject.Users.Dtos
{
    [Serializable]
    public class UserDto : FullAuditedEntityDto<Guid>
    {
        public string UserName { get; set; }

        public string RealName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string RoleName { get; set; }
    }
}