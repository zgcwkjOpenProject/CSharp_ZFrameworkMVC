using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ZFramework.Controllers
{
    /// <summary>
    /// Home控制器
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}