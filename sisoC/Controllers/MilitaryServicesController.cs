using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sisoC.Models;

namespace sisoC.Controllers
{
    public class MilitaryServicesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: MilitaryServices
        public ActionResult Index()
        {
            return View(db.MilitaryServices.ToList());
        }

        // GET: MilitaryServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MilitaryService militaryService = db.MilitaryServices.Find(id);
            if (militaryService == null)
            {
                return HttpNotFound();
            }
            return View(militaryService);
        }

        // GET: MilitaryServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MilitaryServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MilitaryServiceID,Options")] MilitaryService militaryService)
        {
            if (ModelState.IsValid)
            {
                db.MilitaryServices.Add(militaryService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(militaryService);
        }

        // GET: MilitaryServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MilitaryService militaryService = db.MilitaryServices.Find(id);
            if (militaryService == null)
            {
                return HttpNotFound();
            }
            return View(militaryService);
        }

        // POST: MilitaryServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MilitaryServiceID,Options")] MilitaryService militaryService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(militaryService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(militaryService);
        }

        // GET: MilitaryServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MilitaryService militaryService = db.MilitaryServices.Find(id);
            if (militaryService == null)
            {
                return HttpNotFound();
            }
            return View(militaryService);
        }

        // POST: MilitaryServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MilitaryService militaryService = db.MilitaryServices.Find(id);
            db.MilitaryServices.Remove(militaryService);
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
