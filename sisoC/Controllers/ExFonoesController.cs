namespace sisoC.Controllers
{    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class ExFonoesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: ExFonoes
        public ActionResult Index()
        {
            return View(db.ExFonoes.ToList());
        }

        // GET: ExFonoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exFono = db.ExFonoes.Find(id);

            if (exFono == null)
            {
                return HttpNotFound();
            }

            return View(exFono);
        }

        // GET: ExFonoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExFonoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExFono exFono)
        {
            if (ModelState.IsValid)
            {
                db.ExFonoes.Add(exFono);

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

            return View(exFono);
        }

        // GET: ExFonoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exFono = db.ExFonoes.Find(id);

            if (exFono == null)
            {
                return HttpNotFound();
            }

            return View(exFono);
        }

        // POST: ExFonoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExFono exFono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exFono).State = 
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

            return View(exFono);
        }

        // GET: ExFonoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exFono = db.ExFonoes.Find(id);

            if (exFono == null)
            {
                return HttpNotFound();
            }

            return View(exFono);
        }

        // POST: ExFonoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var exFono = db.ExFonoes.Find(id);

            db.ExFonoes.Remove(exFono);

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

            return View(exFono);
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
