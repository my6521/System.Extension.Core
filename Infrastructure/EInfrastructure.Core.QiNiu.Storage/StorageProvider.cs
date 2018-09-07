﻿using System.IO;
using EInfrastructure.Core.Interface.IOC;
using EInfrastructure.Core.Interface.Storage;
using EInfrastructure.Core.Interface.Storage.Param;
using EInfrastructure.Core.QiNiu.Storage.Config;
using Microsoft.Extensions.Options;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;

namespace EInfrastructure.Core.QiNiu.Storage
{
    /// <summary>
    /// 存储
    /// </summary>
    public class StorageProvider : BaseStorageProvider, IStorageService, ISingleInstance
    {
        public StorageProvider(IOptionsSnapshot<QiNiuConfig> qiNiuSnapshot)
            : base(qiNiuSnapshot)
        {
        }

        #region 根据文件流上传

        /// <summary>
        /// 根据文件流上传
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool UploadStream(UploadByStreamParam param)
        {
            SetPutPolicy(param.Key, param.UploadPersistentOps.IsAllowOverlap, param.UploadPersistentOps.PersistentOps);
            string token = Auth.CreateUploadToken(Mac, PutPolicy.ToJsonString());
            FormUploader target = new FormUploader(GetConfig(param.UploadPersistentOps));
            HttpResult result =
                target.UploadStream(param.Stream, param.Key, token, GetPutExtra(param.UploadPersistentOps));
            return result.Code == (int) HttpCode.OK;
        }

        #endregion

        #region 根据文件上传

        /// <summary>
        /// 根据文件上传
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public bool UploadFile(UploadByFormFileParam param)
        {
            SetPutPolicy(param.Key, param.UploadPersistentOps.IsAllowOverlap, param.UploadPersistentOps.PersistentOps);
            string token = Auth.CreateUploadToken(Mac, PutPolicy.ToJsonString());
            FormUploader target = new FormUploader(GetConfig(param.UploadPersistentOps));
            if (param.File != null)
            {
                HttpResult result =
                    target.UploadStream(param.File.OpenReadStream(), param.Key, token, GetPutExtra(param.UploadPersistentOps));
                return result.Code == (int) HttpCode.OK;
            }
            return false;
        }

        #endregion
    }
}