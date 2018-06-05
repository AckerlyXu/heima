using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using m=cn.itcast.bookshop.Model;
using b= cn.itcast.bookshop.BLL;
using cn.itcast.bookshop.Common;
namespace WebApplication1
{
    public partial class Account : System.Web.UI.Page
    {
        protected string url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                url = Request["returnurl"];

            }
            if (IsPostBack) {
                string txtName = Request["txtName"];
                string txtRealName = Request["txtRealName"];
                string txtPwd = Request["txtRealName"];
                url = Request["returnurl"];
                string txtCode = Request["txtCode"];
                m.Users users = new m.Users();
                b.Users bll = new b.Users();
                int count = 0;
                if (bll.GetCountByName(txtName) != 0) {

                    count++;

                }
                if (txtCode != (string)Session["validate"]) {

                    Session["validate"] = null;
                    count++;
                }
                if (String.IsNullOrEmpty(txtPwd)) {
                    count++;

                }
                if (count == 0) {

                    users.LoginId = txtName;
                    users.Name = txtRealName;
                    users.LoginPwd = Md5Util.GetMd5(txtPwd);
                    users.UserStateId = 1;
                    bll.Add(users);
                    Session["user"] = users;
                    if (url != null) {
                        Response.Redirect(url);
                    }
                    Response.Redirect("default.aspx");

                }


            }

        }
    }
}