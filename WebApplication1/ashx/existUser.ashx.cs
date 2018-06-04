using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using m = cn.itcast.bookshop.Model;
using b= cn.itcast.bookshop.BLL;
namespace WebApplication1.ashx
{
    /// <summary>
    /// existUser 的摘要说明
    /// </summary>
    public class existUser : IHttpHandler
    {
        private b.Users users = new b.Users();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string username=context.Request["username"];
           int count= users.GetCountByName(username);
            if (count == 1)
            {

                context.Response.Write("no");
            }
            else {
                context.Response.Write("yes");

            }
           
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