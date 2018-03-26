using HotleConvenience.Lib.Encrypt;
using HotleConvenience.Lib.Http;
using HotleConvenience.Model.SmallAppModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotleConvenience.Lib.WeSmallApp
{
    public class SmallAppClient
    {
        private SmallApp_Setting _setting;
        public SmallAppClient(IOptions<SmallApp_Setting> settingOption)
        {
            _setting = settingOption.Value;
        }
        public async Task<SmallApp_KeyInfo> GetKeyInfo(string code)
        {
            var uri = $"https://api.weixin.qq.com/sns/jscode2session?appid={_setting.appid}&secret={_setting.secret}&js_code={code}&grant_type={_setting.grant_type}";
            var json = await HttpTool.GetStringAsync(uri);
            var keyInfo = JsonConvert.DeserializeObject<SmallApp_KeyInfo>(json);
            return keyInfo;
        }

        public SmallApp_UserInfo GetUserInfo(SmallApp_InfoData data, string session_key)
        {
            //签名验证
            var sign = FrequentlyEncrypt.Sha1(data.rawData + session_key);
            if (sign.ToLower() != data.signature.ToLower())
            {
                throw new Exception("签名验证不通过");
            }

            //解密开始
            try
            {
                var user = JsonConvert.DeserializeObject<SmallApp_UserInfo>(FrequentlyEncrypt.AesDecrypt(data.encryptedData, session_key, data.iv, CipherMode.CBC));
                //水印验证
                if (user.watermark.appid != _setting.appid)
                {
                    throw new Exception("水印验证不通过");
                }
                return user;
            }
            catch
            {
                throw new Exception("解密失败");
            }
        }
    }
}
