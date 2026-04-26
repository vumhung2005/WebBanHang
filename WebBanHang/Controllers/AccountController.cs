 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.ViewModel;
using WebBanHang.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.WebSockets;
using System.Web.Helpers;

namespace WebBanHang.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVM rvm)
        {
            if (ModelState.IsValid) 
            { 
                var appDbContext = new AppDBContext();
                var appUserStore = new AppUserStore(appDbContext);
                var UserManager = new AppUserManager(appUserStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.UserName,
                    PasswordHash = passwordHash,
                    City = rvm.City,
                    Birthday = rvm.DateOfBirth,
                    Address = rvm.Addresss
                };

                IdentityResult result = UserManager.Create(user);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Custoomer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = UserManager.CreateIdentity(user, 
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
                return View();
            }
                
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM login)
        {
            var appDbContext = new AppDBContext();
            var appUserStore = new AppUserStore(appDbContext);
            var UserManager = new AppUserManager(appUserStore);
            var user = UserManager.Find(login.UserName, login.Password);

            if (user != null) 
            { 
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = UserManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);

                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("MyErorr", "Tài khoản hoặc mật khẩu không đúng");
                return View();
            }
            
        }

    }
}