
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace cn.itcast.bookshop.DAL
{
   public partial class Users
    {
        public int GetCountByName(string username) {
            string sql = "select count(*) from USERS where loginid=@loginid";
           int count=(int) SqlHelper.ExcuteScalar(sql,new SqlParameter("@loginid", System.Data.SqlDbType.NVarChar, 50) { Value = username });

            return count;

        }
        
    }
}
