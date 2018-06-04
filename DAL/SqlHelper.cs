using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace cn.itcast.bookshop.DAL

{
	public static class SqlHelper
	{
		private static string url = ConfigurationManager.AppSettings["ConnectionString"];

		public static int ExcuteNunQuery(string sql,params SqlParameter[] sqlParameters) {
			using (SqlConnection con=new SqlConnection(url))
			{
				using (SqlCommand com=new SqlCommand(sql,con))
				{
					com.Parameters.AddRange(sqlParameters);
					con.Open();
					return com.ExecuteNonQuery();
				}
			}
		}

		public static int ExcuteNunQueryPro(string sql, params SqlParameter[] sqlParameters)
		{
			using (SqlConnection con = new SqlConnection(url))
			{
				using (SqlCommand com = new SqlCommand(sql, con))
				{
					com.CommandType = CommandType.StoredProcedure;
					com.Parameters.AddRange(sqlParameters);
					con.Open();
					return com.ExecuteNonQuery();
				}
			}
		}

		public static DataTable getDataSet(string sql, params SqlParameter[] sqlParameters) {

			using (SqlDataAdapter adapter = new SqlDataAdapter(sql, url)) {

				adapter.SelectCommand.Parameters.AddRange(sqlParameters);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}
		public static DataTable getDataSetPro(string sql, params SqlParameter[] sqlParameters)
		{

			using (SqlDataAdapter adapter = new SqlDataAdapter(sql, url))
			{

				adapter.SelectCommand.Parameters.AddRange(sqlParameters);
				adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}


		public static Object ExcuteScalar(string sql, params SqlParameter[] sqlParameters) {
			using (SqlConnection con = new SqlConnection(url)) {
				using (SqlCommand com = new SqlCommand(sql, con)) {
					com.Parameters.AddRange(sqlParameters);
					con.Open();
					return com.ExecuteScalar();
				}

			}

		}
		public static Object ExcuteScalarPro(string sql, params SqlParameter[] sqlParameters)
		{
			using (SqlConnection con = new SqlConnection(url))
			{
				using (SqlCommand com = new SqlCommand(sql, con))
				{
					com.CommandType = CommandType.StoredProcedure;
					com.Parameters.AddRange(sqlParameters);
					con.Open();
					return com.ExecuteScalar();
				}

			}

		}

		public static SqlDataReader GetSqlDataReader(string sql, params SqlParameter[] sqlParameters) {

			//方法内部不能关闭连接，因为方法外部要使用reader，要保证连接是开启状态++++
			SqlConnection con = new SqlConnection(url);
			using (SqlCommand com = new SqlCommand(sql, con)) {
				try
				{
					con.Open();
			
					com.Parameters.AddRange(sqlParameters);
					//设置关闭reader后关闭connection++++++
					return com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				}
				catch (Exception)
				{
					con.Close();
					con.Dispose();

					throw;
				}	

			}

		}
		public static SqlDataReader GetSqlDataReaderPro(string sql, params SqlParameter[] sqlParameters)
		{

			//方法内部不能关闭连接，因为方法外部要使用reader，要保证连接是开启状态++++
			SqlConnection con = new SqlConnection(url);
			using (SqlCommand com = new SqlCommand(sql, con))
			{
				try
				{
					com.CommandType = CommandType.StoredProcedure;
					con.Open();

					com.Parameters.AddRange(sqlParameters);
					//设置关闭reader后关闭connection++++++
					return com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
				}
				catch (Exception)
				{
					con.Close();
					con.Dispose();

					throw;
				}

			}

		}
	}
}
