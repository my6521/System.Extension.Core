﻿using EInfrastructure.Core.Exception;

namespace EInfrastructure.Core.Redis.Config
{
    /// <summary>
    /// Redis配置
    /// </summary>
    public class RedisConfig
    {
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 储存的数据库索引
        /// </summary>
        public int DataBase { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Redis连接池连接数
        /// </summary>
        public int PoolSize { get; set; }

        /// <summary>
        /// Redis链接信息
        /// </summary>
        private static RedisConfig Config;

        /// <summary>
        /// 设置Redis链接信息
        /// </summary>
        /// <param name="config"></param>
        internal static void Set(RedisConfig config)
        {
            Config = config;
        }

        /// <summary>
        /// 读取Redis链接信息
        /// </summary>
        /// <returns></returns>
        internal static RedisConfig Get()
        {
            if (Config == null)
            {
                throw new BusinessException("未配置Redis链接信息");
            }

            return Config;
        }
    }
}