using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZFramework.Models
{
    public static class StaticData
    {
        /// <summary>
        /// 配置文件实例
        /// </summary>
        public static Common.Tools_Config myConfig = new Common.Tools_Config();

        /// <summary>
        /// 数据库连接实例
        /// </summary>
        public static Common.Tools_DAL myDal = new Common.Tools_DAL();
    }
}