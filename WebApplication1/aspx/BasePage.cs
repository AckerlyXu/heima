using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;

namespace WebApplication1.aspx
{
    public class BasePage : System.Web.UI.Page
    {


        protected void Page_Init(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {

                if (Request.Cookies["username"] != null)
                {
                    b.Users userBll = new b.Users();
                   m.Users user= userBll.GetUserByName(Request.Cookies["username"].Value);
                    if (user.LoginPwd == Request.Cookies["password"].Value) {

                        Session["user"] = user;

                    }
                    else
                    {

                        Response.Redirect("/aspx/Login.aspx?returnurl="+Request.Url.ToString());

                    }


                }
                else
                {

                    Response.Redirect("/aspx/Login.aspx?returnurl=" + Request.Url.ToString());

                }


            }
           

        }
    }
}