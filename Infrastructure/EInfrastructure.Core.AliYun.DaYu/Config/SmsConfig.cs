﻿using EInfrastructure.Core.Exception;

namespace EInfrastructure.Core.AliYun.DaYu.Config
{
    /// <summary>
    /// 短信配置
    /// </summary>
    public class SmsConfig
    {
        /// <summary>
        /// 秘钥参数
        /// </summary>
        public string EncryptionKey { get; set; }
        
        /// <summary>
        /// 短信配置
        /// </summary>
        private static SmsConfig Config;

        /// <summary>
        /// 设置短信配置
        /// </summary>
        /// <param name="smsConfig"></param>
        internal static void Set(SmsConfig smsConfig)
        {
            Config = smsConfig;
        }

        /// <summary>
        /// 读取短信配置
        /// </summary>
        /// <returns></returns>
        internal static SmsConfig Get()
        {
            if (Config == null)
            {
                throw new BusinessException("未配置短信");
            }

            return Config;
        }
    }
}