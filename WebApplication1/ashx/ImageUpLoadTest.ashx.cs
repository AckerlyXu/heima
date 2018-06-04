using cn.itcast.bookshop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ashx
{
    /// <summary>
    /// ImageUpLoadTest 的摘要说明
    /// </summary>
    public class ImageUpLoadTest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {



            GeneratingSmallerPicture draw = new GeneratingSmallerPicture();
            HttpPostedFile file = context.Request.Files["Filedata"];
            file.SaveAs(context.Request.MapPath("/upload/" + file.FileName));
            string path;
            draw.MakeThumbnail(context.Request.MapPath("/upload/" + file.FileName), context.Request.MapPath("/upload/thumb/" + file.FileName), 300, 0, "W", out path);
            context.Response.StatusCode = 200;
           context.Response.Write("ok");
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