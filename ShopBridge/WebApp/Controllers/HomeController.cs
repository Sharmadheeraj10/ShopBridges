using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public bool IsValidAddress(string emailAddress)
        {
            Regex regex = new Regex(@"^[\w0-9._%+-]+@[\w0-9.-]+\.[\w]{2,6}$");
            return regex.IsMatch(emailAddress);
        }
    }

}