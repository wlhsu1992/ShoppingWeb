using ShoppingWeb.Models;
using ShoppingWeb.Models.Interface;
using ShoppingWeb.Models.Repository;
using System.Web.Mvc;

namespace ShoppingWeb.Controllers
{
    public class ShoppingCarController : Controller
    {
        private IOrderRepository orderRepository = new OrderRepository();

        public ActionResult Index()
        {
            // 取得使用者購物車資訊
            string userId = (Session["Member"] as tMember).fUserId;
            var orderDetail = orderRepository.GetShoppingCar(userId);
            return View("index", "_LayoutMember", orderDetail);
        }

        public ActionResult AddCar(int pId)
        {
            string userId = (Session["Member"] as tMember).fUserId;

            var product = orderRepository.GetShoppingCarProduct(pId, userId, false);
            
            // 判斷商品是否以在購物車中
            if (product is null) { 
                // 將產品資料加入到訂單明細中
                orderRepository.AddOrderDetail(pId, userId);
            } else {
                // 修改訂單訂購產品數量+1
                orderRepository.UpdateOrderDetailQty(pId, userId);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteCar(int orderDetailId)
        {
            string userId = (Session["Member"] as tMember).fUserId;
            orderRepository.DeletShoppingCar(orderDetailId, userId);
            return RedirectToAction("Index");
        }

        public ActionResult Checkout(string receiver, string email, string address)
        {
            string userId = (Session["Member"] as tMember).fUserId;

            tOrder order = new tOrder
            {
                fUserId = userId,
                fReceiver = receiver,
                fEmail = email,
                fAddress = address,
            };
            var orderId = orderRepository.CreaetOrder(order);

            // 更新訂單明細訂購狀態
            orderRepository.UpdateOrderDetail(userId, orderId, true);

            return RedirectToAction("Index", "Order");
        }
    }
}