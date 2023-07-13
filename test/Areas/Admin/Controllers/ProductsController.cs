using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Filters;
using System.IO;
namespace test.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        //
        // GET: /Admin/Products/
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> products = db.Products.ToList();
            return View(products);
           
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product sp)
        {
            CompanyDBContext db = new CompanyDBContext();
            db.Products.Add(sp);
            db.SaveChanges();
            

            return RedirectToAction("Index", "Products", new { area = "Admin" });
        }
        
        
        public ActionResult Delete(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product products = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product sp)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product products = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index", "products", new { area = "Admin" });
        }
        public ActionResult Edit(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product products = db.Products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }
        [HttpPost]
        public ActionResult Edit(Product sp)
        {
            CompanyDBContext db = new CompanyDBContext();
            Product products = db.Products.Where(row => row.ProductID == sp.ProductID).FirstOrDefault();

            // Sửa sản phẩm
            
            products.ProductName = sp.ProductName;
            products.Price = sp.Price;
            products.Information = sp.Information;
            products.DateOfPurChase = sp.DateOfPurChase;
            products.AvailabilityStatus = sp.AvailabilityStatus;
            products.CategoryID = sp.CategoryID;
            products.BrandID = sp.BrandID;
            products.Active = sp.Active;
            products.Image = sp.Image;
            db.SaveChanges();
            return RedirectToAction("Index", "Products", new { area = "Admin" });
        }
	}
}