using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ZFramework.Controllers
{
    /// <summary>
    /// Admin控制器
    /// </summary>
    public class AdminController : Controller
    {
        #region 登录页面、登录验证码、登录验证、登录用户

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["Accounts"] != null) return RedirectToAction("Admin"); //重定向到Admin
            if (Session["Accounts"] != null) ViewData["Accounts"] = Session["Accounts"].ToString();//账号
            if (Session["Password"] != null) ViewData["Password"] = Session["Password"].ToString();//密码
            if (Session["Remember"] != null) ViewData["Remember"] = Session["Remember"].ToString();//记住密码
            ViewData["DateTime"] = Common.Tools_Date.ConvertDateTime(DateTime.Now);//时间戳

            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateImage()
        {
            Common.Tools_ValidateCode ValidateCode = new Common.Tools_ValidateCode(6);
            Session["ValidateCode"] = ValidateCode.GetValidate();
            return File(ValidateCode.GetImage(), "image/jpg");
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="rememberMe">是否记住用户</param>
        /// <param name="accounts">用户账号</param>
        /// <param name="password">用户密码</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="captcha">验证码</param>
        /// <returns></returns>
        public ActionResult Login(string rememberMe, string accounts, string password, string timestamp, string captcha)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (Session["ValidateCode"] != null)//防止页面的打开方式是不正确
            {
                if (rememberMe != null && accounts != null && password != null && captcha != null && timestamp != null)
                {
                    if (rememberMe != "" && accounts != "" && password != "" && captcha != "" && timestamp != "")
                    {
                        TimeSpan timeSpan = Common.Tools_Date.DateDiff2(DateTime.Now, Common.Tools_Date.GetTime(timestamp));
                        if (timeSpan.TotalSeconds < 120)//在打开网页的两分钟内必须完成登录
                        {
                            string validateCode = Session["ValidateCode"].ToString();
                            if (validateCode.ToLower() == captcha.ToLower())
                            {
                                #region SQL查询方法

                                SqlParameter[] sql =
                                {
                                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireLogin" },
                                    new SqlParameter("@Accounts",SqlDbType.NChar){ Value = accounts },
                                };
                                DataTable dtUser = Models.StaticData.myDal.QueryDataTable("AdminManage", sql);

                                #endregion SQL查询方法

                                if (dtUser.Rows.Count > 0)
                                {
                                    string passwords = password;
                                    //将密码进行Base64解密
                                    passwords = Common.Tools_Base64.DecodeBase64(passwords);
                                    //将密码进行MD5加密
                                    passwords = Common.Tools_MD5.GetMd5(passwords);
                                    if (dtUser.Rows[0]["Password"].ToString() == passwords)
                                    {
                                        returnJson.Message = "登录成功，马上跳转";
                                        returnJson.Status = true;

                                        #region 重要的数据存储到Session中

                                        string remember = "checked";//记住密码
                                        try
                                        {
                                            if (!Convert.ToBoolean(rememberMe))
                                            {
                                                accounts = "";
                                                password = "";
                                                remember = "";
                                            }
                                        }
                                        catch { }

                                        Session["UserID"] = dtUser.Rows[0]["UserID"].ToString();
                                        Session["RoleID"] = dtUser.Rows[0]["RoleID"].ToString();
                                        Session["Single"] = dtUser.Rows[0]["Single"].ToString();
                                        Session["UserName"] = dtUser.Rows[0]["UserName"].ToString();
                                        Session["Accounts"] = accounts;
                                        Session["Password"] = password;
                                        Session["Remember"] = remember;

                                        #endregion 重要的数据存储到Session中

                                        #region 点对点登录(生成)

                                        Models.Authorization.PointToPointLogin_G(this);

                                        #endregion 点对点登录(生成)
                                    }
                                    else returnJson.Message = "您输入的密码错误";
                                }
                                else returnJson.Message = "您输入的账号错误";
                            }
                            else returnJson.Message = "您输入的验证码错误";
                        }
                        else returnJson.Message = "请您刷新界面后操作";
                    }
                }
            }
            return Json(returnJson, JsonRequestBehavior.DenyGet);
        }

        #endregion 登录页面、登录验证码、登录验证、登录用户

        #region 后台面板、后台面板生成、修改个人信息、退出登录

        /// <summary>
        /// 后台面板
        /// </summary>
        /// <returns></returns>
        [Models.Authorization]
        public ActionResult Admin()
        {
            #region SQL查询拥有的菜单

            SqlParameter[] sql =
            {
                new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireMenu"},
                new SqlParameter("@RoleID",SqlDbType.NChar){ Value = Session["RoleID"]},
            };
            DataTable dtMenu = Models.StaticData.myDal.QueryDataTable("AdminManage", sql);

            #endregion SQL查询拥有的菜单

            #region 动态生成左侧功能

            //页面填写 @Html.Raw(ViewBag.Html)
            string _html = "";//输出到页面
            if (dtMenu.Rows.Count > 0)
            {
                foreach (DataRow dtMenu1 in dtMenu.Rows)
                {
                    if (dtMenu1["ParentID"].ToString() == "0")//父ID为0
                    {
                        string Title_1 = dtMenu1["Title"].ToString();//一级菜单名称
                        string Icon_1 = dtMenu1["Icon"].ToString();//一级菜单图标
                        string Link_1 = dtMenu1["Link"].ToString();//一级菜单连接
                        string RBehavior_1 = dtMenu1["RBehavior"].ToString();//二级菜单权限

                        _html += "<li>";
                        if (Link_1.Trim() == "")
                        {
                            _html += "<a href='javascript:void(0);'>";
                            if (Icon_1 != "") _html += "<i class='" + Icon_1 + "'></i>";
                            _html += "<span class='nav-label'>" + Title_1 + "</span>";
                            _html += "<span class='fa arrow'></span>";
                            _html += "</a>";
                            foreach (DataRow dtMenu2 in dtMenu.Rows)
                            {
                                if (dtMenu1["MenuID"].ToString() == dtMenu2["ParentID"].ToString())
                                {
                                    string Title_2 = dtMenu2["Title"].ToString();//二级菜单名称
                                    string Icon_2 = dtMenu2["Icon"].ToString();//二级菜单图标
                                    string Link_2 = dtMenu2["Link"].ToString();//二级菜单连接
                                    string RBehavior_2 = dtMenu2["RBehavior"].ToString();//二级菜单权限

                                    _html += "<ul class='nav nav-second-level'>";

                                    _html += "<li>";
                                    _html += "<a class='J_menuItem' href='" + Link_2 + "?Behavior=" + RBehavior_2 + "'>";
                                    if (Icon_2 != "") _html += "<i class='" + Icon_2 + "'></i>";
                                    _html += "<span class='nav-label'>" + Title_2 + "</span>";
                                    _html += "</a>";
                                    _html += "</li>";

                                    _html += "</ul>";
                                }
                            }
                            _html += "";
                        }
                        else
                        {
                            _html += "<a class='J_menuItem' href='" + Link_1 + "?Behavior=" + RBehavior_1 + "'>";
                            if (Icon_1 != "") _html += "<i class='" + Icon_1 + "'></i>";
                            _html += "<span class='nav-label'>" + Title_1 + "</span>";
                            _html += "</a>";
                        }
                        _html += "</li>";
                    }
                }
            }
            ViewBag.Html = _html;//输出到页面
            ViewData["UserName"] = Session["UserName"].ToString();//用户名称

            #endregion 动态生成左侧功能

            return View();
        }

        /// <summary>
        /// 后台菜单
        /// </summary>
        /// <returns></returns>
        [Models.Authorization]
        public ActionResult Menu()
        {
            #region SQL查询拥有的菜单

            SqlParameter[] sql =
            {
                new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireMenu"},
                new SqlParameter("@RoleID",SqlDbType.NChar){ Value = Session["RoleID"]},
            };
            var listMenu = Models.StaticData.myDal.QueryList("AdminManage", sql);

            #endregion SQL查询拥有的菜单

            return Json(listMenu, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="Name">用户名称</param>
        /// <param name="Password">旧密码</param>
        /// <param name="toPassword">新密码</param>
        /// <returns></returns>
        [Models.Authorization]
        public ActionResult UpdateUser(string Name, string Password, string toPassword)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (Name == null || Password == null || toPassword == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }

            //把密码加密一遍
            Password = Common.Tools_MD5.GetMd5(Password);
            toPassword = Common.Tools_MD5.GetMd5(toPassword);

            #region SQL操作方法

            SqlParameter[] sql =
            {
                new SqlParameter("@Type",SqlDbType.NChar){ Value = "UpdateUser" },
                new SqlParameter("@UserName",SqlDbType.NChar){ Value = Name },
                new SqlParameter("@Password",SqlDbType.NChar){ Value = Password },
                new SqlParameter("@toPassword",SqlDbType.NChar){ Value = toPassword },
                new SqlParameter("@UserID",SqlDbType.NChar){ Value = Session["UserID"] }
            };
            int count = Models.StaticData.myDal.UpdateData("AdminManage", sql);

            #endregion SQL操作方法

            if (count > 0)
            {
                Session.Clear();
                returnJson.Message = "修改成功，请您重新登录";
                returnJson.Status = true;
            }
            else
            {
                returnJson.Message = "修改失败，请您重新尝试";
                returnJson.Status = false;
            }
            return Json(returnJson, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [Models.Authorization]
        public ActionResult ExitUser()
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            try
            {
                Session.Clear();
                returnJson.Message = "成功退出，请等待";
                returnJson.Status = true;
            }
            catch
            {
                returnJson.Message = "退出失败，请重试";
                returnJson.Status = true;
            }

            return Json(returnJson, JsonRequestBehavior.DenyGet);
        }

        #endregion 后台面板、后台面板生成、修改个人信息、退出登录
    }
}