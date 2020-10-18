using System;
using System.Collections.Generic;
using System.Text;

using Volo.Abp.Application.Dtos;

namespace MyProject.AuditLogs.Dtos
{
    public class GetAuditLogsInputDto : PagedAndSortedResultRequestDto
    {
        public DateTime? BeginTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
