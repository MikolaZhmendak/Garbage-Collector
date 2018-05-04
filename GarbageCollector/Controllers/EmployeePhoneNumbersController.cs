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
    public class EmployeePhoneNumbersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeePhoneNumbers
        public ActionResult Index()
        {
            return View(db.EmployeePhoneNumber.ToList());
        }

        // GET: EmployeePhoneNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePhoneNumber employeePhoneNumber = db.EmployeePhoneNumber.Find(id);
            if (employeePhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(employeePhoneNumber);
        }

        // GET: EmployeePhoneNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeePhoneNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PhoneNumer,AreaCode")] EmployeePhoneNumber employeePhoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.EmployeePhoneNumber.Add(employeePhoneNumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeePhoneNumber);
        }

        // GET: EmployeePhoneNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePhoneNumber employeePhoneNumber = db.EmployeePhoneNumber.Find(id);
            if (employeePhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(employeePhoneNumber);
        }

        // POST: EmployeePhoneNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PhoneNumer,AreaCode")] EmployeePhoneNumber employeePhoneNumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeePhoneNumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeePhoneNumber);
        }

        // GET: EmployeePhoneNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeePhoneNumber employeePhoneNumber = db.EmployeePhoneNumber.Find(id);
            if (employeePhoneNumber == null)
            {
                return HttpNotFound();
            }
            return View(employeePhoneNumber);
        }

        // POST: EmployeePhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeePhoneNumber employeePhoneNumber = db.EmployeePhoneNumber.Find(id);
            db.EmployeePhoneNumber.Remove(employeePhoneNumber);
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
