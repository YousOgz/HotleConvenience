namespace HotleConvenience.Model.SmallAppModel
{
    public class SmallApp_KeyInfo
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public string open_id { get; set; }
        /// <summary>
        /// 会话密钥
        /// </summary>
        public string session_key { get; set; }
        /// <summary>
        /// 用户在开放平台的唯一标识符。本字段在满足一定条件的情况下才返回。具体参看UnionID机制说明
        /// </summary>
        public string unionid { get; set; }
    }
}
