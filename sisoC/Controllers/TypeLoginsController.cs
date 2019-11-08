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
    using sisoC.Helpers;

    public class TypeLoginsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: /TypeLogins/
        public ActionResult Index()
        {
            var typelogins = 
                db.TypeLogins.
                Include(t => t.University).
                Include(t => t.UserRoles).
                Include(t => t.Users);

            return View(typelogins.ToList());
        }

        // GET: /TypeLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var typelogin = db.TypeLogins.Find(id);

            if (typelogin == null)
            {
                return HttpNotFound();
            }

            return View(typelogin);
        }

        // GET: /TypeLogins/Create
        public ActionResult Create()
        {
            ViewBag.UniversityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetUniversities(), 
                    "UniversityID", 
                    "Description");

            ViewBag.UserRolesID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetRoles(), 
                    "UserRolesID", 
                    "Description");

            ViewBag.UsersID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetUsers(), 
                    "UsersID", 
                    "UserName");

            return View();
        }

        // POST: /TypeLogins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TypeLogin typelogin)
        {
            if (ModelState.IsValid)
            {
                db.TypeLogins.Add(typelogin);

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

                if (typelogin.FirmLoginFile != null)
                {                    
                    var folder3 = "~/Content/FirmAcces";

                    var file4 = string.Format("{0}.jpg",
                            typelogin.TypeLoginID);

                    var response4 =
                        FileImageUpLoad.
                        UploadPhoto(
                            typelogin.FirmLoginFile,
                            folder3,
                            file4);

                    if (response4)
                    {
                        var pic4 = string.
                          Format("{0}/{1}",
                          folder3, file4);

                        typelogin.FirmLogin = pic4;

                        db.Entry(typelogin).State =
                            EntityState.Modified;

                        db.SaveChanges();
                    }
                }
            }

            ViewBag.UniversityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetUniversities(), 
                    "UniversityID", 
                    "Description", 
                    typelogin.UniversityID);

            ViewBag.UserRolesID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetRoles(), 
                    "UserRolesID", 
                    "Description", 
                    typelogin.UserRolesID);

            ViewBag.UsersID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetUsers(), 
                    "UsersID", 
                    "UserName", 
                    typelogin.UsersID);

            return View(typelogin);
        }

        // GET: /TypeLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var typelogin = db.TypeLogins.Find(id);

            if (typelogin == null)
            {
                return HttpNotFound();
            }

            ViewBag.UniversityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetUniversities(), 
                    "UniversityID", 
                    "Description", 
                    typelogin.UniversityID);

            ViewBag.UserRolesID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetRoles(), 
                    "UserRolesID", 
                    "Description", 
                    typelogin.UserRolesID);

            ViewBag.UsersID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetUsers(), 
                    "UsersID", 
                    "UserName", 
                    typelogin.UsersID);

            return View(typelogin);
        }

        // POST: /TypeLogins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeLogin typelogin)
        {
            if (ModelState.IsValid)
            {
                if (typelogin.FirmLoginFile != null)
                {
                    var folder3 = "~/Content/FirmAcces";

                    var file4 = string.Format("{0}.jpg",
                            typelogin.TypeLoginID);

                    var response4 =
                        FileImageUpLoad.
                        UploadPhoto(
                            typelogin.FirmLoginFile,
                            folder3,
                            file4);

                    if (response4)
                    {
                        var pic4 = string.
                          Format("{0}/{1}",
                          folder3, file4);

                        typelogin.FirmLogin = pic4;

                        db.Entry(typelogin).State =
                            EntityState.Modified;

                        db.SaveChanges();
                    }
                }

                db.Entry(typelogin).State = 
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

            ViewBag.UniversityID = 
                new SelectList(
                    db.Universities, 
                    "UniversityID", 
                    "Description", 
                    typelogin.UniversityID);

            ViewBag.UserRolesID = 
                new SelectList(
                    db.UserRoles, 
                    "UserRolesID", 
                    "Description", 
                    typelogin.UserRolesID);

            ViewBag.UsersID = 
                new SelectList(
                    db.Users, 
                    "UsersID", 
                    "UserName", 
                    typelogin.UsersID);

            return View(typelogin);
        }

        // GET: /TypeLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var typelogin = db.TypeLogins.Find(id);

            if (typelogin == null)
            {
                return HttpNotFound();
            }

            return View(typelogin);
        }

        // POST: /TypeLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var typelogin = 
                db.TypeLogins.Find(id);

            db.TypeLogins.Remove(typelogin);

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

            return View(typelogin);
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
