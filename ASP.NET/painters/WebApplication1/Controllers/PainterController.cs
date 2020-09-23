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
    public class PainterController : Controller
    {
        private PainterContext db = new PainterContext();

        // GET: Painter
        public ActionResult Index()
        {
            return View(db.Painter.ToList());
        }

        // GET: Painter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Painter painter = db.Painter.Find(id);
            painter = db.Painter.Include(p => p.pictures).FirstOrDefault(p => p.id == id);

            if (painter == null)
            {
                return HttpNotFound();
            }
            return View(painter);
        }

        // GET: Painter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Painter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,country,biography,photo,photoType")] Painter painter, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    painter.photoType = img.ContentType;
                    painter.photo = new byte[img.ContentLength];
                    img.InputStream.Read(painter.photo, 0, img.ContentLength);

                }
                db.Painter.Add(painter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(painter);
        }

        // GET: Painter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Painter painter = db.Painter.Find(id);
            if (painter == null)
            {
                return HttpNotFound();
            }
            return View(painter);
        }

        // POST: Painter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,country,biography,photo,photoType")] Painter painter, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                if (img != null)
                {
                    painter.photoType = img.ContentType;
                    painter.photo = new byte[img.ContentLength];
                    img.InputStream.Read(painter.photo, 0, img.ContentLength);

                }
                db.Entry(painter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(painter);
        }

        // GET: Painter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Painter painter = db.Painter.Find(id);
            if (painter == null)
            {
                return HttpNotFound();
            }
            return View(painter);
        }

        // POST: Painter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Painter painter = db.Painter.Find(id);
            db.Painter.Remove(painter);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public FileContentResult GetImage(int id)
        {
            //запрос в БД таблица Players по переданному id
            Painter painter = db.Painter.FirstOrDefault(p => p.id == id);
            if (painter != null)
            {
                return File(painter.photo, painter.photoType);
            }
            return null;
        }

        [ChildActionOnly]
        public ActionResult PicturesInPainters(int id)
        {
            var pp = db.Picture.Where(p => p.painterId == id);
            return PartialView(pp);
        }
    }
}
