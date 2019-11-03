namespace sisoC.Controllers
{
    using sisoC.Helpers;
    using sisoC.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class ArprsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Arprs
        public ActionResult Index()
        {
            return View(db.Arprs.ToList());
        }

        // GET: Arprs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var arpr = db.Arprs.Find(id);

            if (arpr == null)
            {
                return HttpNotFound();
            }

            return View(arpr);
        }

        // GET: Arprs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arprs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Arpr arpr)
        {
            if (ModelState.IsValid)
            {
                db.Arprs.Add(arpr);

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

            return View(arpr);
        }

        // GET: Arprs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var arpr = db.Arprs.Find(id);

            if (arpr == null)
            {
                return HttpNotFound();
            }

            return View(arpr);
        }

        // POST: Arprs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Arpr arpr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arpr).
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
            return View(arpr);
        }

        // GET: Arprs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var arpr = db.Arprs.Find(id);

            if (arpr == null)
            {
                return HttpNotFound();
            }

            return View(arpr);
        }

        // POST: Arprs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arpr arpr = db.Arprs.Find(id);

            db.Arprs.Remove(arpr);

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
