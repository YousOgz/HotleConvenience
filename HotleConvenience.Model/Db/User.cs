using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HotleConvenience.Model.Db
{
    public class User:UtilityEntity
    {
        public UserType UserType { get; set; }
    }

    public enum UserType {
        [Description("管理员")]
        Administrator =0,
        [Description("消费者")]
        Customer,
        [Description("商家")]
        Business
    }
}
