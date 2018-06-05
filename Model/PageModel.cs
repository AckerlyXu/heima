using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.itcast.bookshop.Model
{
    public class PageModel
    {
        public int CurrentPage { get; set; }
        public int TotalPage  { get; set; }
        public int TotalCount { get; set; }
        public List<Books> List { get; set; }
        public int PageSize { get; set; }
        
    }
}
