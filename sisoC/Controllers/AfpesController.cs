namespace sisoC.Controllers
{
    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class AfpesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Afpes
        public ActionResult Index()
        {
            return View(db.Afpes.ToList());
        }

        // GET: Afpes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var afpe = db.Afpes.Find(id);

            if (afpe == null)
            {
                return HttpNotFound();
            }

            return View(afpe);
        }

        // GET: Afpes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Afpes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Afpe afpe)
        {
            if (ModelState.IsValid)
            {
                db.Afpes.Add(afpe);

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

            return View(afpe);
        }

        // GET: Afpes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var afpe = db.Afpes.Find(id);

            if (afpe == null)
            {
                return HttpNotFound();
            }

            return View(afpe);
        }

        // POST: Afpes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Afpe afpe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afpe).
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

            return View(afpe);
        }

        // GET: Afpes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var afpe = db.Afpes.Find(id);

            if (afpe == null)
            {
                return HttpNotFound();
            }

            return View(afpe);
        }

        // POST: Afpes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var afpe = db.Afpes.Find(id);

            db.Afpes.Remove(afpe);

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

            return View(afpe);
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
