namespace sisoC.Controllers
{
    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using PagedList;
    using sisoC.Helpers;
    using sisoC.Models;

    public class ExamenLevelsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: ExamenLevels
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);

            return View(db.ExamenLevels.
                OrderBy(ne => ne.Description)
                .ToPagedList((int)page, 6));
        }

        // GET: ExamenLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examenLevel = db.ExamenLevels.Find(id);

            if (examenLevel == null)
            {
                return HttpNotFound();
            }

            return View(examenLevel);
        }

        // GET: ExamenLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamenLevels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamenLevel examenLevel)
        {
            if (ModelState.IsValid)
            {
                db.ExamenLevels.Add(examenLevel);

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

            return View(examenLevel);
        }

        // GET: ExamenLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examenLevel = db.ExamenLevels.Find(id);

            if (examenLevel == null)
            {
                return HttpNotFound();
            }

            return View(examenLevel);
        }

        // POST: ExamenLevels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamenLevel examenLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenLevel).State = 
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

            return View(examenLevel);
        }

        // GET: ExamenLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examenLevel = db.ExamenLevels.Find(id);

            if (examenLevel == null)
            {
                return HttpNotFound();
            }

            return View(examenLevel);
        }

        // POST: ExamenLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var examenLevel = db.ExamenLevels.Find(id);

            db.ExamenLevels.Remove(examenLevel);

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

            return View(examenLevel);
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
