using System;
using System.Collections.Generic;
using System.Text;

namespace HotleConvenience.Model
{
    public interface IUtilityEntity<T>
    {
        /// <summary>
        /// Id
        /// </summary>
        T Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建日期 非聚集索引
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// 软删除 默认false
        /// </summary>
        bool IsDelete { get; set; }
    }
}
