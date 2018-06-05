using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_BeginRequest(Object sender, EventArgs e) {
            //获得请求网页的相对路径，但是前面会加一个波浪线~   ++++++++++++++++
            string url = Request.AppRelativeCurrentExecutionFilePath;
            //书写正则表达式匹配url            ++++++++++++++++
            Regex reg = new Regex(@"~/aspx/BookDetails_(\d+).aspx");
            //运用match方法判断是否匹配             +++++++++++++++
            Match match = reg.Match(url);
            if (match.Success) {
                //匹配成功后，从match对象中获取正则中用括号括起来的对象的值，但是索引是从1开始，0默认是整个字符串。 ++++++++++++++
                Context.RewritePath("/aspx/BookDetails.aspx?id=" + match.Groups[1].Value);

            }

        }
    }
}