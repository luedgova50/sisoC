namespace sisoC.Controllers
{
    using sisoC.Helpers;
    using sisoC.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class ProfessionsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Professions
        public ActionResult Index()
        {
            return View(db.Professions.ToList());
        }

        // GET: Professions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var profession = db.Professions.Find(id);

            if (profession == null)
            {
                return HttpNotFound();
            }

            return View(profession);
        }

        // GET: Professions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Professions.Add(profession);

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

            return View(profession);
        }

        // GET: Professions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var profession = db.Professions.Find(id);

            if (profession == null)
            {
                return HttpNotFound();
            }

            return View(profession);
        }

        // POST: Professions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession).
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

            return View(profession);
        }

        // GET: Professions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var profession = db.Professions.Find(id);

            if (profession == null)
            {
                return HttpNotFound();
            }

            return View(profession);
        }

        // POST: Professions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profession profession = 
                db.Professions.Find(id);

            db.Professions.Remove(profession);

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
