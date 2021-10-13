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

        public List<tOrder> GetOrder(string userId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters["@UserId"].Value = userId;
            return MSSQLProvider.ToList<tOrder>(MSSQLProvider.QueryCollection(cmd, "sp_get_order"));
        }

        public List<tOrderDetail> GetOrderDetails(int orderId) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.NVarChar));
            cmd.Parameters["@OrderId"].Value = orderId;
            return MSSQLProvider.ToList<tOrderDetail>(MSSQLProvider.QueryCollection(cmd, "sp_get_orderDetail"));
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

        public int CreaetOrder(tOrder order)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Receiver", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar));
            cmd.Parameters["@UserId"].Value = order.fUserId;
            cmd.Parameters["@Receiver"].Value = order.fReceiver;
            cmd.Parameters["@Email"].Value = order.fEmail;
            cmd.Parameters["@Address"].Value = order.fAddress;

            cmd.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            cmd.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            MSSQLProvider.ExecuteNonQuery(cmd, "sp_create_order");
            return (int)cmd.Parameters["@RETURN_VALUE"].Value;
        }

        public void UpdateOrderDetail(string userId, int orderId, bool IsApproved)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));
            cmd.Parameters["@UserId"].Value = userId;
            cmd.Parameters["@OrderId"].Value = orderId;
            cmd.Parameters["@IsApproved"].Value = IsApproved;
            MSSQLProvider.ExecuteNonQuery(cmd, "sp_update_orderDetail");
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

        public List<tOrderDetail> GetShoppingCar(string userId, bool isApproved = false)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));

            cmd.Parameters["@UserId"].Value = userId;
            cmd.Parameters["@IsApproved"].Value = isApproved;

            return MSSQLProvider.ToList<tOrderDetail>(MSSQLProvider.QueryCollection(cmd, "sp_get_shoppingCar"));
        }

        public void DeletShoppingCar(int orderDetailId, string userId, bool isApproved = false)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UserId", SqlDbType.NVarChar));
            cmd.Parameters.Add(new SqlParameter("@IsApproved", SqlDbType.Bit));

            cmd.Parameters["@Id"].Value = orderDetailId;
            cmd.Parameters["@UserId"].Value = userId;
            cmd.Parameters["@IsApproved"].Value = isApproved;

            MSSQLProvider.ExecuteNonQuery(cmd, "sp_delete_shoppingCar");
        }
    }
}