namespace sisoC.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class DriveLicensesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: DriveLicenses
        public ActionResult Index()
        {
            return View(db.DriveLicenses.ToList());
        }

        // GET: DriveLicenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
           
            var driveLicense = 
                db.DriveLicenses.Find(id);

            if (driveLicense == null)
            {
                return HttpNotFound();
            }

            return View(driveLicense);
        }

        // GET: DriveLicenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriveLicenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DriveLicense driveLicense)
        {
            if (ModelState.IsValid)
            {
                db.DriveLicenses.
                    Add(driveLicense);

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

            return View(driveLicense);
        }

        // GET: DriveLicenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var driveLicense = 
                db.DriveLicenses.Find(id);

            if (driveLicense == null)
            {
                return HttpNotFound();
            }

            return View(driveLicense);
        }

        // POST: DriveLicenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DriveLicense driveLicense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driveLicense).
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

            return View(driveLicense);
        }

        // GET: DriveLicenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var driveLicense = 
                db.DriveLicenses.Find(id);

            if (driveLicense == null)
            {
                return HttpNotFound();
            }

            return View(driveLicense);
        }

        // POST: DriveLicenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var driveLicense = 
                db.DriveLicenses.Find(id);

            db.DriveLicenses.Remove(driveLicense);

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
