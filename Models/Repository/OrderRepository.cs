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
    public class OrderRepository : IOrderRepository
    {
        public tProduct GetShoppingCarProduct(int pId, string userId, bool isApproved)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@PId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));

            cmd.Parameters["@PId"].Value = pId;
            cmd.Parameters["@UserId"].Value = userId;
            cmd.Parameters["@IsApproved"].Value = isApproved;

            return MSSQLProvider.ToList<tProduct>(MSSQLProvider.QueryCollection(cmd, "sp_get_shoppingCarProduct")).FirstOrDefault();
        }

        public void AddOrderDetail(int pId, string userId, int qty = 1)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@PId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
            cmd.Parameters["@PId"].Value = pId;
            cmd.Parameters["@UserId"].Value = userId;
            cmd.Parameters["@Qty"].Value = qty;

            MSSQLProvider.ExecuteNonQuery(cmd, "sp_add_orderDetail");
        }

        public void UpdateOrderDetailQty(int pId, string userId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@PId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Int));
            cmd.Parameters["@PId"].Value = pId;
            cmd.Parameters["@UserId"].Value = userId;
            cmd.Parameters["@IsApproved"].Value = false;

            MSSQLProvider.ExecuteNonQuery(cmd, "sp_update_orderDetailQty");
        }
    }
}