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
    using PagedList;

    public class UsersController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: /Users/
        public ActionResult Index(int? page = null)
        {
            var users = 
                db.Users.
                Include(u => u.City).
                Include(u => u.DocumentType).
                Include(u => u.State);

            page = (page ?? 1);

            return View(
                db
                .Users.OrderBy(
            us => us.FirstName).
            ThenBy(us => us.LastName)
            .ToPagedList((int)page, 6));
        }

        // GET: /Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var users = db.Users.Find(id);

            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // GET: /Users/Create
        public ActionResult Create()
        {
            ViewBag.CityID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(0), 
                    "CityID", "Name");

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
                    "StateID", "Name");

            return View();
        }

        // POST: /Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Users users)
        {
            if (ModelState.IsValid)
            {
                if (users.PhotoUsersFile != null)
                {
                    //var pic = string.Empty;

                    var folder = "~/Content/Users";

                    var file = string.Format("{0}.jpg",
                            users.UsersID);

                    var response2 =
                        FileImageUpLoad.
                        UploadPhoto(
                            users.PhotoUsersFile,
                            folder,
                            file);

                    if (response2)
                    {
                        var pic = string.
                          Format("{0}/{1}",
                          folder, file);

                        users.PhotoUsers = pic;

                        db.Entry(users).State =
                            EntityState.Modified;

                        //db.SaveChanges();
                    }
                }

                if (users.FirmUsersFile != null)
                {
                    //var pic2 = string.Empty;

                    var folder2 = "~/Content/FirmUsers";

                    var file = string.Format("{0}.jpg",
                            users.UsersID);

                    var response2 =
                        FileImageUpLoad.
                        UploadPhoto(
                            users.FirmUsersFile,
                            folder2,
                            file);

                    if (response2)
                    {
                        var pic2 = string.
                          Format("{0}/{1}",
                          folder2, file);

                        users.FirmUsers = pic2;

                        db.Entry(users).State =
                            EntityState.Modified;

                        // db.SaveChanges();
                    }
                }

                db.Users.Add(users);

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
                    GetCities(users.StateID), 
                    "CityID", 
                    "Name", 
                    users.CityID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetDocumentTypes(), 
                    "DocumentTypeID", 
                    "Description", 
                    users.DocumentTypeID);

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.GetStates(), 
                    "StateID", 
                    "Name", 
                    users.StateID);

            return View(users);
        }

        // GET: /Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var users = db.Users.Find(id);

            if (users == null)
            {
                return HttpNotFound();
            }

            ViewBag.CityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(users.StateID), 
                    "CityID", 
                    "Name", 
                    users.CityID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.GetDocumentTypes(), 
                    "DocumentTypeID", 
                    "Description", 
                    users.DocumentTypeID);

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.GetStates(), 
                    "StateID", 
                    "Name", 
                    users.StateID);

            return View(users);

        }

        // POST: /Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                if (users.PhotoUsersFile != null)
                {
                    //var pic = string.Empty;

                    var folder = "~/Content/Users";

                    var file = string.Format("{0}.jpg",
                            users.UsersID);

                    var response2 =
                        FileImageUpLoad.
                        UploadPhoto(
                            users.PhotoUsersFile,
                            folder,
                            file);

                    if (response2)
                    {
                        var pic = string.
                          Format("{0}/{1}",
                          folder, file);

                        users.PhotoUsers = pic;

                        db.Entry(users).State =
                            EntityState.Modified;

                        //db.SaveChanges();
                    }
                }

                if (users.FirmUsersFile != null)
                {
                    //var pic2 = string.Empty;

                    var folder2 = "~/Content/FirmUsers";

                    var file = string.Format("{0}.jpg",
                            users.UsersID);

                    var response2 =
                        FileImageUpLoad.
                        UploadPhoto(
                            users.FirmUsersFile,
                            folder2,
                            file);

                    if (response2)
                    {
                        var pic2 = string.
                          Format("{0}/{1}",
                          folder2, file);

                        users.FirmUsers = pic2;

                        db.Entry(users).State =
                            EntityState.Modified;

                        // db.SaveChanges();
                    }
                }

                db.Entry(users).State = 
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
                    GetCities(users.StateID), 
                    "CityID", 
                    "Name", 
                    users.CityID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.GetDocumentTypes(), 
                    "DocumentTypeID", 
                    "Description", 
                    users.DocumentTypeID);

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.GetStates(), 
                    "StateID", 
                    "Name", 
                    users.StateID);

            return View(users);
        }

        // GET: /Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var users = db.Users.Find(id);

            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var users = db.Users.Find(id);

            db.Users.Remove(users);

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

            return View(users);
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
