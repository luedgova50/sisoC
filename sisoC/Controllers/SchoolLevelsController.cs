namespace sisoC.Controllers
{
    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class SchoolLevelsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: SchoolLevels
        public ActionResult Index()
        {
            return View(db.SchoolLevels.ToList());
        }

        // GET: SchoolLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var schoolLevel = 
                db.SchoolLevels.Find(id);

            if (schoolLevel == null)
            {
                return HttpNotFound();
            }

            return View(schoolLevel);
        }

        // GET: SchoolLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolLevels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SchoolLevel schoolLevel)
        {
            if (ModelState.IsValid)
            {
                db.SchoolLevels.Add(schoolLevel);

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

            return View(schoolLevel);
        }

        // GET: SchoolLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult
                    (HttpStatusCode.BadRequest);
            }

            var schoolLevel = db.SchoolLevels.Find(id);

            if (schoolLevel == null)
            {
                return HttpNotFound();
            }

            return View(schoolLevel);
        }

        // POST: SchoolLevels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SchoolLevel schoolLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolLevel).
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
            return View(schoolLevel);
        }

        // GET: SchoolLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var schoolLevel = db.SchoolLevels.Find(id);

            if (schoolLevel == null)
            {
                return HttpNotFound();
            }

            return View(schoolLevel);
        }

        // POST: SchoolLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var schoolLevel = 
                db.SchoolLevels.Find(id);

            db.SchoolLevels.Remove(schoolLevel);
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
