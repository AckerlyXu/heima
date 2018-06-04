using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cn.itcast.bookshop.BLL
{
    
    public partial class Users
    {
        public int GetCountByName(string username) {
            return dal.GetCountByName(username);
        }
        public Model.Users GetUserByName(string username) {

            return dal.GerUserByName(username);

        }

    }
}
