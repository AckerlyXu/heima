using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;
using System.Collections;

namespace WebApplication1.ashx
{
    /// <summary>
    /// bookcomment 的摘要说明
    /// </summary>
    public class bookcomment : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
        b.BookComment bll = new b.BookComment();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = context.Request["msg"];
            int bookid;
           
           bool result= int.TryParse( context.Request["bookid"],out bookid);
            
            if (msg == null)
            {
                if (!result) {
                    System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    m.Users user=context.Session["user"] as m.Users;
                    if (context.Session["user"] == null)
                    {
                        if (context.Request["username"] != null)
                        {
                            b.Users bll = new b.Users();
                            m.Users baseUser = bll.GetUserByName(context.Request["username"]);
                            if (baseUser.LoginPwd == context.Request["password"])
                            {


                                context.Response.Write(javaScriptSerializer.Serialize(baseUser));
                                context.Response.End();
                            }

                        }
                        context.Response.Write(javaScriptSerializer.Serialize(new { Msg = "no" }));
                        context.Response.End();
                    }
                    else {
                        context.Response.Write(javaScriptSerializer.Serialize(user));

                    }
                    
                }
                else
                {
                    context.Response.Write(LoadCommnet(bookid));

                }
               

            }
            else  {

                context.Response.Write(AddComment(bookid,msg));

            }
           
        }

        public string LoadCommnet(int bookid) {

           List<m.BookComment> list= bll.GetModelList("bookid=" + bookid);
            ArrayList list1 = new ArrayList();
            foreach (var item in list)
            {
                list1.Add(new { item.Msg, CreateDateTime = GetTime(DateTime.Now - item.CreateDateTime) });
            }
            System.Web.Script.Serialization.JavaScriptSerializer javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return javaScriptSerializer.Serialize(list1);

        }
        public int AddComment(int bookid,string msg) {
           return  bll.Add(new m.BookComment() { BookId = bookid, Msg = msg, CreateDateTime = DateTime.Now });

        }
        public string GetTime(TimeSpan span) {
            string str="";
            int year = span.Days / 365;
            int month = span.Days % 365/30;
            int day = span.Days % 30;
            int hour = span.Hours % 24;
            int minute = span.Minutes % 60;
            int second = span.Seconds % 60;
            if (year > 0) {
                str += year + "年";
            }
            if (month > 0) {
                str += month + "月";
            }
            if (day > 0) {
                str += day + "天";
            }
            if (hour > 0)
            {

                str += hour + "小时";
            }
            if (minute > 0) {
                str += minute + "分钟";
            }
            if (second > 0) {
                str += second + "秒";
            }
            else {
                return "刚刚";
            }
            return str + "前";

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