using System.Collections.Generic;
using System.Threading.Tasks;

using MyProject.AuditLogs;
using MyProject.AuditLogs.Dtos;
using MyProject.HttpResult;

using Volo.Abp.AuditLogging;

namespace MyProject.AuditingLogs
{

    public class AuditLogAppService : MyProjectAppService, IAuditLogAppService
    {
        private readonly IAuditLogRepository _auditingLogRepository;
        public AuditLogAppService(IAuditLogRepository auditingLogRepository)
        {
            _auditingLogRepository = auditingLogRepository;
        }
        /// <summary>
        /// 获取审计日志
        /// </summary>
        /// <param name="input">输入参数</param>
        /// <returns></returns>
        public async Task<Result<List<AuditLogDto>>> GetListAsync(GetAuditLogsInputDto input)
        {
            var list = await _auditingLogRepository.GetListAsync(
                sorting: input.Sorting,
                maxResultCount: input.MaxResultCount,
                skipCount: input.SkipCount,
                startTime: input.BeginTime,
                endTime: input.EndTime,
                includeDetails: true);
            var listDto = ObjectMapper.Map<List<AuditLog>, List<AuditLogDto>>(list);
            var result = new Result<List<AuditLogDto>>
            {
                Code = ResultCode.Success,
                Data = listDto
            };
            return result;
        }
    }
}
