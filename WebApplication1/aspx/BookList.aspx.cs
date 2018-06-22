using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;
using c = cn.itcast.bookshop.Common;

namespace WebApplication1.aspx
{
    public partial class BookList : System.Web.UI.Page
    {
        protected m.PageModel Model;
        protected void Page_Load(object sender, EventArgs e)
        {
       Response.ContentType = "text/html;charset=utf-8";
            b.Books bll = new b.Books();
            int currentPage = int.Parse((Request["currentPage"] ?? "1"));
            int pageSize = int.Parse(Request["pageSize"]??"5");

            Model = new m.PageModel();
          Model.CurrentPage = currentPage;
            Model.PageSize = pageSize;
            bll.GetPageModel(Model);
            
        }

        public string GetSuitableLength(string content, int length) {

            if (content.Length > 150) {

                return content.Substring(0, 150) + "......";
            }

            return content;

        }
    }
}