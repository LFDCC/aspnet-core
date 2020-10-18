using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace MyProject.AuditLogs.Dtos
{
    public class AuditLogActionDto : EntityDto<Guid>
    {
        public virtual Guid? TenantId
        {
            get;
            set;
        }

        public virtual Guid AuditLogId
        {
            get;
            set;
        }

        public virtual string ServiceName
        {
            get;
            set;
        }

        public virtual string MethodName
        {
            get;
            set;
        }

        public virtual string Parameters
        {
            get;
            set;
        }

        public virtual DateTime ExecutionTime
        {
            get;
            set;
        }

        public virtual int ExecutionDuration
        {
            get;
            set;
        }

        public virtual Dictionary<string, object> ExtraProperties
        {
            get;
            set;
        }
    }
}