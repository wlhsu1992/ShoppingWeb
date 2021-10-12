using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWeb.Models.Interface
{
    public interface IOrderRepository
    {
        tProduct GetShoppingCarProduct(int pId, string userId, bool isApproved);

        void AddOrderDetail(int pId, string userId, int qty=1);

        void UpdateOrderDetailQty(int pId, string userId);

    }
}
