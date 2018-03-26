namespace HotleConvenience.Model.SmallAppModel
{
    public class SmallApp_UserInfo
    {
        /// <summary>
        /// 微信用户openid
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 性别 0：未知、1：男、2：女
        /// </summary>
        public int gender { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string avatarUrl { get; set; }
        /// <summary>
        /// 联合ID,在多个微信公众号下一个开发者 下唯一
        /// </summary>
        public string unionId { get; set; }
        /// <summary>
        /// 水印
        /// </summary>
        public Watermark watermark { get; set; }
    }

    public class Watermark
    {
        /// <summary>
        /// 微信ID
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long timestamp { get; set; }
    }

}
