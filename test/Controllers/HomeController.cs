using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
namespace test.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       
        public ActionResult Index(string search = "", int page = 1)
        {
            CompanyDBContext db = new CompanyDBContext();
            IList<Product> Products = db.Products.Where(row => row.Brand.BrandName.Contains(search)).ToList();
            // Phân trang
            int NoOfReCordPerPage = 8;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Products.Count) / Convert.ToDouble(NoOfReCordPerPage)));
            int NoOfReCordToSkip = (page - 1) * NoOfReCordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            Products = Products.Skip(NoOfReCordToSkip).Take(NoOfReCordPerPage).ToList();
            return View(Products);
        }
        public ActionResult Cart(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            List<Product> empls = db.Products.ToList();
            Product em = null;
            foreach (var e in empls)
            {
                if (e.ProductID == id)
                {
                    em = e;
                }
            }
            return View(em);
           
        }
	}
}