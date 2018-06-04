using cn.itcast.bookshop.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.aspx
{
    public partial class ImageUpload :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                if (Context.Request["action"] == null)  //上传初始图片
                {

                    GeneratingSmallerPicture draw = new GeneratingSmallerPicture();
                    HttpPostedFile file = Request.Files["Filedata"];
                    if (Path.GetExtension(file.FileName) == ".jpg")
                    {

                        try
                        {
                            file.SaveAs(Request.MapPath("/upload/" + file.FileName));
                            string path;
                            string gid = Guid.NewGuid().ToString();
                            draw.MakeThumbnail(Request.MapPath("/upload/" + file.FileName), Request.MapPath("/upload/thumb/" + gid + ".jpg"), 500, 300, "Cut", out path);
                            File.Delete(Request.MapPath("/upload/" + file.FileName));
                            Context.Response.Write("/upload/thumb" + gid + ".jpg");

                        }
                        catch (Exception)
                        {
                            Context.Response.Write("no");

                            throw;
                        }


                    }
                    else   
                    {

                        Context.Response.Write("no");

                    }




                }
                else
                {//裁剪图片

                    try
                    {
                        int x = int.Parse(Context.Request["x"]);
                        int y = int.Parse(Context.Request["y"]);
                        int w = int.Parse(Context.Request["w"]);
                        int h = int.Parse(Context.Request["h"]);
                        string url = Context.Request["url"];
                        using (Bitmap map = new Bitmap(w, h))
                        {
                            Graphics g = Graphics.FromImage(map);
                            using (System.Drawing.Image img = System.Drawing.Image.FromFile(url))
                            {
                                g.DrawImage(img, new Rectangle(0, 0, w, h), new Rectangle(x, y, w, h), GraphicsUnit.Pixel);
                                string fileName = Guid.NewGuid().ToString() + ".jpg";
                                map.Save(Context.Request.MapPath("/upload/thubm/") + fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                //File.Delete(Context.Request.MapPath(url));
                                Response.Write("/upload/thubm/" + fileName);
                            }

                        }

                    }
                    catch (Exception)
                    {
                        Response.Write("no");
                        throw;
                    }
                  



                }

            }

        }
    }
}