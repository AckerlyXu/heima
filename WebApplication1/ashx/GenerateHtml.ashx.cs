using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using m = cn.itcast.bookshop.Model;
using b = cn.itcast.bookshop.BLL;
using System.IO;

namespace WebApplication1.ashx
{
    /// <summary>
    /// GenerateHtml 的摘要说明
    /// </summary>
    public class GenerateHtml : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            b.Books bll = new b.Books();
           List<m.Books> list=bll.GetModelList("");
            foreach (var item in list)
            {
                GenerateHtmlPage(item.Id);
            }
            context.Response.Write("ok");
        }

        private void GenerateHtmlPage(int id) {
            b.Books bll = new b.Books();
            m.Books model=bll.GetModel(id);
            string path=HttpContext.Current.Request.MapPath("/Template/BookTemplate.html");

            string content=File.ReadAllText(path);
            string dir = HttpContext.Current.Request.MapPath("/" );
            if (!Directory.Exists(dir+ "BookDetails" + "\\" + model.PublishDate.Year + "\\" + model.PublishDate.Month + "\\" + model.PublishDate.Date)) {
                Directory.CreateDirectory(dir  + "BookDetails"+"/" + model.PublishDate.Year + "/" + model.PublishDate.Month + "/" + model.PublishDate.Day);
            }
            string html = content.Replace("$title", model.Title).Replace("$id", model.Id.ToString()).Replace("$unitPrice", model.UnitPrice.ToString("0.00"))
                .Replace("$isbn", model.ISBN).Replace("$toc", model.TOC).Replace("$content", model.ContentDescription).Replace("$authorDesc", model.AurhorDescription).Replace("author", model.Author)
                .Replace("$wordCount", model.WordsCount.ToString()).Replace("$publishDate", model.PublishDate.ToShortDateString()).Replace("$bookid",model.Id.ToString());
            File.WriteAllText(dir + "BookDetails" + "/" + model.PublishDate.Year + "/" + model.PublishDate.Month + "/" + model.PublishDate.Day + "/" + model.Id + ".html",html);

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