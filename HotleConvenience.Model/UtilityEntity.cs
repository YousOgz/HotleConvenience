using System;
using System.Collections.Generic;
using System.Text;

namespace HotleConvenience.Model
{
    public class UtilityEntity:IUtilityEntity<int>
    {
        public UtilityEntity()
        {
            this.CreateDate = DateTime.Today;
            this.CreateTime = DateTime.Now;
            this.IsDelete = false;
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建日期 非聚集索引
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 软删除 默认false
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
