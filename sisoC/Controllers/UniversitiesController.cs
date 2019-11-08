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
    using sisoC.Models;
    using PagedList;
    using sisoC.Helpers;

    public class UniversitiesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: /UniversitiesDefault1/
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);

            return View(
                db.Universities.
                OrderBy(uv => uv.Description)
                .ToPagedList((int)page, 6));
        }

        // GET: /UniversitiesDefault1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            
            var university = db.Universities.Find(id);

            if (university == null)
            {
                return HttpNotFound();
            }

            return View(university);
        }

        // GET: /UniversitiesDefault1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UniversitiesDefault1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(University university)
        {
            if (ModelState.IsValid)
            {
                db.Universities.Add(university);

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

            return View(university);
        }

        // GET: /UniversitiesDefault1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var university = db.Universities.Find(id);

            if (university == null)
            {
                return HttpNotFound();
            }

            return View(university);
        }

        // POST: /UniversitiesDefault1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(University university)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university).State = 
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

            return View(university);
        }

        // GET: /UniversitiesDefault1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var university = db.Universities.Find(id);

            if (university == null)
            {
                return HttpNotFound();
            }

            return View(university);
        }

        // POST: /UniversitiesDefault1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var university = 
                db.Universities.Find(id);

            db.Universities.Remove(university);

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

            return View(university);
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
