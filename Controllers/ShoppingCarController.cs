using ShoppingWeb.Models;
using ShoppingWeb.Models.Interface;
using ShoppingWeb.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWeb.Controllers
{
    public class ShoppingCarController : Controller
    {
        private IOrderRepository orderRepository = new OrderRepository();

        // GET: ShoppingCar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCar(int pId)
        {
            // Session取得會員帳號並指定給 fUserId
            string userId = (Session["Member"] as tMember).fUserId;

            // 判斷商品是否以在購物車中
            var product = orderRepository.GetShoppingCarProduct(pId, userId, false);

            if (product is null) { //不在購物車中
                orderRepository.AddOrderDetail(pId, userId);
                // 將產品資料加入到訂單明細中
            } else {
                // 將該訂單訂購產品數量+1
                orderRepository.UpdateOrderDetailQty(pId, userId);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}