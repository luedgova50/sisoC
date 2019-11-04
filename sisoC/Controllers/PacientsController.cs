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

    public class PacientsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Pacients
        public ActionResult Index()
        {
            var pacients = 
                db.Pacients.
                Include(p => p.Afpe).
                Include(p => p.Arpr).
                Include(p => p.City).
                Include(p => p.Civil).
                Include(p => p.DocumentType).
                Include(p => p.DriveLicense).
                Include(p => p.Epsa).
                Include(p => p.FactorRh).
                Include(p => p.Gender).
                Include(p => p.Military).
                Include(p => p.Profession).
                Include(p => p.SchoolLevel).
                Include(p => p.State);

            return View(pacients.ToList());
        }

        // GET: Pacients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var pacient = db.Pacients.Find(id);

            if (pacient == null)
            {
                return HttpNotFound();
            }

            return View(pacient);
        }

        // GET: Pacients/Create
        public ActionResult Create()
        {
            ViewBag.AfpeID = 
                new SelectList(
                    db.Afpes, "AfpeID", "Description");

            ViewBag.ArprID = 
                new SelectList(
                    db.Arprs, "ArprID", "Description");

            ViewBag.CityID = 
                new SelectList(
                    db.Cities, "CityID", "Name");

            ViewBag.CivilID = 
                new SelectList(
                    db.Civils, "CivilID", "Description");

            ViewBag.DocumentTypeID = 
                new SelectList(
                    db.DocumentTypes, "DocumentTypeID", "Description");

            ViewBag.DriveLicenseID = 
                new SelectList(
                    db.DriveLicenses, "DriveLicenseID", "Description");

            ViewBag.EpsaID = 
                new SelectList(
                    db.Epsas, "EpsaID", "Description");

            ViewBag.FactorRhID = 
                new SelectList(
                    db.FactorRhs, "FactorRhID", "Description");

            ViewBag.GenderID = 
                new SelectList(
                    db.Genders, "GenderID", "Description");

            ViewBag.MilitaryServiceID = 
                new SelectList(
                    db.MilitaryServices, "MilitaryServiceID", "Options");

            ViewBag.ProfessionID = 
                new SelectList(
                    db.Professions, "ProfessionID", "Description");

            ViewBag.SchoolLevelID = 
                new SelectList(
                    db.SchoolLevels, "SchoolLevelID", "Description");

            ViewBag.StateID = 
                new SelectList(
                    db.States, "StateID", "Name");

            return View();
        }

        // POST: Pacients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Pacients.Add(pacient);

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

            ViewBag.AfpeID = 
                new SelectList(
                    db.Afpes, "AfpeID", "Description", 
                    pacient.AfpeID);

            ViewBag.ArprID = 
                new SelectList(
                    db.Arprs, "ArprID", "Description", 
                    pacient.ArprID);

            ViewBag.CityID = 
                new SelectList(
                    db.Cities, "CityID", "Name", 
                    pacient.CityID);

            ViewBag.CivilID = 
                new SelectList(
                    db.Civils, "CivilID", "Description", 
                    pacient.CivilID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    db.DocumentTypes, "DocumentTypeID", "Description", 
                    pacient.DocumentTypeID);

            ViewBag.DriveLicenseID = 
                new SelectList(
                    db.DriveLicenses, "DriveLicenseID", "Description", 
                    pacient.DriveLicenseID);

            ViewBag.EpsaID = 
                new SelectList(
                    db.Epsas, "EpsaID", "Description", 
                    pacient.EpsaID);

            ViewBag.FactorRhID = 
                new SelectList(
                    db.FactorRhs, "FactorRhID", "Description", 
                    pacient.FactorRhID);

            ViewBag.GenderID = 
                new SelectList(
                    db.Genders, "GenderID", "Description", 
                    pacient.GenderID);

            ViewBag.MilitaryServiceID = 
                new SelectList(
                    db.MilitaryServices, "MilitaryServiceID", "Options", 
                    pacient.MilitaryServiceID);

            ViewBag.ProfessionID = 
                new SelectList(
                    db.Professions, "ProfessionID", "Description", 
                    pacient.ProfessionID);

            ViewBag.SchoolLevelID = 
                new SelectList(
                    db.SchoolLevels, "SchoolLevelID", "Description", 
                    pacient.SchoolLevelID);

            ViewBag.StateID = 
                new SelectList(
                    db.States, "StateID", "Name", 
                    pacient.StateID);

            return View(pacient);
        }

        // GET: Pacients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var pacient = db.Pacients.Find(id);

            if (pacient == null)
            {
                return HttpNotFound();
            }

            ViewBag.AfpeID = 
                new SelectList(
                    db.Afpes, "AfpeID", "Description", 
                    pacient.AfpeID);

            ViewBag.ArprID = 
                new SelectList(
                    db.Arprs, "ArprID", "Description", 
                    pacient.ArprID);

            ViewBag.CityID = 
                new SelectList(
                    db.Cities, "CityID", "Name", 
                    pacient.CityID);

            ViewBag.CivilID = 
                new SelectList(
                    db.Civils, "CivilID", "Description", 
                    pacient.CivilID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    db.DocumentTypes, "DocumentTypeID", "Description", 
                    pacient.DocumentTypeID);

            ViewBag.DriveLicenseID = 
                new SelectList(
                    db.DriveLicenses, "DriveLicenseID", "Description", 
                    pacient.DriveLicenseID);

            ViewBag.EpsaID = 
                new SelectList(
                    db.Epsas, "EpsaID", "Description", 
                    pacient.EpsaID);

            ViewBag.FactorRhID = 
                new SelectList(
                    db.FactorRhs, "FactorRhID", "Description", 
                    pacient.FactorRhID);

            ViewBag.GenderID = 
                new SelectList(
                    db.Genders, "GenderID", "Description", 
                    pacient.GenderID);

            ViewBag.MilitaryServiceID = 
                new SelectList(
                    db.MilitaryServices, "MilitaryServiceID", "Options", 
                    pacient.MilitaryServiceID);

            ViewBag.ProfessionID = 
                new SelectList(
                    db.Professions, "ProfessionID", "Description", 
                    pacient.ProfessionID);

            ViewBag.SchoolLevelID = 
                new SelectList(
                    db.SchoolLevels, "SchoolLevelID", "Description", 
                    pacient.SchoolLevelID);

            ViewBag.StateID = new 
                SelectList(
                db.States, "StateID", "Name", 
                pacient.StateID);

            return View(pacient);
        }

        // POST: Pacients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pacient pacient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacient).
                    State = EntityState.Modified;

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

            ViewBag.AfpeID = 
                new SelectList(
                    db.Afpes, "AfpeID", "Description", 
                    pacient.AfpeID);

            ViewBag.ArprID = 
                new SelectList(
                    db.Arprs, "ArprID", "Description", 
                    pacient.ArprID);

            ViewBag.CityID = 
                new SelectList(
                    db.Cities, "CityID", "Name", 
                    pacient.CityID);

            ViewBag.CivilID = 
                new SelectList(
                    db.Civils, "CivilID", "Description", 
                    pacient.CivilID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    db.DocumentTypes, "DocumentTypeID", "Description", 
                    pacient.DocumentTypeID);

            ViewBag.DriveLicenseID = 
                new SelectList(
                    db.DriveLicenses, "DriveLicenseID", "Description", 
                    pacient.DriveLicenseID);

            ViewBag.EpsaID = 
                new SelectList(
                    db.Epsas, "EpsaID", "Description", 
                    pacient.EpsaID);

            ViewBag.FactorRhID = 
                new SelectList(
                    db.FactorRhs, "FactorRhID", "Description", 
                    pacient.FactorRhID);

            ViewBag.GenderID = 
                new SelectList(
                    db.Genders, "GenderID", "Description", 
                    pacient.GenderID);

            ViewBag.MilitaryServiceID = 
                new SelectList(
                    db.MilitaryServices, "MilitaryServiceID", "Options", 
                    pacient.MilitaryServiceID);

            ViewBag.ProfessionID = 
                new SelectList(
                    db.Professions, "ProfessionID", "Description", 
                    pacient.ProfessionID);

            ViewBag.SchoolLevelID = 
                new SelectList(
                    db.SchoolLevels, "SchoolLevelID", "Description", 
                    pacient.SchoolLevelID);

            ViewBag.StateID = 
                new SelectList(
                    db.States, "StateID", "Name", 
                    pacient.StateID);

            return View(pacient);
        }

        // GET: Pacients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var pacient = db.Pacients.Find(id);

            if (pacient == null)
            {
                return HttpNotFound();
            }

            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pacient pacient = 
                db.Pacients.Find(id);

            db.Pacients.Remove(pacient);

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
