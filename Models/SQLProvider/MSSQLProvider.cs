using ShoppingWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ShoppingWeb.DAL
{
    public class MSSQLProvider
    {
        private static string constr = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;

        public static DataTable QueryCollection(SqlCommand cmd, string spName)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                ///設置Command
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0];
            }
        }

        public static DataRow Query(SqlCommand cmd, string spName)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                ///設置Command
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0].Rows[0];
            }
        }

        public static int ExecuteNonQuery(SqlCommand cmd, string spName)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                return cmd.ExecuteNonQuery();
            }
        }

        public static bool ExecuteMultiNonQuery(List<SqlCommand> cmds, string spName)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    foreach (var cmd in cmds)
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = spName;
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return true;
                }
                catch(Exception)
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 將DataTable轉為指定DTO物件的List集合
        /// </summary>
        /// <typeparam name="TResult">DTO</typeparam>
        /// <returns></returns>
        public static List<TResult> ToList<TResult>(DataTable dt) where TResult : class, new()
        {
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            // 取得TResult的類型實例反射的入口
            Type t = typeof(TResult);
            // 獲得TResult所有public屬性，並找出TResult屬性和DataTable屬性名稱相同的屬性(PropertyInfo)並加入到屬性列表
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });
            // 建立返回的集合
            List<TResult> oblist = new List<TResult>();
            
            foreach(DataRow row in dt.Rows)
            {
                TResult ob = new TResult();
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                oblist.Add(ob);
            }
            return oblist;
        }
    }
}