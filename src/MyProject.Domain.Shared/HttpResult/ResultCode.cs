using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyProject.HttpResult
{
    public enum ResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 20000,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = 20001,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Error = 20002,
        /// <summary>
        /// 拒绝访问
        /// </summary>
        [Description("拒绝访问")]
        Forbidden = 40000,
        /// <summary>
        /// 非法令牌/未授权
        /// </summary>
        [Description("非法令牌/未授权")]
        UnAuthorized = 50000,
        /// <summary>
        /// 令牌超时
        /// </summary>
        [Description("令牌超时")]
        TokenExpired = 50001
    }
}
