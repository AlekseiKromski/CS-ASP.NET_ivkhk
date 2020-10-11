using filmJPTVR18.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace filmJPTVR18.Controllers
{
    public class HomeController : Controller
    {

        private filmJPTVR18Entities2 db = new filmJPTVR18Entities2();

        public ActionResult Index()
        {
            return View(db.Films.OrderByDescending(v => v.Id).Take(3).ToList());
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

        public FileContentResult GetImage(int id)
        {
            Film film = db.Films.FirstOrDefault(f => f.Id == id);
            if (film.Image != null)
            {
                return File(film.Image, film.ImageType);
            }
            return null;
        }
    }
}