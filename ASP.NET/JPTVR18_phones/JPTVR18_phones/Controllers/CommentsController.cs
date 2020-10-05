using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JPTVR18_phones.Models;
using System.Globalization;

namespace JPTVR18_phones.Controllers
{
    public class CommentsController : Controller
    {
        private phonesEntities db = new phonesEntities();

        // GET: Comments
        [ChildActionOnly]
        public PartialViewResult Index(int PhoneID)
        {
            ViewBag.PhoneId = PhoneID;
            var comment = db.Comment.Where(c => c.PhonesId == PhoneID).OrderByDescending(m => m.DatePublish);
            return PartialView(comment.ToList());
        }


        // GET: Comments/Create
        [Authorize]
        public PartialViewResult Create(int PhoneID)
        {
            ViewBag.PhoneId = PhoneID;
            return PartialView();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public PartialViewResult Index(Comment comment, int PhoneID)
        {
            comment.UserName = User.Identity.Name;
            comment.DatePublish = DateTime.Now;
            comment.PhonesId = PhoneID;
            if (ModelState.IsValid)
            {
                db.Comment.Add(comment);
                db.SaveChanges();
            }
            var comments = db.Comment.Where(c => c.PhonesId == PhoneID).OrderByDescending(m => m.DatePublish);
            ViewBag.PhoneId = PhoneID;
            return PartialView("Index", comments.ToList());
        }
        

        // GET: Comments/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comment.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comment.Find(id);
            ViewBag.PhoneId = comment.PhonesId;
            db.Comment.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Phones", new { id = ViewBag.PhoneId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
