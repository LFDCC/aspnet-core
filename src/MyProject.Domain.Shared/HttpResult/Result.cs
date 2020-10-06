using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.HttpResult
{
    public class Result<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public ResultCode Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 结果集
        /// </summary>
        public T Data { get; set; }
    }
}
