/*
代码生成器 V 1.9.0.3 zgcwkj
生成时间：2019年03月02日
在使用过程中应当保留原作者相关版权
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ZFramework.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Models.Authorization]
    public class UserController : Controller
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询所有角色数据
        /// </summary>
        public ActionResult InquireRole()
        {
            SqlParameter[] sql =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "InquireRole" },
            };
            List<Dictionary<string, object>> ListReturn = Models.StaticData.myDal.QueryList("UserManage", sql);

            return Json(ListReturn, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 查询用户数据
        /// </summary>
        /// <param name="Page">页码</param>
        /// <param name="PageSize">每页数量</param>
        /// <param name="QueryLikeStr">模糊搜索内容</param>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        public ActionResult InquireUserData(string Page, string PageSize, string QueryLikeStr, string BeginDate, string EndDate)
        {
            if (Page == null || PageSize == null || QueryLikeStr == null) { return null; }
            if (Page == "" || PageSize == "") { return null; }

            try
            {
                #region SQL查询方法

                if (BeginDate == "") { BeginDate = null; }
                if (EndDate == "") { EndDate = null; }
                SqlParameter[] sql =
                {
                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireUserData" },
                    new SqlParameter("@Page",SqlDbType.NChar){ Value = Page },
                    new SqlParameter("@PageSize",SqlDbType.NChar){ Value = PageSize },
                    new SqlParameter("@QueryLikeStr",SqlDbType.NChar){ Value = QueryLikeStr },
                    new SqlParameter("@BeginDate",SqlDbType.NChar){ Value = BeginDate },
                    new SqlParameter("@EndDate",SqlDbType.NChar){ Value = EndDate },
                };
                List<Dictionary<string, object>> ListReturn = Models.StaticData.myDal.QueryList("UserManage", sql);
                var total = "0";//获取总数
                if (ListReturn.Count != 0) total = ListReturn[0]["tbCount"].ToString();

                #endregion SQL查询方法

                return Json(new { status = 0, message = "成功", total, rows = ListReturn }, JsonRequestBehavior.DenyGet);
            }
            catch
            {
                return Json(new { status = -1, message = "失败" }, JsonRequestBehavior.DenyGet);
            }
        }

        /// <summary>
        /// 新增用户数据
        /// </summary>
        /// <param name="Accounts">用户账号</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="Password">用户密码</param>
        /// <param name="RoleID">用户角色ID</param>
        /// <param name="Single">单点登录</param>
        /// <returns></returns>
        public ActionResult InsertUserData(string Accounts, string UserName, string Password, string RoleID, string Single)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (Accounts == null || UserName == null || RoleID == null || Single == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            if (Accounts == "" || UserName == "" || RoleID == "" || Single == "") { return Json(returnJson, JsonRequestBehavior.DenyGet); }

            //数据转换
            int single = 0; if (Convert.ToBoolean(Single)) single = 1;

            //把密码加密一遍
            if (Password != "" && Password != null) Password = Common.Tools_MD5.GetMd5(Password);

            #region SQL查询方法

            SqlParameter[] sqlUser =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "InsertUser" },
                new SqlParameter("@Accounts",SqlDbType.NChar){ Value = Accounts },
            };
            int rows = Models.StaticData.myDal.QueryDataTable("UserManage", sqlUser).Rows.Count;

            #endregion SQL查询方法

            //防止添加同样账号的用户
            if (rows > 0)
            {
                returnJson.Message = "存在同样账号的用户";
                return Json(returnJson, JsonRequestBehavior.DenyGet);
            }

            #region SQL操作方法

            SqlParameter[] sql =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "InsertUserData" },
                new SqlParameter("@RoleID",SqlDbType.Int){ Value = RoleID },
                new SqlParameter("@UserName",SqlDbType.NChar){ Value = UserName },
                new SqlParameter("@Accounts",SqlDbType.NChar){ Value = Accounts },
                new SqlParameter("@Password",SqlDbType.NChar){ Value = Password },
                new SqlParameter("@Single",SqlDbType.Int){ Value = single },
            };
            int count = Models.StaticData.myDal.UpdateData("UserManage", sql);

            #endregion SQL操作方法

            if (count > 0)
            {
                returnJson.Message = "新增成功";
                returnJson.Status = true;
            }
            else
            {
                returnJson.Message = "新增失败";
                returnJson.Status = false;
            }
            return Json(returnJson, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="Accounts">用户账号</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="Password">用户密码</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="RoleID">用户角色ID</param>
        /// <param name="Single">单点登录</param>
        /// <returns></returns>
        public ActionResult UpdateUserData(string Accounts, string UserName, string Password, string UserID, string RoleID, string Single)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (Accounts == null || UserName == null || RoleID == null || Single == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            if (Accounts == "" || UserName == "" || RoleID == "" || Single == "") { return Json(returnJson, JsonRequestBehavior.DenyGet); }

            //数据转换
            int single = 0; if (Convert.ToBoolean(Single)) single = 1;

            //把密码加密一遍
            if (Password != "" && Password != null) Password = Common.Tools_MD5.GetMd5(Password);

            #region SQL查询方法

            SqlParameter[] sqlUser =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "InsertUser" },
                new SqlParameter("@Accounts",SqlDbType.NChar){ Value = Accounts },
            };
            DataTable dtUser = Models.StaticData.myDal.QueryDataTable("UserManage", sqlUser);

            #endregion SQL查询方法

            //防止修改成，除了本身的其它同样账号的用户
            if (dtUser.Rows.Count > 0)
            {
                string str = dtUser.Rows[0]["UserID"].ToString();
                if (dtUser.Rows[0]["UserID"].ToString() != UserID)
                {
                    returnJson.Message = "存在同样账号的用户";
                    return Json(returnJson, JsonRequestBehavior.DenyGet);
                }
            }

            #region SQL操作方法

            SqlParameter[] sql =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "UpdateUserData" },
                new SqlParameter("@UserID",SqlDbType.Int){ Value = UserID },
                new SqlParameter("@RoleID",SqlDbType.Int){ Value = RoleID },
                new SqlParameter("@UserName",SqlDbType.NChar){ Value = UserName },
                new SqlParameter("@Accounts",SqlDbType.NChar){ Value = Accounts },
                new SqlParameter("@Password",SqlDbType.NChar){ Value = Password },
                new SqlParameter("@Single",SqlDbType.Int){ Value = single },
            };
            int count = Models.StaticData.myDal.UpdateData("UserManage", sql);

            #endregion SQL操作方法

            if (count > 0)
            {
                returnJson.Message = "修改成功";
                returnJson.Status = true;
            }
            else
            {
                returnJson.Message = "修改失败";
                returnJson.Status = false;
            }
            return Json(returnJson, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 删除用户数据
        /// </summary>
        /// <param name="IDS">ID集合</param>
        /// <returns></returns>
        public ActionResult DeleteUserData(string IDS)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (IDS == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            if (IDS == "") { return Json(returnJson, JsonRequestBehavior.DenyGet); }

            int DelectCount = 0;//统计删除的数量
            string[] IDs = IDS.Split(',');

            foreach (var id in IDs)
            {
                #region SQL操作方法

                SqlParameter[] sql =
                {
                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "DeleteUserData" },
                    new SqlParameter("@UserID",SqlDbType.NChar){ Value = id },
                };
                DelectCount += Models.StaticData.myDal.UpdateData("UserManage", sql);

                #endregion SQL操作方法
            }

            if (DelectCount > 0)
            {
                returnJson.Message = "删除成功";
                returnJson.Status = true;
            }
            else
            {
                returnJson.Message = "删除失败";
                returnJson.Status = false;
            }

            return Json(returnJson, JsonRequestBehavior.DenyGet);
        }
    }
}