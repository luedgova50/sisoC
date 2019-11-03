namespace sisoC.Controllers
{
    using sisoC.Helpers;
    using sisoC.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class FactorRhsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: FactorRhs
        public ActionResult Index()
        {
            return View(db.FactorRhs.ToList());
        }

        // GET: FactorRhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var factorRh = db.FactorRhs.Find(id);

            if (factorRh == null)
            {
                return HttpNotFound();
            }

            return View(factorRh);
        }

        // GET: FactorRhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FactorRhs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FactorRh factorRh)
        {
            if (ModelState.IsValid)
            {
                db.FactorRhs.Add(factorRh);

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

            return View(factorRh);
        }

        // GET: FactorRhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var factorRh = db.FactorRhs.Find(id);

            if (factorRh == null)
            {
                return HttpNotFound();
            }

            return View(factorRh);
        }

        // POST: FactorRhs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FactorRh factorRh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factorRh).State = 
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

            return View(factorRh);
        }

        // GET: FactorRhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var factorRh = db.FactorRhs.Find(id);

            if (factorRh == null)
            {
                return HttpNotFound();
            }

            return View(factorRh);
        }

        // POST: FactorRhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FactorRh factorRh = 
                db.FactorRhs.Find(id);

            db.FactorRhs.Remove(factorRh);

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
