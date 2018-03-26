namespace HotleConvenience.Lib.Cache
{
    public interface ICache
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time">相对过期时间,秒</param>
        /// <returns></returns>
        void AddOrUpdate<T>(string key, T value, int time=7200);
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool HasKey(string key);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        void Remove(string key);
    }
}
