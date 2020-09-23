using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PaintersMenuController : Controller
    {
        private PainterContext db = new PainterContext();

        // GET: PaintersMenu
        public ActionResult Index()
        {
            return View(db.Painter.ToList());
        }

        [ChildActionOnly]
        public ActionResult PaintersMenu()
        {
            var paintersName = db.Painter.ToList();
            return PartialView(paintersName);
        }

        public ActionResult Browse(int id)
        {
            var painterPictures = db.Painter.Include("Pictures").Single(g => g.id == id);
            return View(painterPictures);
        }

        public ActionResult Gallery()
        {
            var pictures = db.Picture.ToList();
            return View(pictures);
        }
    }
}
