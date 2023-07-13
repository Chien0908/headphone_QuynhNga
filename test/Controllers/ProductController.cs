using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using test.Filters;

namespace test.Controllers
{
    
    public class ProductController : Controller
    {
        //
        // GET: /Products/
        [MyauthenFilter]
        public ActionResult Index(string SortColumn, int page = 1)
        {
            CompanyDBContext DB = new CompanyDBContext();
            List<Product> Products = DB.Products.ToList();
            ViewBag.SortColumn = SortColumn;

            if (SortColumn == "Thấp đến Cao")
            {
                Products = Products.OrderBy(row => row.Price).ToList();
            }
            else if (SortColumn == "Cao đến thấp")
            {
                Products = Products.OrderByDescending(row => row.Price).ToList();
            }
            else if (SortColumn == "Tên: A-Z")
            {
                Products = Products.OrderBy(row => row.ProductName).ToList();
            }
            // Phân trang
            int NoOfReCordPerPage = 8;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Products.Count) / Convert.ToDouble(NoOfReCordPerPage)));
            int NoOfReCordToSkip = (page - 1) * NoOfReCordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            Products = Products.Skip(NoOfReCordToSkip).Take(NoOfReCordPerPage).ToList();
            
            return View(Products);
        }
        [MyauthenFilter]
        public ActionResult Detail(int id)
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
        public ActionResult search_CategoryName(string search = "", string SortColumn = "IDSanPham", int page = 1)
        {
            CompanyDBContext db = new CompanyDBContext();
            IList<Product> Products = db.Products.Where(row => row.Category.CategoryName.Contains(search)).ToList();
            if (SortColumn == "Thấp đến Cao")
            {
                Products = Products.OrderBy(row => row.Price).ToList();
            }
            else if  (SortColumn == "Cao đến thấp")
            {
                Products = Products.OrderByDescending(row => row.Price).ToList();
            }
            else if (SortColumn == "Tên: A-Z")
            {
                Products = Products.OrderByDescending(row => row.ProductName).ToList();
            }
            // Phân trang
            int NoOfReCordPerPage = 8;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Products.Count) / Convert.ToDouble(NoOfReCordPerPage)));
            int NoOfReCordToSkip = (page - 1) * NoOfReCordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            Products = Products.Skip(NoOfReCordToSkip).Take(NoOfReCordPerPage).ToList();
            
            return View(Products);

        }
        public ActionResult search_ProductName(string search = "", string SortColumn = "IDSanPham", int page = 1)
        {
            CompanyDBContext db = new CompanyDBContext();
            IList<Product> Products = db.Products.Where(row => row.ProductName.Contains(search)).ToList();

            if (SortColumn == "Thấp đến Cao")
            {
                Products = Products.OrderBy(row => row.Price).ToList();
            }
            else if (SortColumn == "Cao đến thấp")
            {
                Products = Products.OrderByDescending(row => row.Price).ToList();
            }
            else if (SortColumn == "Tên: A-Z")
            {
                Products = Products.OrderBy(row => row.ProductName).ToList();
            }
            // Phân trang
            int NoOfReCordPerPage = 8;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Products.Count) / Convert.ToDouble(NoOfReCordPerPage)));
            int NoOfReCordToSkip = (page - 1) * NoOfReCordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPages = NoOfPages;
            Products = Products.Skip(NoOfReCordToSkip).Take(NoOfReCordPerPage).ToList();
            
            
            ViewBag.search = search;
            return View(Products);
        }
	}
}