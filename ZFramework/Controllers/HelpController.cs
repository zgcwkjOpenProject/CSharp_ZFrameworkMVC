using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZFramework.Controllers
{
    /// <summary>
    /// 帮助控制器
    /// </summary>
    public class HelpController : Controller
    {
        /// <summary>
        /// 框架介绍、框架说明、框架使用方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 404页面
        /// 在web.config的system.web节点上添加如下内容
        /// <customErrors mode="On" defaultRedirect="Help/Error">
        ///   <error statusCode="404" redirect="Help/Error" />
        /// </customErrors>
        /// </summary>
        /// <param name="aspxerrorpath">自动传递报错的参数</param>
        /// <returns></returns>
        public ActionResult Error(string aspxerrorpath)
        {
            ViewData["html"] = aspxerrorpath;

            return View();
        }
    }
}