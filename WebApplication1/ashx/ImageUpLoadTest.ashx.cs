using cn.itcast.bookshop.Common;
using System;
using System.Collections.Generic;
using System.IO;
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





           
            HttpPostedFile file = context.Request.Files["Filedata"];
            if (Path.GetExtension(file.FileName) == ".jpg") {
                file.SaveAs(context.Request.MapPath("/upload/" + file.FileName));
                GeneratingSmallerPicture draw = new GeneratingSmallerPicture();

                string path;
                
                draw.MakeThumbnail(context.Request.MapPath("/upload/" + file.FileName), context.Request.MapPath("/upload/thumb/" + Guid.NewGuid().ToString()+".jpg"), 500, 400, "Cut", out path);
                File.Delete(context.Request.MapPath("/upload/" + file.FileName));
                context.Response.StatusCode = 200;
               
                context.Response.Write(path);
            }
            else {
                context.Response.StatusCode = 200;
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