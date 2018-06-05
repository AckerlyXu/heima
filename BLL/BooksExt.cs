using cn.itcast.bookshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.itcast.bookshop.BLL
{
    public partial class Books
    {

        public void GetPageModel(PageModel model) {
         dal.GetPageModel(model);


        }
    }
}
