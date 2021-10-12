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
    public class MemberController : Controller
    {
        private IMemberRepository memberRepository;
        public MemberController()
        {
            this.memberRepository = new MemberRepository();
        }


        // GET: Member
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tMember pMember)
        {
            if (ModelState.IsValid == false) return View();
            
            // 檢查會員帳號是否重複
            if (memberRepository.Get(pMember.fUserId) is null) {
                // 新增會員
                memberRepository.Create(pMember);
                return RedirectToAction("Login");
            } else {
                ViewBag.Message = "此帳號已有人使用，請使用另一組帳號";
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userId, string pwd)
        {
            var member = memberRepository.Get(userId, pwd);
            if(member is null)
            {
                ViewBag.Message = "帳號密碼輸入錯誤";
                return View();
            }
            Session["Member"] = member;
            return RedirectToAction("Index","Home");
        }
    }
}