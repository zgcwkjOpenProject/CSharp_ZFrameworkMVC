/*
代码生成器 V 1.9.0.3 zgcwkj
生成时间：2019年03月02日
在使用过程中应当保留原作者相关版权
*/
using System;
using System.Text;

namespace ZFramework.Common
{
    /// <summary>
    /// Base64加密解密工具
    /// </summary>
    public static class Tools_Base64
    {
        /// <summary>
        /// 解码Base64
        /// </summary>
        public static string DecodeBase64(string val)
        {
            return Encoding.UTF8.GetString(DecodeBase64ToBytes(val));
        }
        /// <summary>
        /// 编码Base64
        /// </summary>
        public static string EncodeBase64(string val)
        {
            return Encoding.UTF8.GetString(DecodeUrlSafeBase64ToBytes(val));
        }

        /// <summary>
        /// 解码Base64到二进制
        /// </summary>
        public static byte[] DecodeBase64ToBytes(string val)
        {
            var data = val.PadRight(val.Length + (4 - val.Length % 4) % 4, '=');
            return Convert.FromBase64String(data);
        }

        /// <summary>
        /// 编码Url Safe Base64
        /// </summary>
        public static string EncodeUrlSafeBase64(byte[] val, bool trim)
        {
            if (trim)
                return Convert.ToBase64String(val).Replace('+', '-').Replace('/', '_').TrimEnd('=');
            else
                return Convert.ToBase64String(val).Replace('+', '-').Replace('/', '_');
        }

        /// <summary>
        /// 解码Url Safe Base64
        /// </summary>
        public static byte[] DecodeUrlSafeBase64ToBytes(string val)
        {
            var data = val.Replace('-', '+').Replace('_', '/').PadRight(val.Length + (4 - val.Length % 4) % 4, '=');
            return Convert.FromBase64String(data);
        }

        /// <summary>
        /// 编码Url Safe Base64
        /// </summary>
        public static string EncodeUrlSafeBase64(string val, bool trim = true)
        {
            return EncodeUrlSafeBase64(Encoding.UTF8.GetBytes(val), trim);
        }

        /// <summary>
        /// 解码Url Safe Base64
        /// </summary>
        public static string DecodeUrlSafeBase64(string val)
        {
            return Encoding.UTF8.GetString(DecodeUrlSafeBase64ToBytes(val));
        }
    }
}