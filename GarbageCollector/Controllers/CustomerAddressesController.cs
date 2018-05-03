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
    public class CustomerAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerAddresses
        public ActionResult Index()
        {
            return View(db.CustomerAdresses.ToList());
        }

        // GET: CustomerAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddress customerAddress = db.CustomerAdresses.Find(id);
            if (customerAddress == null)
            {
                return HttpNotFound();
            }
            return View(customerAddress);
        }

        // GET: CustomerAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerMainAddress,CustomerCity,CustomerState,CustomerZipCode")] CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                db.CustomerAdresses.Add(customerAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerAddress);
        }

        // GET: CustomerAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddress customerAddress = db.CustomerAdresses.Find(id);
            if (customerAddress == null)
            {
                return HttpNotFound();
            }
            return View(customerAddress);
        }

        // POST: CustomerAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerMainAddress,CustomerCity,CustomerState,CustomerZipCode")] CustomerAddress customerAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerAddress);
        }

        // GET: CustomerAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAddress customerAddress = db.CustomerAdresses.Find(id);
            if (customerAddress == null)
            {
                return HttpNotFound();
            }
            return View(customerAddress);
        }

        // POST: CustomerAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerAddress customerAddress = db.CustomerAdresses.Find(id);
            db.CustomerAdresses.Remove(customerAddress);
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
