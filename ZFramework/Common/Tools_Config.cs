/*
代码生成器 V 1.9.0.3 zgcwkj
生成时间：2019年03月02日
在使用过程中应当保留原作者相关版权
*/
using System.Configuration;

namespace ZFramework.Common
{
    /// <summary>
    /// 配置文件工具
    /// </summary>
    public class Tools_Config
    {
        //组态
        private Configuration config = null;

        /// <summary>
        /// 实例配置文件对象
        /// </summary>
        public Tools_Config()
        {
            //获取Configuration对象
            //config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //string path = System.Web.Mvc.Server.MapPath("~/Web.config");
            config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
        }

        /// <summary>
        /// 查询配置文件
        /// </summary>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public string Inquire(string Name)
        {
            //根据Key读取元素的Value
            return config.AppSettings.Settings[Name].Value;
        }

        /// <summary>
        /// 新增配置文件
        /// </summary>
        /// <param name="Name">名称</param>
        /// <param name="Data">数据</param>
        /// <returns></returns>
        public bool Insert(string Name, string Data)
        {
            try
            {
                //增加元素
                config.AppSettings.Settings.Add(Name, Data);
                //一定要记得保存，写不带参数的config.Save()也可以
                config.Save(ConfigurationSaveMode.Modified);
                //刷新，否则程序读取的还是之前的值（可能已装入内存）
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改配置文件
        /// </summary>
        /// <param name="Name">名称</param>
        /// <param name="Data">数据</param>
        /// <returns></returns>
        public bool Update(string Name, string Data)
        {
            try
            {
                //更新元素
                config.AppSettings.Settings[Name].Value = Data;
                //一定要记得保存，写不带参数的config.Save()也可以
                config.Save(ConfigurationSaveMode.Modified);
                //刷新，否则程序读取的还是之前的值（可能已装入内存）
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除配置文件
        /// </summary>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public bool Delete(string Name)
        {
            try
            {
                ////删除元素
                config.AppSettings.Settings.Remove(Name);
                //一定要记得保存，写不带参数的config.Save()也可以
                config.Save(ConfigurationSaveMode.Modified);
                //刷新，否则程序读取的还是之前的值（可能已装入内存）
                ConfigurationManager.RefreshSection("appSettings");

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void AccessAppSettings()
        {
            ////直接读取配置文件
            //System.Configuration.ConfigurationManager.AppSettings["name"];
            ////获取Configuration对象
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ////根据Key读取元素的Value
            //string name = config.AppSettings.Settings["name"].Value;
            ////写入元素的Value
            //config.AppSettings.Settings["name"].Value = "xieyc";
            ////增加元素
            //config.AppSettings.Settings.Add("url", "http://www.myhack58.com");
            ////删除元素
            //config.AppSettings.Settings.Remove("name");
            ////一定要记得保存，写不带参数的config.Save()也可以
            //config.Save(ConfigurationSaveMode.Modified);
            ////刷新，否则程序读取的还是之前的值（可能已装入内存）
            //ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
