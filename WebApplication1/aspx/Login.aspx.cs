using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;
using c=cn.itcast.bookshop.Common;

namespace WebApplication1.aspx
{
  
    public partial class Login : System.Web.UI.Page
    {
        public string Msg { get; set; }
        public string url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            url = Request["returnurl"];
            
           Response.ContentType = "text/html;charset=utf-8";
            if (Request.HttpMethod.ToLower() == "post") {

                string username = Request["username"];
                string password = Request["password"];
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {

                    b.Users usersBll = new b.Users();
                    m.Users user = usersBll.GetUserByName(username);
                    if (user != null)
                    {

                        if (c.Md5Util.GetMd5(password) == user.LoginPwd)
                        {

                            Session["user"] = user;
                            if (!string.IsNullOrEmpty(Request["autoLogin"])) {

                                HttpCookie cName = new HttpCookie("username");
                                HttpCookie cPwd = new HttpCookie("password");
                                cName.Value = user.LoginId;
                                cPwd.Value = user.LoginPwd;
                                cName.Expires = DateTime.Now.AddDays(7);
                                cPwd.Expires = DateTime.Now.AddDays(7);
                                Response.SetCookie(cName);
                                Response.SetCookie(cPwd);


                            }
                            if (url != null) {
                                Response.Redirect(url);

                            }
                            


                        }

                    }
                    else {

                        Msg = "用户名或密码错误";
                    }

                }
                else { Msg = "用户名或密码不能为空"; }
               
                

            }

        }
    }
}