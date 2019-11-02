namespace sisoC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class CivilsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Civils
        public ActionResult Index()
        {
            return View(db.Civils.ToList());
        }

        // GET: Civils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var civil = db.Civils.Find(id);

            if (civil == null)
            {
                return HttpNotFound();
            }

            return View(civil);
        }

        // GET: Civils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Civils/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Civil civil)
        {
            if (ModelState.IsValid)
            {
                db.Civils.Add(civil);

                var response =
                    DBHelper.SaveChanges(db);

                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.
                    AddModelError(
                    string.Empty,
                    response.Message);
            }

            return View(civil);
        }

        // GET: Civils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var civil = db.Civils.Find(id);

            if (civil == null)
            {
                return HttpNotFound();
            }

            return View(civil);
        }

        // POST: Civils/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Civil civil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(civil).State = 
                    EntityState.Modified;

                var response =
                    DBHelper.SaveChanges(db);

                if (response.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.
                    AddModelError(
                    string.Empty,
                    response.Message);
            }

            return View(civil);
        }

        // GET: Civils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var civil = db.Civils.Find(id);

            if (civil == null)
            {
                return HttpNotFound();
            }

            return View(civil);
        }

        // POST: Civils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Civil civil = db.Civils.Find(id);

            db.Civils.Remove(civil);

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
