using ShoppingWeb.Models.Interface;
using ShoppingWeb.Models.Repository;
using System.Web.Mvc;

namespace ShoppingWeb.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        public HomeController() {
            this.productRepository = new ProductRepository();
        }

        public ActionResult Index()
        {
            var products = this.productRepository.GetAll();

            if(Session["Member"] is null) return View("Index", "_Layout", products);
            else  return View("Index", "_LayoutMember", products);
        }
    }
}