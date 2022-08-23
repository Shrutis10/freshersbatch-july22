using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_1_3.Models;

namespace Assignment_1_3.Controllers
{
    public class FOOTBALL_LEAGUEController : Controller
    {
        private footballEntities db = new footballEntities();

        // GET: FOOTBALL_LEAGUE
        public ActionResult Index()
        {
            return View(db.FOOTBALL_LEAGUE.ToList());
        }

        // GET: FOOTBALL_LEAGUE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTBALL_LEAGUE fOOTBALL_LEAGUE = db.FOOTBALL_LEAGUE.Find(id);
            if (fOOTBALL_LEAGUE == null)
            {
                return HttpNotFound();
            }
            return View(fOOTBALL_LEAGUE);
        }

        // GET: FOOTBALL_LEAGUE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FOOTBALL_LEAGUE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatchID,TeamName1,TeamName2,Status,WinningTeam,Points")] FOOTBALL_LEAGUE fOOTBALL_LEAGUE)
        {
            if (ModelState.IsValid)
            {
                db.FOOTBALL_LEAGUE.Add(fOOTBALL_LEAGUE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fOOTBALL_LEAGUE);
        }

        // GET: FOOTBALL_LEAGUE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTBALL_LEAGUE fOOTBALL_LEAGUE = db.FOOTBALL_LEAGUE.Find(id);
            if (fOOTBALL_LEAGUE == null)
            {
                return HttpNotFound();
            }
            return View(fOOTBALL_LEAGUE);
        }

        // POST: FOOTBALL_LEAGUE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatchID,TeamName1,TeamName2,Status,WinningTeam,Points")] FOOTBALL_LEAGUE fOOTBALL_LEAGUE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOOTBALL_LEAGUE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fOOTBALL_LEAGUE);
        }

        // GET: FOOTBALL_LEAGUE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTBALL_LEAGUE fOOTBALL_LEAGUE = db.FOOTBALL_LEAGUE.Find(id);
            if (fOOTBALL_LEAGUE == null)
            {
                return HttpNotFound();
            }
            return View(fOOTBALL_LEAGUE);
        }

        // POST: FOOTBALL_LEAGUE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FOOTBALL_LEAGUE fOOTBALL_LEAGUE = db.FOOTBALL_LEAGUE.Find(id);
            db.FOOTBALL_LEAGUE.Remove(fOOTBALL_LEAGUE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult won()
        {
            WonMatchDetails win = new WonMatchDetails();
            List<FOOTBALL_LEAGUE> winlist = win.winninglist();
            return View(winlist);
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
