using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Models.Entity;

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
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Products = db.products.ToList();
            ViewBag.CategoryList = new SelectList(db.categories.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    
                    if (uploadImage != null && uploadImage.ContentLength > 0)
                    {
                        string filename = System.IO.Path.GetFileName(uploadImage.FileName);
                        string path = Server.MapPath("~/Content/images/" + filename);
                        uploadImage.SaveAs(path);

                        product.Image = filename;
                    }

                    db.products.Add(product);
                }
                else
                {
                    
                    var existing = db.products.Find(product.Id);

                    if (existing == null)
                        return HttpNotFound();

                    if (uploadImage != null && uploadImage.ContentLength > 0)
                    {
                        string filename = System.IO.Path.GetFileName(uploadImage.FileName);
                        string path = Server.MapPath("~/Content/images/" + filename);
                        uploadImage.SaveAs(path);

                        existing.Image = filename;
                    }

                    existing.Name = product.Name;
                    existing.Price = product.Price;
                    existing.Quantity = product.Quantity;
                    existing.CategoryId = product.CategoryId;
                }

                db.SaveChanges();
                return RedirectToAction("Create");
            }

            
            ViewBag.Products = db.products.ToList();
            ViewBag.CategoryList = new SelectList(db.categories.ToList(), "Id", "Name", product.CategoryId);

            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var product = db.products.Find(id);
            if(product!=null)
            {
                db.products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Create");
        } 
    }
}