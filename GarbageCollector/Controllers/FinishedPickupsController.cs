using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarbageCollector.Models;

namespace GarbageCollector.Controllers
{
    public class FinishedPickupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinishedPickups
        public ActionResult Index()
        {
            return View(db.FinishedPickups.ToList());
        }

        // GET: FinishedPickups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedPickups finishedPickups = db.FinishedPickups.Find(id);
            if (finishedPickups == null)
            {
                return HttpNotFound();
            }
            return View(finishedPickups);
        }

        // GET: FinishedPickups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinishedPickups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,EmployeeId,FinishedDates")] FinishedPickups finishedPickups)
        {
            if (ModelState.IsValid)
            {
                db.FinishedPickups.Add(finishedPickups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finishedPickups);
        }

        // GET: FinishedPickups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedPickups finishedPickups = db.FinishedPickups.Find(id);
            if (finishedPickups == null)
            {
                return HttpNotFound();
            }
            return View(finishedPickups);
        }

        // POST: FinishedPickups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,EmployeeId,FinishedDates")] FinishedPickups finishedPickups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finishedPickups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finishedPickups);
        }

        // GET: FinishedPickups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedPickups finishedPickups = db.FinishedPickups.Find(id);
            if (finishedPickups == null)
            {
                return HttpNotFound();
            }
            return View(finishedPickups);
        }

        // POST: FinishedPickups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinishedPickups finishedPickups = db.FinishedPickups.Find(id);
            db.FinishedPickups.Remove(finishedPickups);
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
