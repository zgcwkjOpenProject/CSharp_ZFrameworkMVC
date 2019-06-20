namespace ZFramework.Models
{
    /// <summary>
    /// 返回JSON数据
    /// </summary>
    public class ReturnJson
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
    }
}