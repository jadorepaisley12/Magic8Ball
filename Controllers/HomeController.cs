using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TwilioTest2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(bool? messageSent)
        {
            if (messageSent != null)
            {
                ViewBag.MessageSent = messageSent;
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