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
    public class EmployeeAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeAddresses
        public ActionResult Index()
        {
            return View(db.EmployeeAddress.ToList());
        }

        // GET: EmployeeAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAddress employeeAddress = db.EmployeeAddress.Find(id);
            if (employeeAddress == null)
            {
                return HttpNotFound();
            }
            return View(employeeAddress);
        }

        // GET: EmployeeAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PrimaryEmployeeAddress,City,State,ZipCode")] EmployeeAddress employeeAddress)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeAddress.Add(employeeAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeAddress);
        }

        // GET: EmployeeAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAddress employeeAddress = db.EmployeeAddress.Find(id);
            if (employeeAddress == null)
            {
                return HttpNotFound();
            }
            return View(employeeAddress);
        }

        // POST: EmployeeAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrimaryEmployeeAddress,City,State,ZipCode")] EmployeeAddress employeeAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeAddress);
        }

        // GET: EmployeeAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAddress employeeAddress = db.EmployeeAddress.Find(id);
            if (employeeAddress == null)
            {
                return HttpNotFound();
            }
            return View(employeeAddress);
        }

        // POST: EmployeeAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAddress employeeAddress = db.EmployeeAddress.Find(id);
            db.EmployeeAddress.Remove(employeeAddress);
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
