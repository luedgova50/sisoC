namespace sisoC.Controllers
{
    using sisoC.Helpers;
    using sisoC.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class EpsasController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Epsas
        public ActionResult Index()
        {
            return View(db.Epsas.ToList());
        }

        // GET: Epsas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var epsa = db.Epsas.Find(id);

            if (epsa == null)
            {
                return HttpNotFound();
            }

            return View(epsa);
        }

        // GET: Epsas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Epsas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Epsa epsa)
        {
            if (ModelState.IsValid)
            {
                db.Epsas.Add(epsa);

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

            return View(epsa);
        }

        // GET: Epsas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var epsa = db.Epsas.Find(id);

            if (epsa == null)
            {
                return HttpNotFound();
            }

            return View(epsa);
        }

        // POST: Epsas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Epsa epsa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(epsa).
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

            return View(epsa);
        }

        // GET: Epsas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var epsa = db.Epsas.Find(id);

            if (epsa == null)
            {
                return HttpNotFound();
            }

            return View(epsa);
        }

        // POST: Epsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var epsa = db.Epsas.Find(id);

            db.Epsas.Remove(epsa);

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
