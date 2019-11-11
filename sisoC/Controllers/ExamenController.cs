namespace sisoC.Controllers
{    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using PagedList;
    using sisoC.Helpers;
    using sisoC.Models;

    public class ExamenController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Examen
        public ActionResult Index(int? page = null)
        {
            var examen = 
                db.Examen.
                Include(e => e.Enterprise).
                Include(e => e.ExActivo).
                Include(e => e.ExamenLevel).
                Include(e => e.ExamenType).
                Include(e => e.ExFono).
                Include(e => e.ExMedico).
                Include(e => e.ExOpto).
                Include(e => e.ExPsico).
                Include(e => e.OtherExam).
                Include(e => e.Pacient);

            page = (page ?? 1);

            return View(db.Examen.
                OrderBy(ex => ex.Date).
                ToPagedList((int)page, 6));
        }

        // GET: Examen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examen = db.Examen.Find(id);

            if (examen == null)
            {
                return HttpNotFound();
            }

            return View(examen);
        }

        // GET: Examen/Create
        public ActionResult Create()
        {
            ViewBag.EnterpriseID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEnterprises(), 
                    "EnterpriseID", 
                    "Document");

            ViewBag.ExActivoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetActivoes(), 
                    "ExActivoID", 
                    "Description");

            ViewBag.ExamenLevelID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetELevels(), 
                    "ExamenLevelID", 
                    "Description");

            ViewBag.ExamenTypeID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetETypes(), 
                    "ExamenTypeID", 
                    "Description");

            ViewBag.ExFonoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEFonos(), 
                    "ExFonoID", 
                    "Description");

            ViewBag.ExMedicoID = 
                new SelectList(
                    ComboBoxStateHelper
                    .GetEMedicos(), 
                    "ExMedicoID", 
                    "Description");

            ViewBag.ExOptoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEOptos(), 
                    "ExOptoID", 
                    "Description");

            ViewBag.ExPsicoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEPsicos(), 
                    "ExPsicoID", 
                    "Description");

            ViewBag.OtherExamID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetOthers(), 
                    "OtherExamID", 
                    "Description");

            ViewBag.PacientID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetPacients(), 
                    "PacientID", 
                    "Document");

            return View();
        }

        // POST: Examen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Examen.Add(examen);

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

            ViewBag.EnterpriseID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEnterprises(), 
                    "EnterpriseID", 
                    "Document", 
                    examen.EnterpriseID);

            ViewBag.ExActivoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetActivoes(), 
                    "ExActivoID", 
                    "Description", 
                    examen.ExActivoID);

            ViewBag.ExamenLevelID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetELevels(), 
                    "ExamenLevelID", 
                    "Description", 
                    examen.ExamenLevelID);

            ViewBag.ExamenTypeID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetETypes(), 
                    "ExamenTypeID", 
                    "Description", 
                    examen.ExamenTypeID);

            ViewBag.ExFonoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEFonos(), 
                    "ExFonoID", 
                    "Description", 
                    examen.ExFonoID);

            ViewBag.ExMedicoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEMedicos(), 
                    "ExMedicoID", 
                    "Description", 
                    examen.ExMedicoID);

            ViewBag.ExOptoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEOptos(), 
                    "ExOptoID", 
                    "Description", 
                    examen.ExOptoID);

            ViewBag.ExPsicoID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetEPsicos(), 
                    "ExPsicoID", 
                    "Description", 
                    examen.ExPsicoID);

            ViewBag.OtherExamID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetOthers(), 
                    "OtherExamID", 
                    "Description", 
                    examen.OtherExamID);

            ViewBag.PacientID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetPacients(), 
                    "PacientID", 
                    "Document", 
                    examen.PacientID);

            return View(examen);
        }

        // GET: Examen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examen = db.Examen.Find(id);

            if (examen == null)
            {
                return HttpNotFound();
            }

            ViewBag.EnterpriseID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEnterprises(),
                    "EnterpriseID",
                    "Document",
                    examen.EnterpriseID);

            ViewBag.ExActivoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetActivoes(),
                    "ExActivoID",
                    "Description",
                    examen.ExActivoID);

            ViewBag.ExamenLevelID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetELevels(),
                    "ExamenLevelID",
                    "Description",
                    examen.ExamenLevelID);

            ViewBag.ExamenTypeID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetETypes(),
                    "ExamenTypeID",
                    "Description",
                    examen.ExamenTypeID);

            ViewBag.ExFonoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEFonos(),
                    "ExFonoID",
                    "Description",
                    examen.ExFonoID);

            ViewBag.ExMedicoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEMedicos(),
                    "ExMedicoID",
                    "Description",
                    examen.ExMedicoID);

            ViewBag.ExOptoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEOptos(),
                    "ExOptoID",
                    "Description",
                    examen.ExOptoID);

            ViewBag.ExPsicoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEPsicos(),
                    "ExPsicoID",
                    "Description",
                    examen.ExPsicoID);

            ViewBag.OtherExamID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetOthers(),
                    "OtherExamID",
                    "Description",
                    examen.OtherExamID);

            ViewBag.PacientID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetPacients(),
                    "PacientID",
                    "Document",
                    examen.PacientID);

            return View(examen);
        }

        // POST: Examen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examen).State = 
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

            ViewBag.EnterpriseID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEnterprises(),
                    "EnterpriseID",
                    "Document",
                    examen.EnterpriseID);

            ViewBag.ExActivoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetActivoes(),
                    "ExActivoID",
                    "Description",
                    examen.ExActivoID);

            ViewBag.ExamenLevelID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetELevels(),
                    "ExamenLevelID",
                    "Description",
                    examen.ExamenLevelID);

            ViewBag.ExamenTypeID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetETypes(),
                    "ExamenTypeID",
                    "Description",
                    examen.ExamenTypeID);

            ViewBag.ExFonoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEFonos(),
                    "ExFonoID",
                    "Description",
                    examen.ExFonoID);

            ViewBag.ExMedicoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEMedicos(),
                    "ExMedicoID",
                    "Description",
                    examen.ExMedicoID);

            ViewBag.ExOptoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEOptos(),
                    "ExOptoID",
                    "Description",
                    examen.ExOptoID);

            ViewBag.ExPsicoID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetEPsicos(),
                    "ExPsicoID",
                    "Description",
                    examen.ExPsicoID);

            ViewBag.OtherExamID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetOthers(),
                    "OtherExamID",
                    "Description",
                    examen.OtherExamID);

            ViewBag.PacientID =
                new SelectList(
                    ComboBoxStateHelper.
                    GetPacients(),
                    "PacientID",
                    "Document",
                    examen.PacientID);

            return View(examen);
        }

        // GET: Examen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examen = db.Examen.Find(id);

            if (examen == null)
            {
                return HttpNotFound();
            }

            return View(examen);
        }

        // POST: Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var examen = db.Examen.Find(id);

            db.Examen.Remove(examen);

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

            return View(examen);
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
