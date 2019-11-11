namespace sisoC.Controllers
{
    using sisoC.Helpers;
    using sisoC.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class ExamenTypesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: ExamenTypes
        public ActionResult Index()
        {
            return View(db.ExamenTypes.ToList());
        }

        // GET: ExamenTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examenType = db.ExamenTypes.Find(id);

            if (examenType == null)
            {
                return HttpNotFound();
            }

            return View(examenType);
        }

        // GET: ExamenTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamenTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamenType examenType)
        {
            if (ModelState.IsValid)
            {
                db.ExamenTypes.Add(examenType);

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

            return View(examenType);
        }

        // GET: ExamenTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examenType = db.ExamenTypes.Find(id);

            if (examenType == null)
            {
                return HttpNotFound();
            }

            return View(examenType);
        }

        // POST: ExamenTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamenType examenType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examenType).State = 
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

            return View(examenType);
        }

        // GET: ExamenTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var examenType = db.ExamenTypes.Find(id);

            if (examenType == null)
            {
                return HttpNotFound();
            }

            return View(examenType);
        }

        // POST: ExamenTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var examenType = 
                db.ExamenTypes.Find(id);

            db.ExamenTypes.Remove(examenType);

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

            return View(examenType);
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
