using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;

namespace WebApplication1.ashx
{
    /// <summary>
    /// bookcomment 的摘要说明
    /// </summary>
    public class bookcomment : IHttpHandler
    {
        b.BookComment bll = new b.BookComment();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = context.Request["msg"];
            int bookid =int.Parse( context.Request["bookid"]);
            if (msg == null)
            {

                context.Response.Write(LoadCommnet(bookid));

            }
            else {

                context.Response.Write(AddComment(bookid,msg));

            }
           
        }

        public string LoadCommnet(int bookid) {

           List<m.BookComment> list= bll.GetModelList("bookid=" + bookid);
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return javaScriptSerializer.Serialize(list);

        }
        public int AddComment(int bookid,string msg) {
           return  bll.Add(new m.BookComment() { BookId = bookid, Msg = msg, CreateDateTime = DateTime.Now });

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