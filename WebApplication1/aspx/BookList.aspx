<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="WebApplication1.aspx.BookList" %>
<%@ Import Namespace="cn.itcast.bookshop.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">

      <script>

        $(function () {

            $("#pages").html(loadPageLabel(<%=Model.CurrentPage %>,<%= Model.TotalPage%>, 2, "/aspx/BookList.aspx", 5));
            //让当前页的a标签字体颜色变为红色
            $("#pages a:contains(<%=Model.CurrentPage %>)").css("color", "red");


        })
        function loadPageLabel(currentPage, totalPage, range,url,pageSize) {
            str = "";
            //拼接首页链接和上一页链接
            if (currentPage != 1) {

                str += "<a href='" + url + "?currentPage=1&pageSize=" + pageSize + "'>首页</a>&nbsp;&nbsp;";
                str += "<a href='" + url + "?currentPage=" + (currentPage-1) + "&pageSize=" + pageSize + "'>上一页</a>&nbsp;&nbsp;"
            }

            //拼接数字页，如果总页数比较少，直接显示总页数
            if (totalPage <= 2 * range + 1) {

                for (var i = 1; i < totalPage; i++) {
                    str += "<a href='" + url + "?currentPage=" + i + "&pageSize=" + pageSize + "'>第" + i + "页</a>&nbsp;&nbsp;"
                }
            }
            //如果总页数较大，则显示一定范围内的页码
            else {
                //如果当前页比较前
                if (currentPage <= range) {
                    for (var i = 1; i <= 2 * range + 1; i++) {
                        str += "<a href='" + url + "?currentPage=" + i + "&pageSize=" + pageSize + "'>第" + i + "页</a>&nbsp;&nbsp;"
                    }
                }

                //如果当前页在末尾
                else if (currentPage >= totalPage - range + 1) {
                    for (var i = totalPage - 2 * range; i <= totalPage; i++) {
                        str += "<a href='" + url + "?currentPage=" + i + "&pageSize=" + pageSize + "'>第" + i + "页</a>&nbsp;&nbsp;"
                    }
                }
                    //如果当前页在中间
                else {

                    for (var i = currentPage - range; i <= currentPage+range; i++) {
                        str += "<a href='" + url + "?currentPage=" + i + "&pageSize=" + pageSize + "'>第" + i + "页</a>&nbsp;&nbsp;"
                    }

                }

               
            }


            //拼接末页和下一页

            if (currentPage != totalPage) {

                str += "<a href='" + url + "?currentPage=" + totalPage + "&pageSize=" + pageSize + "'>末页</a>&nbsp;";
                str += "<a href='" + url + "?currentPage=" + (currentPage+1) + "&pageSize=" + pageSize + "'>下一页</a>&nbsp;&nbsp;"
            }
            str += "当前第" + currentPage + "页/共" + totalPage + "页"
             return str;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <%foreach (var item in Model.List)
       {%>

    
<TABLE>
                    <TBODY>
                    <TR>
                      <TD rowSpan=2><a  href="BookDetails_<%=item.Id %>.aspx"
                       ><IMG 
                        style="CURSOR: hand" height=121 
                        alt="<%=item.Title %>" hspace=4 
                        src="/Images/BookCovers/<%=item.ISBN %>.jpg" width=95></a> 
</TD>
                      <TD style="FONT-SIZE: small; COLOR: red" width=650><a 
                        class=booktitle id=link_prd_name 
                        href="BookDetails_<%=item.Id %>.aspx" target="_blank" 
                        name="link_prd_name">
                      </a> </TD></TR>
                    <TR>
                      <TD align=left><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"><%=item.Author %></SPAN><BR><BR><SPAN 
                        style="FONT-SIZE: 12px; LINE-HEIGHT: 20px"> <%=GetSuitableLength(  item.AurhorDescription+item.ContentDescription,150 )%></SPAN> 
                      </TD></TR>
                    <TR>
                      <TD align=right colSpan=2><SPAN 
                        style="FONT-WEIGHT: bold; FONT-SIZE: 13px; LINE-HEIGHT: 20px">&yen;
                        <%=item.UnitPrice.ToString("0.00") %></SPAN> </TD></TR></TBODY></TABLE>
    <hr />

      <% } %>

    <div style="width:800px">

        <div id="pages" style="margin:0 auto"></div>

    </div>
  
</asp:Content>
