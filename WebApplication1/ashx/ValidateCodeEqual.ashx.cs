using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ashx
{
    /// <summary>
    /// ValidateCodeEqual 的摘要说明
    /// </summary>
    public class ValidateCodeEqual : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
           context.Response.ContentType = "text/plain";

            if ((string)context.Session["validate"] == context.Request["validate"])
            {


                context.Response.Write("yes");
            }
            else {

                context.Response.Write("no");
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