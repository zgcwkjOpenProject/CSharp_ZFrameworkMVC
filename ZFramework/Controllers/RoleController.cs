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
    /// 角色管理
    /// </summary>
    [Models.Authorization]
    public class RoleController : Controller
    {
        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询角色数据
        /// </summary>
        /// <param name="Page">页码</param>
        /// <param name="PageSize">每页数量</param>
        /// <param name="QueryLikeStr">模糊搜索内容</param>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
        public ActionResult InquireRoleData(string Page, string PageSize, string QueryLikeStr, string BeginDate, string EndDate)
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
                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireRoleData" },
                    new SqlParameter("@Page",SqlDbType.NChar){ Value = Page },
                    new SqlParameter("@PageSize",SqlDbType.NChar){ Value = PageSize },
                    new SqlParameter("@QueryLikeStr",SqlDbType.NChar){ Value = QueryLikeStr },
                    new SqlParameter("@BeginDate",SqlDbType.NChar){ Value = BeginDate },
                    new SqlParameter("@EndDate",SqlDbType.NChar){ Value = EndDate },
                };
                List<Dictionary<string, object>> ListReturn = Models.StaticData.myDal.QueryList("RoleManage", sql);
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
        /// 新增角色数据
        /// </summary>
        /// <param name="RoleName">角色名称</param>
        /// <returns></returns>
        public ActionResult InsertRoleData(string RoleName)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (RoleName == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            if (RoleName == "") { return Json(returnJson, JsonRequestBehavior.DenyGet); }

            #region SQL操作方法

            SqlParameter[] sql =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "InsertRoleData" },
                new SqlParameter("@RoleName",SqlDbType.NChar){ Value = RoleName },
            };
            int count = Models.StaticData.myDal.UpdateData("RoleManage", sql);

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
        /// 修改角色数据
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <param name="RoleName">角色名称</param>
        /// <returns></returns>
        public ActionResult UpdateRoleData(string RoleID, string RoleName)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (RoleName == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            if (RoleName == "") { return Json(returnJson, JsonRequestBehavior.DenyGet); }

            #region SQL操作方法

            SqlParameter[] sql =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "UpdateRoleData" },
                new SqlParameter("@RoleID",SqlDbType.Int){ Value = RoleID },
                new SqlParameter("@RoleName",SqlDbType.NChar){ Value = RoleName },
            };
            int count = Models.StaticData.myDal.UpdateData("RoleManage", sql);

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
        /// 删除角色数据
        /// </summary>
        /// <param name="IDS">ID集合</param>
        /// <returns></returns>
        public ActionResult DeleteRoleData(string IDS)
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
                #region SQL操作方法 删除角色数据

                SqlParameter[] sqlDeleteRoleData =
                {
                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "DeleteRoleData" },
                    new SqlParameter("@RoleID",SqlDbType.NChar){ Value = id },
                };
                DelectCount += Models.StaticData.myDal.UpdateData("RoleManage", sqlDeleteRoleData);

                #endregion SQL操作方法 删除角色数据

                #region SQL操作方法 删除角色明细数据

                SqlParameter[] sqlDeleteRoleDetailData =
                {
                    new SqlParameter("Type",SqlDbType.NChar){ Value = "DeleteRoleDetailData" },
                    new SqlParameter("@RoleID",SqlDbType.Int){ Value = id },
                };
                DelectCount += Models.StaticData.myDal.UpdateData("RoleManage", sqlDeleteRoleDetailData);

                #endregion SQL操作方法 删除角色明细数据
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

        /// <summary>
        /// 查询角色明细管理
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <returns></returns>
        public ActionResult InquireRoleDetail(string RoleID)
        {
            if (RoleID == null) { return null; }
            if (RoleID == "") { return null; }

            #region SQL查询方法

            //查询所有菜单的行为数据
            SqlParameter[] sqlMenuBehavior =
            {
                new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireMenuBehaviorData" }
            };
            DataTable dtMenuBehavior = Models.StaticData.myDal.QueryDataTable("RoleManage", sqlMenuBehavior);

            //查询当前角色明细数据
            SqlParameter[] sqlRoleDetail =
            {
                new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireRoleDetailData" },
                new SqlParameter("@RoleID",SqlDbType.Int){ Value = RoleID }
            };
            DataTable dtRoleDetail = Models.StaticData.myDal.QueryDataTable("RoleManage", sqlRoleDetail);

            #endregion SQL查询方法

            string _html = "";

            #region 生成功能权限可操作的模块

            _html += "<div class='table-responsive'>";
            _html += "<table class='table table-bordered table-hover table-success'>";
            _html += "<thead class='thead-default'>";
            _html += "<tr>";
            _html += "<th>功能名称</th>";
            _html += "<th>权限操作</th>";
            _html += "</tr>";
            _html += "</thead>";
            _html += "<tbody>";
            foreach (DataRow drMB in dtMenuBehavior.Rows)
            {
                string MenuID = drMB["MenuID"].ToString();//菜单ID
                string Title = drMB["Title"].ToString();//菜单名称
                string Behavio = drMB["Behavior"].ToString();//菜单权限

                string toBehavio = "";//该菜单当前拥有权限
                foreach (DataRow drRD in dtRoleDetail.Rows)
                {
                    if (drMB["MenuID"].ToString() == drRD["MenuID"].ToString()) toBehavio = drRD["Behavior"].ToString();
                }

                _html += "<tr>";
                _html += "<td>" + Title + "</td>";
                _html += "<td>";
                string[] behavios = Behavio.Split(',');//把菜单权限拆分为数组
                foreach (string behavio in behavios)
                {
                    string checkbox = "";//该菜单的权限是否被选中
                    if (toBehavio.Contains(behavio)) checkbox = "checked";

                    _html += "<label class='zg-check'><input type='checkbox' name='" + behavio + "-zf-" + MenuID + "' " + checkbox + "><i></i>" + behavio + "</label>";
                    _html += " ";
                }
                _html += "</td>";
                _html += "</tr>";
            }
            _html += "</tbody>";
            _html += "</table>";
            _html += "</div>";

            #endregion 生成功能权限可操作的模块

            return Json(_html, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// 更新角色明细数据
        /// </summary>
        /// <param name="RoleID">角色ID</param>
        /// <param name="Behavior">修改的内容</param>
        /// <returns></returns>
        public ActionResult UpdateRoleDetailData(string RoleID, Dictionary<string, bool> Behavior)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            int updateCount = 0;//统计更新的数量

            #region SQL操作方法 删除角色明细数据

            SqlParameter[] sqlDeleteRoleDetailData =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "DeleteRoleDetailData" },
                new SqlParameter("@RoleID",SqlDbType.Int){ Value = RoleID },
            };
            Models.StaticData.myDal.UpdateData("RoleManage", sqlDeleteRoleDetailData);

            #endregion SQL操作方法 删除角色明细数据

            #region SQL操作方法 新增角色明细数据

            Dictionary<int, string> behaviors = new Dictionary<int, string>();

            foreach (var behavior in Behavior)
            {
                string[] keys = behavior.Key.Replace("-zf-", "^").Split('^');
                string behavio = keys[0];
                int menuID = Convert.ToInt32(keys[1]);
                bool value = behavior.Value;
                if (value)
                {
                    try { behaviors[menuID] += "," + behavio; }
                    catch { behaviors.Add(menuID, behavio); }
                }
            }

            foreach (var behavior in behaviors)
            {
                SqlParameter[] sqlInsertRoleDetailData =
                {
                    new SqlParameter("Type", SqlDbType.NChar) { Value = "InsertRoleDetailData" },
                    new SqlParameter("@RoleID", SqlDbType.Int) { Value = RoleID },
                    new SqlParameter("@MenuID", SqlDbType.Int) { Value = behavior.Key },
                    new SqlParameter("@Behavior", SqlDbType.NChar) { Value = behavior.Value },
                };
                updateCount = Models.StaticData.myDal.UpdateData("RoleManage", sqlInsertRoleDetailData);
            }

            #endregion SQL操作方法 新增角色明细数据

            if (updateCount > 0)
            {
                returnJson.Message = "角色权限调整成功";
                returnJson.Status = true;
            }
            else
            {
                returnJson.Message = "角色权限调整失败";
                returnJson.Status = false;
            }

            return Json(returnJson, JsonRequestBehavior.DenyGet);
        }
    }
}