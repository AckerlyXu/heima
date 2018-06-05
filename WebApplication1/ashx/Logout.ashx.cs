using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ashx
{
    /// <summary>
    /// Logout 的摘要说明
    /// </summary>
    public class Logout : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session["user"] = null;
            context.Request.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            context.Request.Cookies["password"].Expires = DateTime.Now.AddDays(-1);
            context.Response.SetCookie(context.Request.Cookies["username"]);
         //   context.Response.Cookies["username"].Expires=DateTime.Now.AddDays(-1) 也可以这样，比较简便+++++
            context.Response.SetCookie(context.Request.Cookies["password"]);
            context.Response.Write("yes");
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