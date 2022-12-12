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