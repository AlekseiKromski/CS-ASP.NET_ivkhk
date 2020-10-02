using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JPTVR18_phones.Models;
using PagedList.Mvc;
using PagedList;

namespace JPTVR18_phones.Controllers
{
    public class PhonesController : Controller
    {
        private phonesEntities db = new phonesEntities();

        // GET: Phones
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var phones = db.Phones.Include(p => p.Company).OrderBy(p => p.name).ToList();
            return View(phones.ToPagedList(pageNumber, pageSize));
        }

        // GET: Phones/Details/5
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
