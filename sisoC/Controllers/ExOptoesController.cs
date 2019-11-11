namespace sisoC.Controllers
{    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class ExOptoesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: ExOptoes
        public ActionResult Index()
        {
            return View(db.ExOptoes.ToList());
        }

        // GET: ExOptoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exOpto = db.ExOptoes.Find(id);

            if (exOpto == null)
            {
                return HttpNotFound();
            }

            return View(exOpto);
        }

        // GET: ExOptoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExOptoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExOpto exOpto)
        {
            if (ModelState.IsValid)
            {
                db.ExOptoes.Add(exOpto);

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

            return View(exOpto);
        }

        // GET: ExOptoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exOpto = db.ExOptoes.Find(id);

            if (exOpto == null)
            {
                return HttpNotFound();
            }

            return View(exOpto);
        }

        // POST: ExOptoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExOpto exOpto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exOpto).State = 
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

            return View(exOpto);
        }

        // GET: ExOptoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exOpto = db.ExOptoes.Find(id);

            if (exOpto == null)
            {
                return HttpNotFound();
            }

            return View(exOpto);
        }

        // POST: ExOptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var exOpto = 
                db.ExOptoes.Find(id);

            db.ExOptoes.Remove(exOpto);

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

            return View(exOpto);
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
