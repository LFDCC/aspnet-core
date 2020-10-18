using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyProject.AuditLogs.Dtos;
using MyProject.HttpResult;
using Volo.Abp.Application.Services;

namespace MyProject.AuditLogs
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<Result<List<AuditLogDto>>> GetListAsync(GetAuditLogsInputDto input);
    }
}
