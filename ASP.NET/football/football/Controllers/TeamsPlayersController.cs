using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using football.Models;

namespace football.Controllers
{
    public class TeamsPlayersController : Controller
    {
        private FootBallContext db = new FootBallContext();

        // GET: TeamsPlayers
        public ActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        // GET: TeamsPlayers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = db.Teams.Include(t => t.Players).FirstOrDefault(t => t.id == id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [ChildActionOnly]
        public ActionResult PlayersInTeam(int id)
        {
            var tp = db.Players.Where(p => p.TeamId == id);
            return PartialView(tp);
        }
    }
}
