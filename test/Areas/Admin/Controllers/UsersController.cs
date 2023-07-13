using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Identity;
using test.Filters;
namespace test.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        //
        // GET: /Admin/Users/
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
        public ActionResult Delete(string id)
        {
            AppDbContext db = new AppDbContext();
            AppUser users = db.Users.Where(row => row.Id == id).FirstOrDefault();
            return View(users);
        }
        [HttpPost]
        public ActionResult Delete(string id, AppUser sp)
        {
            AppDbContext db = new AppDbContext();
            AppUser users = db.Users.Where(row => row.Id == id).FirstOrDefault();
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index", "Users", new { area = "Admin" });
        }
        public ActionResult Create()
        {
            return View();
        }

        
	}
}