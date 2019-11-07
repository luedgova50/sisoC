namespace sisoC.Controllers
{
    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.UI.WebControls;
    using sisoC.Helpers;
    using sisoC.Models;
    using PagedList;

    public class PacientsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Pacients
        public ActionResult Index(int? page = null)
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

            page = (page ?? 1);

            return View(db.Pacients.OrderBy(
                pc => pc.FirstName).
                ThenBy(pc => pc.LastName)
                .ToPagedList((int)page, 6));
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
                    ComboBoxStateHelper.GetAfpes(), 
                    "AfpeID", "Description");

            ViewBag.ArprID = 
                new SelectList(
                    ComboBoxStateHelper.GetArps(), 
                    "ArprID", "Description");

            ViewBag.CityID = 
                new SelectList(
                    ComboBoxStateHelper.GetCities(0), 
                    "CityID", "Name");

            ViewBag.CivilID = 
                new SelectList(
                    ComboBoxStateHelper.GetCivils(), 
                    "CivilID", "Description");

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.GetDocumentTypes(), 
                    "DocumentTypeID", "Description");

            ViewBag.DriveLicenseID = 
                new SelectList(
                    ComboBoxStateHelper.GetLicenses(), 
                    "DriveLicenseID", "Description");

            ViewBag.EpsaID = 
                new SelectList(
                    ComboBoxStateHelper.GetEpsas(), 
                    "EpsaID", "Description");

            ViewBag.FactorRhID = 
                new SelectList(
                    ComboBoxStateHelper.GetFactors(), 
                    "FactorRhID", "Description");

            ViewBag.GenderID = 
                new SelectList(
                    ComboBoxStateHelper.GetGenders(), 
                    "GenderID", "Description");

            ViewBag.MilitaryServiceID = 
                new SelectList(
                    ComboBoxStateHelper.GetMilitaries(), 
                    "MilitaryServiceID", "Options");

            ViewBag.ProfessionID = 
                new SelectList(
                    ComboBoxStateHelper.GetProfessions(), 
                    "ProfessionID", "Description");

            ViewBag.SchoolLevelID = 
                new SelectList(
                    ComboBoxStateHelper.GetLevels(), 
                    "SchoolLevelID", "Description");

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.GetStates(), 
                    "StateID", "Name");

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
                                                
                if (pacient.PhotoFile != null)
                {                   

                    var folder = "~/Content/Photos";

                    var file = string.Format("{0}.jpg",
                            pacient.PacientID);

                    var response2 =
                        FileImageUpLoad.
                        UploadPhoto(
                            pacient.
                            PhotoFile,
                            folder, 
                            file);

                    if (response2)
                    {
                        var pic = string.
                          Format("{0}/{1}",
                          folder, file);

                        pacient.Photo = pic;

                        db.Entry(pacient).State = 
                            EntityState.Modified;

                        db.SaveChanges();
                    }
                }                              

                if (pacient.FirmFile != null)
                {
                    var folder2 = "~/Content/Firms";

                    var file2 = string.Format("{0}.jpg",
                            pacient.PacientID);

                    var response3 =
                        FileImageUpLoad.
                        UploadPhoto(
                            pacient.
                            FirmFile,
                            folder2, 
                            file2);

                    if (response3)
                    {
                        var pic2 = string.
                          Format("{0}/{1}",
                          folder2, file2);

                        pacient.Firm = pic2;

                        db.Entry(pacient).State =
                            EntityState.Modified;

                       db.SaveChanges();
                    }
                }

               
            }

            ViewBag.AfpeID = 
                new SelectList(
                    ComboBoxStateHelper.GetAfpes(), 
                    "AfpeID", "Description", 
                    pacient.AfpeID);

            ViewBag.ArprID = 
                new SelectList(
                    ComboBoxStateHelper.GetArps(), 
                    "ArprID", "Description", 
                    pacient.ArprID);

            ViewBag.CityID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(pacient.StateID), 
                    "CityID", "Name", 
                    pacient.CityID);

            ViewBag.CivilID = 
                new SelectList(
                    ComboBoxStateHelper.GetCivils(), 
                    "CivilID", "Description", 
                    pacient.CivilID);

            ViewBag.DocumentTypeID = 
                new SelectList(
                    ComboBoxStateHelper.GetDocumentTypes(), 
                    "DocumentTypeID", "Description", 
                    pacient.DocumentTypeID);

            ViewBag.DriveLicenseID = 
                new SelectList(
                    ComboBoxStateHelper.GetLicenses(), 
                    "DriveLicenseID", "Description", 
                    pacient.DriveLicenseID);

            ViewBag.EpsaID = 
                new SelectList(
                    ComboBoxStateHelper.GetEpsas(), 
                    "EpsaID", "Description", 
                    pacient.EpsaID);

            ViewBag.FactorRhID = 
                new SelectList(
                    ComboBoxStateHelper.GetFactors(), 
                    "FactorRhID", "Description", 
                    pacient.FactorRhID);

            ViewBag.GenderID = 
                new SelectList(
                    ComboBoxStateHelper.GetGenders(), 
                    "GenderID", "Description", 
                    pacient.GenderID);

            ViewBag.MilitaryServiceID = 
                new SelectList(
                    ComboBoxStateHelper.GetMilitaries(), 
                    "MilitaryServiceID", "Options", 
                    pacient.MilitaryServiceID);

            ViewBag.ProfessionID = 
                new SelectList(
                    ComboBoxStateHelper.GetProfessions(), 
                    "ProfessionID", "Description", 
                    pacient.ProfessionID);

            ViewBag.SchoolLevelID = 
                new SelectList(
                    ComboBoxStateHelper.GetLevels(), 
                    "SchoolLevelID", "Description", 
                    pacient.SchoolLevelID);

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.GetStates(), 
                    "StateID", "Name", 
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
                    ComboBoxStateHelper.GetAfpes(), 
                    "AfpeID", "Description",
                    pacient.AfpeID);

            ViewBag.ArprID =
                new SelectList(
                    ComboBoxStateHelper.GetArps(), 
                    "ArprID", "Description",
                    pacient.ArprID);

            ViewBag.CityID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(pacient.StateID), 
                    "CityID", "Name",
                    pacient.CityID);

            ViewBag.CivilID =
                new SelectList(
                    ComboBoxStateHelper.GetCivils(), 
                    "CivilID", "Description",
                    pacient.CivilID);

            ViewBag.DocumentTypeID =
                new SelectList(
                    ComboBoxStateHelper.GetDocumentTypes(), 
                    "DocumentTypeID", "Description",
                    pacient.DocumentTypeID);

            ViewBag.DriveLicenseID =
                new SelectList(
                    ComboBoxStateHelper.GetLicenses(), 
                    "DriveLicenseID", "Description",
                    pacient.DriveLicenseID);

            ViewBag.EpsaID =
                new SelectList(
                    ComboBoxStateHelper.GetEpsas(), 
                    "EpsaID", "Description",
                    pacient.EpsaID);

            ViewBag.FactorRhID =
                new SelectList(
                    ComboBoxStateHelper.GetFactors(), 
                    "FactorRhID", "Description",
                    pacient.FactorRhID);

            ViewBag.GenderID =
                new SelectList(
                    ComboBoxStateHelper.GetGenders(), 
                    "GenderID", "Description",
                    pacient.GenderID);

            ViewBag.MilitaryServiceID =
                new SelectList(
                    ComboBoxStateHelper.GetMilitaries(), 
                    "MilitaryServiceID", "Options",
                    pacient.MilitaryServiceID);

            ViewBag.ProfessionID =
                new SelectList(
                    ComboBoxStateHelper.GetProfessions(), 
                    "ProfessionID", "Description",
                    pacient.ProfessionID);

            ViewBag.SchoolLevelID =
                new SelectList(
                    ComboBoxStateHelper.GetLevels(), 
                    "SchoolLevelID", "Description",
                    pacient.SchoolLevelID);

            ViewBag.StateID =
                new SelectList(
                    ComboBoxStateHelper.GetStates(), 
                    "StateID", "Name",
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

                if (pacient.PhotoFile != null)
                {                  

                    var folder = "~/Content/Photos";

                    var file = string.Format("{0}.jpg", pacient.PacientID);

                    var response2 =
                        FileImageUpLoad.
                        UploadPhoto(
                            pacient.
                            PhotoFile,
                            folder,
                            file);

                    if (response2)
                    {
                        var pic = string.Format("{0}/{1}",
                          folder, file);

                        pacient.Photo = pic;
                    }
                } 

                if (pacient.FirmFile != null)
                {                    
                    var folder2 = "~/Content/Firms";

                    var file2 = 
                        string.Format("{0}.jpg", 
                        pacient.PacientID);

                    var response3 =
                        FileImageUpLoad.
                        UploadPhoto(
                            pacient.
                            FirmFile,
                            folder2,
                            file2);

                    if (response3)
                    {
                        var pic2 = string.Format("{0}/{1}",
                        folder2, file2);

                        pacient.Firm = pic2;
                    }
                }
                
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
                    ComboBoxStateHelper.GetAfpes(), 
                    "AfpeID", "Description",
                    pacient.AfpeID);

            ViewBag.ArprID =
                new SelectList(
                    ComboBoxStateHelper.GetArps(), 
                    "ArprID", "Description",
                    pacient.ArprID);

            ViewBag.CityID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetCities(pacient.StateID), 
                    "CityID", "Name",
                    pacient.CityID);

            ViewBag.CivilID =
                new SelectList(
                    ComboBoxStateHelper.GetCivils(), 
                    "CivilID", "Description",
                    pacient.CivilID);

            ViewBag.DocumentTypeID =
                new SelectList(
                    ComboBoxStateHelper.GetDocumentTypes(), 
                    "DocumentTypeID", "Description",
                    pacient.DocumentTypeID);

            ViewBag.DriveLicenseID =
                new SelectList(
                    ComboBoxStateHelper.GetLicenses(), 
                    "DriveLicenseID", "Description",
                    pacient.DriveLicenseID);

            ViewBag.EpsaID =
                new SelectList(
                    ComboBoxStateHelper.GetEpsas(), 
                    "EpsaID", "Description",
                    pacient.EpsaID);

            ViewBag.FactorRhID =
                new SelectList(
                    ComboBoxStateHelper.GetFactors(), 
                    "FactorRhID", "Description",
                    pacient.FactorRhID);

            ViewBag.GenderID =
                new SelectList(
                    ComboBoxStateHelper.GetGenders(), 
                    "GenderID", "Description",
                    pacient.GenderID);

            ViewBag.MilitaryServiceID =
                new SelectList(
                    ComboBoxStateHelper.GetMilitaries(), 
                    "MilitaryServiceID", "Options",
                    pacient.MilitaryServiceID);

            ViewBag.ProfessionID =
                new SelectList(
                    ComboBoxStateHelper.GetProfessions(), 
                    "ProfessionID", "Description",
                    pacient.ProfessionID);

            ViewBag.SchoolLevelID =
                new SelectList(
                    ComboBoxStateHelper.GetLevels(), 
                    "SchoolLevelID", "Description",
                    pacient.SchoolLevelID);

            ViewBag.StateID =
                new SelectList(
                    ComboBoxStateHelper.GetStates(), 
                    "StateID", "Name",
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
            var pacient = 
                db.Pacients.Find(id);

            db.Pacients.Remove(pacient);

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

            return View(pacient);
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
