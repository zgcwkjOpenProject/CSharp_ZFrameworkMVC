using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZFramework.Models
{
    /// <summary>
    /// 权限检测类
    /// </summary>
    public class Authorization : FilterAttribute, IAuthorizationFilter
    {
        private int userID = 0;//用户ID
        private int roleID = 0;//角色ID

        /// <summary>
        /// 检验授权方法
        /// </summary>
        /// <param name="filterContext">接收控件器相关信息</param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string toClass = filterContext.Controller.ToString();//获取访问的控制器类名
            string toPageName = filterContext.ActionDescriptor.ActionName;//获取访问的页面名称
            string toControllerName = toClass.Split('.')[toClass.Split('.').Count() - 1];//获取访问的控制器名
            string toUserIP = filterContext.HttpContext.Request.UserHostAddress;//获取访问者的IP地址
            string toFilePath = filterContext.HttpContext.Request.FilePath;//获取访问的地址
            string toFilePathS = toFilePath.Substring(0, toFilePath.LastIndexOf("/"));//获取访问的地址并减少尾部

            #region 验证并读取Session数据

            var UserID = filterContext.HttpContext.Session["UserID"];
            var RoleID = filterContext.HttpContext.Session["RoleID"];
            if (UserID == null || RoleID == null)
            {
                Jumpout(filterContext, "/Admin/index?Data=验证过期");
                return;
            }
            userID = Convert.ToInt32(UserID);
            roleID = Convert.ToInt32(RoleID);

            #endregion 验证并读取Session数据

            #region 通过数据库验证是否存在权限

            if (toControllerName != "AdminController")//放行 AdminController 控制器
            {
                #region 查询数据库上记录的权限

                SqlParameter[] sqlInquireRoleDetail1 =
                {
                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireRoleDetail" },
                    new SqlParameter("@RoleID",SqlDbType.Int){ Value = roleID },
                    new SqlParameter("@QueryLikeStr",SqlDbType.NChar){ Value = toFilePath },
                };
                DataTable dtRoleDetail = Models.StaticData.myDal.QueryDataTable("RoleManage", sqlInquireRoleDetail1);
                if (dtRoleDetail.Rows.Count == 0)
                {
                    SqlParameter[] sqlInquireRoleDetail2 =
                    {
                        new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireRoleDetail" },
                        new SqlParameter("@RoleID",SqlDbType.Int){ Value = roleID },
                        new SqlParameter("@QueryLikeStr",SqlDbType.NChar){ Value = toFilePathS },
                    };
                    dtRoleDetail = Models.StaticData.myDal.QueryDataTable("RoleManage", sqlInquireRoleDetail2);
                }

                #endregion 查询数据库上记录的权限

                //验证权限是否存在
                int RoleCount = 0;//统计关键字出现次数
                if (dtRoleDetail.Rows.Count > 0)
                {
                    string Behavior = dtRoleDetail.Rows[0][0].ToString();

                    foreach (string behavior in Behavior.Split(','))
                    {
                        //判断关键字是否匹配成功
                        if (toPageName.ToLower().Contains(behavior.ToLower())) RoleCount++;
                    }
                }
                //如果没出现过关键字这代表没有权限
                if (RoleCount == 0)
                {
                    Jumpout(filterContext, "/Admin/index?Data=越权访问");
                    return;
                }
            }

            #endregion 通过数据库验证是否存在权限

            #region 点对点登录(验证)

            if (!PointToPointLogin_V(filterContext))
            {
                filterContext.HttpContext.Session.Clear();
                Jumpout(filterContext, "/Admin/index?Data=账号被逼退");
                return;
            }

            #endregion 点对点登录(验证)

            #region 新增当前操作的日志

            //SqlParameter[] sqlInsertLogData =
            //{
            //    new SqlParameter("@Type",SqlDbType.NChar){ Value = "InsertLogData" },
            //    new SqlParameter("@UserID",SqlDbType.Int){ Value = userID },
            //    new SqlParameter("@UserIP",SqlDbType.NChar){ Value = toUserIP },
            //    new SqlParameter("@RequestPath",SqlDbType.NChar){ Value = toFilePath },
            //    new SqlParameter("@Controller",SqlDbType.NChar){ Value = toControllerName },
            //};
            //Models.StaticData.myDal.UpdateData("LogManage", sqlInsertLogData);

            #endregion 新增当前操作的日志
        }

        /// <summary>
        /// 点对点登录(验证)
        /// </summary>
        /// <param name="filterContext">接收控件器相关信息</param>
        /// <returns>是否通过</returns>
        private bool PointToPointLogin_V(AuthorizationContext filterContext)
        {
            //是否只允许一处登录
            if (!Convert.ToBoolean(filterContext.HttpContext.Session["Single"])) return true;

            //查询用户的信息
            SqlParameter[] sql =
            {
                new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireVerify" },
                new SqlParameter("@UserID",SqlDbType.NChar){ Value = userID },
            };
            DataTable dtInquireVerify = Models.StaticData.myDal.QueryDataTable("AdminManage", sql);
            //--> 读取Cookie
            if (Common.Tools_Cookie.Read("Landing", "Verification") == dtInquireVerify.Rows[0]["Verify"].ToString())
            {
                filterContext.HttpContext.Session["Single"] = dtInquireVerify.Rows[0]["Single"].ToString();
                return true;
            }

            return false;
        }

        /// <summary>
        /// 点对点登录(生成)
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>是否成功</returns>
        public static bool PointToPointLogin_G(Controller controller)
        {
            //是否只允许一处登录
            if (!Convert.ToBoolean(controller.Session["Single"])) return false;

            //随机码
            string random = new Common.Tools_RandomCode(true, true, false).GoRandom(10);
            //用户ID
            int userID = Convert.ToInt32(controller.Session["UserID"]);
            //查询用户的信息
            SqlParameter[] sql =
            {
                new SqlParameter("@Type",SqlDbType.NChar){ Value = "UpdateVerify" },
                new SqlParameter("@UserID",SqlDbType.NChar){ Value = userID },
                new SqlParameter("@Verify",SqlDbType.NChar){ Value = random },
            };
            Models.StaticData.myDal.UpdateData("AdminManage", sql);

            //-->  设置Cookie
            Common.Tools_Cookie.Write("Landing", "Verification", random, 1);

            return true;
        }

        /// <summary>
        /// 跳转界面
        /// </summary>
        /// <param name="filterContext">接收控件器相关信息</param>
        /// <param name="url">准备跳转到的界面路径</param>
        private void Jumpout(AuthorizationContext filterContext, string url)
        {
            filterContext.Result = new RedirectResult(url);
        }
    }
}