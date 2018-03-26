namespace HotleConvenience.Model.SmallAppModel
{
    public class SmallApp_InfoData
    {
        /// <summary>
        /// 不包括敏感信息的原始数据字符串，用于计算签名。
        /// </summary>
        public string rawData { get; set; }
        /// <summary>
        /// 使用 sha1( rawData + sessionkey ) 得到字符串，用于校验用户信息，参考文档 signature。
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 包括敏感数据在内的完整用户信息的加密数据，详细见加密数据解密算法
        /// </summary>
        public string encryptedData { get; set; }
        /// <summary>
        /// 加密算法的初始向量，详细见加密数据解密算法
        /// </summary>
        public string iv { get; set; }
    }
}
