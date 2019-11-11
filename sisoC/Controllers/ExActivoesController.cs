namespace sisoC.Controllers
{    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class ExActivoesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: ExActivoes
        public ActionResult Index()
        {
            return View(db.ExActivoes.ToList());
        }

        // GET: ExActivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exActivo = db.ExActivoes.Find(id);

            if (exActivo == null)
            {
                return HttpNotFound();
            }

            return View(exActivo);
        }

        // GET: ExActivoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExActivoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExActivo exActivo)
        {
            if (ModelState.IsValid)
            {
                db.ExActivoes.Add(exActivo);

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

            return View(exActivo);
        }

        // GET: ExActivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exActivo = db.ExActivoes.Find(id);

            if (exActivo == null)
            {
                return HttpNotFound();
            }

            return View(exActivo);
        }

        // POST: ExActivoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExActivo exActivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exActivo).State = 
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

            return View(exActivo);
        }

        // GET: ExActivoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exActivo = db.ExActivoes.Find(id);

            if (exActivo == null)
            {
                return HttpNotFound();
            }

            return View(exActivo);
        }

        // POST: ExActivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var exActivo = 
                db.ExActivoes.Find(id);
            db.ExActivoes.Remove(exActivo);

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

            return View(exActivo);
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
