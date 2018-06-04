using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cn.itcast.bookshop.Common;
namespace WebApplication1
{
    public partial class ImageUpLoadTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) {

                GeneratingSmallerPicture draw = new GeneratingSmallerPicture();
              HttpPostedFile file=  Request.Files["Filedata"];
                file.SaveAs(Request.MapPath("/upload/" + file.FileName));
                string path;
                draw.MakeThumbnail(Request.MapPath("/upload/" + file.FileName), Request.MapPath("/upload/thumb/" + file.FileName), 300,0, "W", out path);



            }
        }
    }
}