/*
代码生成器 V 1.9.0.5 zgcwkj
生成时间：2019年06月11日
在使用过程中应当保留原作者相关版权
*/
using System.Web.Mvc;

namespace ZFramework.Areas.BTest
{
    public class BTestAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BTest";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BTest_default",
                "BTest/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}