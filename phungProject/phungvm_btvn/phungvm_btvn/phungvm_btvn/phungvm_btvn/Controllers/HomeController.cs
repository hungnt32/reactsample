using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phungvm_btvn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Register";

            return View("../Users/Create");
        }
        public ActionResult Login()
        {
            ViewBag.Title = "Login";

            return View("../Users/Login");
        }
    }
}
