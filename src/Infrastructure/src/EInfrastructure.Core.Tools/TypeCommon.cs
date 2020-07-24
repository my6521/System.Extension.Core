﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace EInfrastructure.Core.Tools
{
    /// <summary>
    ///
    /// </summary>
    public class TypeCommon
    {
        #region 获取类型

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>()
        {
            return GetType(typeof(T));
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType(Type type)
        {
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        #endregion

        #region 判断是否枚举

        /// <summary>
        /// 判断是否枚举
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEnum(Type type)
        {
            return type.GetTypeInfo().IsEnum;
        }

        #endregion
    }
}
