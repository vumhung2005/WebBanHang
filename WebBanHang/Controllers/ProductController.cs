using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Product
        public ActionResult Index()
        {
            var data = db.products.ToList();
            return View(data);
        }

        public ActionResult Details(int id)
        { 
            var product = db.products
                            .Include("Category")
                            .FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
    }
}