
using cn.itcast.bookshop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// CheckMail 的摘要说明
    /// </summary>
    public class CheckMail : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            b.Users bll = new b.Users();
            string address = context.Request["address"];
            m.Users user = bll.GetUserByMail(address);
            if (user != null)
            {

                string password = Guid.NewGuid().ToString().Substring(0, 8);
                SendMail(address, user.LoginId, "bookshop3密码修改", "您的新密码是" + password);
                user.LoginPwd = Md5Util.GetMd5(password);
                bll.Update(user);
                context.Response.Write("yes");

            }
            else
            {
                context.Response.Write("no");

            }

        }

        public void SendMail(string mail, string username, string subject, string body)
        {


            MailMessage message = new MailMessage();
            b.SettingsBll bll = new b.SettingsBll();
            string adminaddress = bll.GetValue("系统邮件地址");
            string adminname = bll.GetValue("系统邮件用户名");
            message.From = new MailAddress(adminaddress, adminname);
            message.To.Add(new MailAddress(mail, username));
            message.IsBodyHtml = true;
            message.Subject = subject;
            message.Body = body;
            //实例化client有一个无参数的，要使用有参数的设置协议。
            SmtpClient client = new SmtpClient(bll.GetValue("系统邮件SMTP"));
            //一定要先设置EnableSsl和UseDefaultCredentials再实例化Credentials+++++
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            //认证使用的是授权码而不是QQ密码+++++
            client.Credentials = new System.Net.NetworkCredential(adminaddress, bll.GetValue("系统邮件密码"));
            client.Send(message);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}