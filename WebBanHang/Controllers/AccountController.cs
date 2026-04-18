 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            //var user = db.users.FirstOrDefault(x => x.Username == username && x.Password == password);


            //if (user != null) 
            //{
            //    Session["user"] = user;
            //    Session["role"] = user.Role;

            //    return RedirectToAction("Index");
            //}

            //ViewBag.Error = "Sai mật khẩu hoặc tài khoản!";
            return View();
        }
    }
}