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
    public class L250Controller : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: L250
        public ActionResult Index()
        {
            return View(db.L250.ToList());
        }

        // GET: L250/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L250 l250 = db.L250.Find(id);
            if (l250 == null)
            {
                return HttpNotFound();
            }
            return View(l250);
        }

        // GET: L250/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: L250/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "L250ID,Values")] L250 l250)
        {
            if (ModelState.IsValid)
            {
                db.L250.Add(l250);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(l250);
        }

        // GET: L250/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L250 l250 = db.L250.Find(id);
            if (l250 == null)
            {
                return HttpNotFound();
            }
            return View(l250);
        }

        // POST: L250/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "L250ID,Values")] L250 l250)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l250).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l250);
        }

        // GET: L250/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            L250 l250 = db.L250.Find(id);
            if (l250 == null)
            {
                return HttpNotFound();
            }
            return View(l250);
        }

        // POST: L250/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            L250 l250 = db.L250.Find(id);
            db.L250.Remove(l250);
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
