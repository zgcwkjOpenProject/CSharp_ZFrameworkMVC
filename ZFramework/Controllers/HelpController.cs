/*
代码生成器 V 1.9.0.3 zgcwkj
生成时间：2019年03月02日
在使用过程中应当保留原作者相关版权
*/
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