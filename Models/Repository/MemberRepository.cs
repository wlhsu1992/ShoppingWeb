using ShoppingWeb.DAL;
using ShoppingWeb.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoppingWeb.Models.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void Create(tMember member)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Pwd", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));

            cmd.Parameters["@UserId"].Value = member.fUserId;
            cmd.Parameters["@Pwd"].Value = member.fPwd;
            cmd.Parameters["@Name"].Value = member.fName;
            cmd.Parameters["@Email"].Value = member.fEmail;

            MSSQLProvider.ExecuteNonQuery(cmd, "sp_add_member");
        }

        public void Delete(tMember instance)
        {
            throw new NotImplementedException();
        }

        public tMember Get(string userId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters["@UserId"].Value = userId;

            return MSSQLProvider.ToList<tMember>(MSSQLProvider.QueryCollection(cmd, "sp_get_memberByUserId")).FirstOrDefault();

        }

        public IEnumerable<tMember> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(tMember instance)
        {
            throw new NotImplementedException();
        }
    }
}