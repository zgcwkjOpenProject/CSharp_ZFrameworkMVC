using System;
using System.Web;

namespace ZFramework.Common
{
    public static class Tools_Cookie
    {
        /// <summary>
        /// 读取 Cookie
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="cookieKey">键</param>
        /// <returns></returns>
        public static string Read(string cookieName, string cookieKey)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null && cookie[cookieKey] != null)
            {
                return HttpContext.Current.Server.UrlDecode(cookie[cookieKey]);
            }
            return "";
        }

        /// <summary>
        /// 写入 Cookie
        /// </summary>
        /// <param name="Response">响应</param>
        /// <param name="cookieName">名称</param>
        /// <param name="cookieKey">键</param>
        /// <param name="cookieValue">值</param>
        /// <param name="cookieDay">有效时长，单位天</param>
        /// <returns></returns>
        public static void Write(string cookieName, string cookieKey, string cookieValue, int cookieDay = 3)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie[cookieKey] = cookieValue;
            cookie.Expires = DateTime.Now.AddDays(cookieDay);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}