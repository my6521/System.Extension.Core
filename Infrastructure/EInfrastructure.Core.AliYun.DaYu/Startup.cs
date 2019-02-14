using System;
using EInfrastructure.Core.AliYun.DaYu.Config;
using Microsoft.Extensions.DependencyInjection;

namespace EInfrastructure.Core.AliYun.DaYu
{
    /// <summary>
    /// 加载阿里大于短信服务
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// 加载此服务
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="action"></param>
        public static IServiceCollection AddAliDaYu(this IServiceCollection serviceCollection,
            Action<SmsConfig> action)
        {
            action.Invoke(SmsConfig.Get());
            return serviceCollection;
        }
    }
}