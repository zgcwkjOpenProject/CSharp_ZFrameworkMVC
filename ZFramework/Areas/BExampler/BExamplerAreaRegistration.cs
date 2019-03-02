/*
代码生成器 V 1.9.0.3 zgcwkj
生成时间：2019年03月02日
在使用过程中应当保留原作者相关版权
*/
using System.Web.Mvc;

namespace ZFramework.Areas.BExampler
{
    public class BExamplerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BExampler";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BExampler_default",
                "BExampler/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}