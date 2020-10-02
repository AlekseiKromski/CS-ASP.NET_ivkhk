using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JPTVR18_phones.Models;

namespace JPTVR18_phones.Controllers
{
    public class PhonesActionController : Controller
    {
        private phonesEntities db = new phonesEntities();

        // GET: PhonesAction
        [Authorize]
        public ActionResult Index()
        {
            var phones = db.Phones.Include(p => p.Company);
            return View(phones.ToList());
        }

        // GET: PhonesAction/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phones phones = db.Phones.Find(id);
            if (phones == null)
            {
                return HttpNotFound();
            }
            return View(phones);
        }

        // GET: PhonesAction/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.companyId = new SelectList(db.Company, "id", "name");
            return View();
        }

        // POST: PhonesAction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,price,companyId")] Phones phones)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.companyId = new SelectList(db.Company, "id", "name", phones.companyId);
            return View(phones);
        }

        // GET: PhonesAction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phones phones = db.Phones.Find(id);
            if (phones == null)
            {
                return HttpNotFound();
            }
            ViewBag.companyId = new SelectList(db.Company, "id", "name", phones.companyId);
            return View(phones);
        }

        // POST: PhonesAction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price,companyId")] Phones phones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.companyId = new SelectList(db.Company, "id", "name", phones.companyId);
            return View(phones);
        }

        // GET: PhonesAction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phones phones = db.Phones.Find(id);
            if (phones == null)
            {
                return HttpNotFound();
            }
            return View(phones);
        }

        // POST: PhonesAction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phones phones = db.Phones.Find(id);
            db.Phones.Remove(phones);
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
    }
}
