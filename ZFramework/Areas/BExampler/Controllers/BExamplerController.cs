using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZFramework.Areas.BExampler.Controllers
{
    /// <summary>
    /// 示例表控制器
    /// </summary>
    [Models.Authorization]
    public class BExamplerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="Page">页码</param>
        /// <param name="PageSize">每页数量</param>
        /// <param name="QueryLikeStr">模糊搜索内容</param>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        public ActionResult InquireData(string Page, string PageSize, string QueryLikeStr, string BeginDate, string EndDate)
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
                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "InquireData" },
                    new SqlParameter("@Page",SqlDbType.NChar){ Value = Page },
                    new SqlParameter("@PageSize",SqlDbType.NChar){ Value = PageSize },
                    new SqlParameter("@QueryLikeStr",SqlDbType.NChar){ Value = QueryLikeStr },
                    new SqlParameter("@BeginDate",SqlDbType.NChar){ Value = BeginDate },
                    new SqlParameter("@EndDate",SqlDbType.NChar){ Value = EndDate },
                };
                List<Dictionary<string, object>> ListReturn = Models.StaticData.myDal.QueryList("BExamplerManage", sql);
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
        /// 新增数据
        /// </summary>
        /// <param name="ExamplerName">示例名称</param>
        /// <param name="Remark">备注</param>
        /// <returns></returns>
        public ActionResult InsertData(string ExamplerName, string Remark)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (ExamplerName == null || Remark == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            if (ExamplerName == "" || Remark == "") { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            
            #region SQL操作方法

            SqlParameter[] sql =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "InsertData" },
                new SqlParameter("@ExamplerName",SqlDbType.NChar){ Value = ExamplerName },
                new SqlParameter("@Remark",SqlDbType.NChar){ Value = Remark },
            };
            int count = Models.StaticData.myDal.UpdateData("BExamplerManage", sql);

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
        /// 修改数据
        /// </summary>
        /// <param name="ExamplerID">示例ID</param>
        /// <param name="ExamplerName">示例名称</param>
        /// <param name="Remark">备注</param>
        /// <returns></returns>
        public ActionResult UpdateData(string ExamplerID, string ExamplerName, string Remark)
        {
            Models.ReturnJson returnJson = new Models.ReturnJson();
            returnJson.Message = "信息错误";
            returnJson.Status = false;

            if (ExamplerID == null || ExamplerName == null || Remark == null) { return Json(returnJson, JsonRequestBehavior.DenyGet); }
            if (ExamplerID == "" || ExamplerName == "" || Remark == "") { return Json(returnJson, JsonRequestBehavior.DenyGet); }

            #region SQL操作方法

            SqlParameter[] sql =
            {
                new SqlParameter("Type",SqlDbType.NChar){ Value = "UpdateData" },
                new SqlParameter("@ExamplerID",SqlDbType.NChar){ Value = ExamplerID },
                new SqlParameter("@ExamplerName",SqlDbType.NChar){ Value = ExamplerName },
                new SqlParameter("@Remark",SqlDbType.NChar){ Value = Remark },
            };
            int count = Models.StaticData.myDal.UpdateData("BExamplerManage", sql);

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
        /// 删除数据
        /// </summary>
        /// <param name="IDS">ID集合</param>
        /// <returns></returns>
        public ActionResult DeleteData(string IDS)
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
                    new SqlParameter("@Type",SqlDbType.NChar){ Value = "DeleteData" },
                    new SqlParameter("@ExamplerID",SqlDbType.NChar){ Value = id },
                };
                DelectCount += Models.StaticData.myDal.UpdateData("BExamplerManage", sql);

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