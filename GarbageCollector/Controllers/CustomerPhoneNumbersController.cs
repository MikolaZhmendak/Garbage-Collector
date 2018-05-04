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
    public class CustomerPhoneNumbersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerPhoneNumbers
        public ActionResult Index()
        {
            return View(db.CustomerPhoneNumber.ToList());
        }

        // GET: CustomerPhoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPhoneNumber customerPhoneNumber = db.CustomerPhoneNumber.Find(id);
            if (customerPhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(customerPhoneNumber);
        }

        // GET: CustomerPhoneNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerPhoneNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AreaCode,PhoneNumber")] CustomerPhoneNumber customerPhoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.CustomerPhoneNumber.Add(customerPhoneNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerPhoneNumber);
        }

        // GET: CustomerPhoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPhoneNumber customerPhoneNumber = db.CustomerPhoneNumber.Find(id);
            if (customerPhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(customerPhoneNumber);
        }

        // POST: CustomerPhoneNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AreaCode,PhoneNumber")] CustomerPhoneNumber customerPhoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerPhoneNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerPhoneNumber);
        }

        // GET: CustomerPhoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPhoneNumber customerPhoneNumber = db.CustomerPhoneNumber.Find(id);
            if (customerPhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(customerPhoneNumber);
        }

        // POST: CustomerPhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerPhoneNumber customerPhoneNumber = db.CustomerPhoneNumber.Find(id);
            db.CustomerPhoneNumber.Remove(customerPhoneNumber);
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
