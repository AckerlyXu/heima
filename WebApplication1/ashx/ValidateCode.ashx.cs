using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using c=cn.itcast.bookshop.Common;

namespace WebApplication1.ashx
{
    /// <summary>
    /// ValidateCode 的摘要说明
    /// </summary>
    public class ValidateCode : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpeg";
            c.ValidateCode validateCode = new c.ValidateCode();
            string code=validateCode.CreateValidateCode(4);
            MemoryStream stream = validateCode.CreateValidateGraphic(code);
            context.Session["validate"] = code;
            context.Response.BinaryWrite(stream.ToArray());
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