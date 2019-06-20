using System.Net;
using System.Net.Mail;

namespace ZFramework.Common
{
    /// <summary>
    /// 邮箱工具类
    /// </summary>
    public class Tools_Mail
    {
        private string _host;//服务器地址
        private int _port = 25;//服务器端口
        private string _user;//发送者邮箱账号
        private string _password;//发送者邮箱密码

        /// <summary>
        /// 发送邮件基本数据
        /// </summary>
        /// <param name="host">服务器地址</param>
        /// <param name="port">服务器端口</param>
        /// <param name="user">发送者邮箱账号</param>
        /// <param name="password">发送者邮箱密码</param>
        public Tools_Mail(string host, int port, string user, string password)
        {
            _host = host;
            _port = port;
            _user = user;
            _password = password;
        }

        /// <summary>
        /// 发送邮件基本数据
        /// </summary>
        /// <param name="host">服务器地址</param>
        /// <param name="user">发送者邮箱账号</param>
        /// <param name="password">发送者邮箱密码</param>
        public Tools_Mail(string host, string user, string password)
        {
            _host = host;
            _user = user;
            _password = password;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">接收者账号</param>
        /// <param name="title">标题</param>
        /// <param name="body">内容</param>
        public void Send(string to, string title, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_user);//设置发件人
            message.To.Add(to);//设置收件人
            message.Subject = title;//设置邮件标题
            message.Body = body;//设置邮件内容

            SmtpClient client = new SmtpClient(_host, _port);//设置邮件发送服务器
            client.UseDefaultCredentials = false;//默认凭证
            client.EnableSsl = true;//SSL状态
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//设置邮件发送方式
            client.Credentials = new NetworkCredential(_user, _password);//设置发送人的邮箱账号和密码
            client.Send(message);//发送邮件
        }
    }
}