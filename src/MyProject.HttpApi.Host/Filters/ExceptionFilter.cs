using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

using MyProject.HttpResult;

namespace MyProject.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnException(ExceptionContext context)
        {
            var result = new Result<string>
            {
                Code = ResultCode.Error,
                Message = context.Exception.Message
            };
            context.Result = new ObjectResult(result);
            context.ExceptionHandled = true;
            // 错误日志记录
            logger.LogError($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
