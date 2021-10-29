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
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository = new OrderRepository();

        public ActionResult Index()
        {
            var userId = (Session["Member"] as tMember).fUserId;
            List<tOrder> orders = orderRepository.GetOrder(userId);
            return View("index", "_LayoutMember", orders);
        }

        public ActionResult OrderDetail(int orderId)
        {
            List<tOrderDetail> orderDeatails = orderRepository.GetOrderDetails(orderId);
            return View(orderDeatails);
        }
    }
}