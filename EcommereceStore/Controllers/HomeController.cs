using EcommereceStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommereceStore.Controllers
{
    public class HomeController : Controller
    {
        DbEntities DbEntities = new DbEntities();
        public ActionResult Index()
        {
            var data = DbEntities.Products.ToList();
            return View(data);
        }
        public ActionResult checkout()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var data = DbEntities.ShopCarts.ToList();
            return View(data);
        }
        public ActionResult ProduntDetails(int id)
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var data = DbEntities.Products.Where(x => x.Pid == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Addtocart(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Alluser alluser)
        {
            DbEntities.Allusers.Add(alluser);
            DbEntities.SaveChanges();
            Session["UserName"] = alluser.Username;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Alluser alluser)
        {
            var data = DbEntities.Allusers.Where(x => x.useremail == alluser.useremail && x.UserPass == alluser.UserPass).FirstOrDefault();
            if (data != null)
            {
                Session["UserName"] = data.Username;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}