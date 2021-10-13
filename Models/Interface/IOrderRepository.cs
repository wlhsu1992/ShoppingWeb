using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.Models.Interface
{
    public interface IOrderRepository
    {
        tProduct GetShoppingCarProduct(int pId, string userId, bool isApproved = false);

        void AddOrderDetail(int pId, string userId, int qty=1);

        int CreaetOrder(tOrder order);

        void UpdateOrderDetail(string userId, int orderId, bool IsApproved);

        void UpdateOrderDetailQty(int pId, string userId);

        List<tOrderDetail> GetShoppingCar(string userId, bool isApproved = false);

        void DeletShoppingCar(int orderDetailId, string userId, bool isApproved = false);
    }
}
