using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // index controller
        public ActionResult Index()
        {
            // returns the user back to the index page
            return View();
        }

        // about controller
        public ActionResult About()
        {
            // returns the user to the site's about page
            ViewBag.Message = "Your application description page.";
            return View();
        }

        // contact controller
        public ActionResult Contact()
        {
            // returns the user to the site's contact page
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
