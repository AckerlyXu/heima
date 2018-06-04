
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

        public Model.Users GerUserByName(string loginId) {

            string sql = "select * from USERS where loginid=@loginid";
            using (SqlDataReader reader=SqlHelper.GetSqlDataReader(sql, new SqlParameter("@loginid", System.Data.SqlDbType.NVarChar, 50) { Value =loginId }))
            {
                if (reader.HasRows) {
                    reader.Read();
                    Model.Users user = new Model.Users();
                    user.Id = reader.GetInt32(0);
                    user.LoginId = reader.GetString(1);
                    user.LoginPwd = reader.GetString(2);
                    user.Name = reader.GetString(3);
                    user.Address = reader.GetString(4);
                    user.Mail = reader.GetString(6);
                    user.UserStateId = reader.GetInt32(7);
                    return user;

                }
                return null;
            }

        }
        
    }
}
