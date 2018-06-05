using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] != null)
            {
                b.Users userBll = new b.Users();
                m.Users user = userBll.GetUserByName(Request.Cookies["username"].Value);
                if (user.LoginPwd == Request.Cookies["password"].Value)
                {

                    Session["user"] = user;

                }
            }

        }
    }
}