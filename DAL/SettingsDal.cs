using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using cn.itcast.bookshop.Common;

namespace cn.itcast.bookshop.DAL
{
    public class SettingsDal
    {

        public string GetValue(string name) {
            string sql = "select Value from Settings where name=@name";
            return SqlHelper.ExcuteScalar(sql, new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 50) { Value = name }) as string ;

        }
        public int SetValue(string name,string value) {
            string sql = "update Settings set value=@value where name =@name";
  
            return SqlHelper.ExcuteNunQuery(sql, new SqlParameter("@value", System.Data.SqlDbType.NVarChar, 50) { Value = value }, new SqlParameter("@name", System.Data.SqlDbType.NVarChar, 50) { Value = name });

                

        }
    }
}
