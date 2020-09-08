using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Praktika_1.Models;

namespace Praktika_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string name = "world";
            ViewBag.Hello = "hello, " + name;
            int hour = DateTime.Now.Hour;
            ViewBag.Time = hour < 12 ? "Доброе утро" : "Добрый день";

            return View();
        }

        public string Start()
        {
            return "Hello, world";
        }

        [HttpGet]// SHOW FORM
        public ViewResult RegisterForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RegisterForm(GuestResponse gs)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", gs);
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Contact(ContactResponse cr)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks_Contact", cr);

            }
            else
            {
                return View();
            }
        }
    }
}