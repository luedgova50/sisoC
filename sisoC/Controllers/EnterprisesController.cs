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

    public class EnterprisesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: /Enterprises/
        public ActionResult Index(int? page = null)
        {
            var enterprises = 
                db.Enterprises.
                Include(e => e.City).
                Include(e => e.DocumentType).
                Include(e => e.State);

            page = (page ?? 1);

            return View(
                db.Enterprises.
                OrderBy(en => en.BusinessName)
                .ToPagedList((int)page, 6));
        }

        // GET: /Enterprises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var enterprise = db.Enterprises.Find(id);

            if (enterprise == null)
            {
                return HttpNotFound();
            }

            return View(enterprise);
        }

        // GET: /Enterprises/Create
        public ActionResult Create()
        {
            ViewBag.CityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(0), 
                    "CityID", 
                    "Name");

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetDocumentTypes(), 
                    "DocumentTypeID", 
                    "Description");

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetStates(), 
                    "StateID", 
                    "Name");

            return View();
        }

        // POST: /Enterprises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Enterprises.Add(enterprise);

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

            ViewBag.CityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(
                    enterprise.StateID), 
                    "CityID", 
                    "Name", 
                    enterprise.CityID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetDocumentTypes(), 
                    "DocumentTypeID", 
                    "Description", 
                    enterprise.DocumentTypeID);

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetStates(), 
                    "StateID", 
                    "Name", 
                    enterprise.StateID);

            return View(enterprise);
        }

        // GET: /Enterprises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var enterprise = db.Enterprises.Find(id);

            if (enterprise == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(
                    enterprise.StateID), 
                    "CityID", 
                    "Name", 
                    enterprise.CityID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetDocumentTypes(), 
                    "DocumentTypeID", 
                    "Description", 
                    enterprise.DocumentTypeID);

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetStates(), 
                    "StateID", 
                    "Name", 
                    enterprise.StateID);

            return View(enterprise);
        }

        // POST: /Enterprises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Enterprise enterprise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enterprise).State = 
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

            ViewBag.CityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(
                    enterprise.StateID), 
                    "CityID", 
                    "Name", 
                    enterprise.CityID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetDocumentTypes(), 
                    "DocumentTypeID", 
                    "Description", 
                    enterprise.DocumentTypeID);

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetStates(), 
                    "StateID", 
                    "Name", 
                    enterprise.StateID);

            return View(enterprise);
        }

        // GET: /Enterprises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var enterprise = db.Enterprises.Find(id);

            if (enterprise == null)
            {
                return HttpNotFound();
            }

            return View(enterprise);
        }

        // POST: /Enterprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var enterprise = 
                db.Enterprises.Find(id);

            db.Enterprises.Remove(enterprise);

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

            return View(enterprise);
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
