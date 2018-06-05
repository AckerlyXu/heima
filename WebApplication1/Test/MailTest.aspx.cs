using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
namespace WebApplication1.Test
{
    public partial class MailTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("1290272597@qq.com", "乱码");
            message.To.Add(new MailAddress("1290272597@qq.com", "乱码"));
            message.IsBodyHtml = true;
            message.Subject = "test";
            message.Body = "<h1>this is  a test mail</h1>";
            //实例化client有一个无参数的，要使用有参数的设置协议。
            SmtpClient client = new SmtpClient("smtp.qq.com");
            //一定要先设置EnableSsl和UseDefaultCredentials再实例化Credentials+++++
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            //认证使用的是授权码而不是QQ密码+++++
            client.Credentials = new System.Net.NetworkCredential("1290272597@qq.com", "batyzrzknvruhdbg");
            client.Send(message);
        }
    }
}