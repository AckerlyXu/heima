using cn.itcast.bookshop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.itcast.bookshop.DAL
{
    public partial class Books
    {

        public void GetPageModel(PageModel model) {
            List<Model.Books> list = GetPageBooks(model.CurrentPage, model.PageSize);
            model.List = list;
            int count = GetBookCount();
            int totalPage = (int)Math.Ceiling(count * 1.0 / model.PageSize);
            model.TotalPage = totalPage;
            model.TotalCount = count;
        }
        public int GetBookCount() {
            string sql = "select count(*) from books";
          return  (int)SqlHelper.ExcuteScalar(sql);

        }
        public List<Model.Books> GetPageBooks(int currentPage, int pageSize) {
            string sql= "select * from (select * ,rows=Row_Number() over (order by id) from Books) as b where b.rows between (@currentPage-1)*@pageSize+1 and @currentPage*@pageSize";
            List<Model.Books> books = new List<Model.Books>();
            using (SqlDataReader reader=SqlHelper.GetSqlDataReader(sql,new SqlParameter("@currentPage", System.Data.SqlDbType.Int) {Value=currentPage }, new SqlParameter("@pageSize", System.Data.SqlDbType.Int) { Value = pageSize }))
            {
                if (reader.HasRows) {

                    while (reader.Read()) {

                        Model.Books book = new Model.Books();
                        book.Id = reader.GetInt32(0);
                        book.Title = reader.GetString(1);
                        book.Author = reader.GetString(2);
                        book.PublisherId = reader.GetInt32(3);
                        book.PublishDate = reader.GetDateTime(4);
                        book.ISBN = reader.GetString(5);
                        book.WordsCount = reader.GetInt32(6);
                        book.UnitPrice = reader.GetDecimal(7);
                        book.ContentDescription = reader.GetString(8);
                        book.AurhorDescription = reader.GetString(9);
                        book.EditorComment = reader.GetString(10);
                        book.CategoryId = reader.GetInt32(12);
                        books.Add(book);
                    }
                   

                }
                return books;
            }

        }
    }
}
