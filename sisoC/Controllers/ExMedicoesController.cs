namespace sisoC.Controllers
{    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class ExMedicoesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: ExMedicoes
        public ActionResult Index()
        {
            return View(db.ExMedicoes.ToList());
        }

        // GET: ExMedicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exMedico = db.ExMedicoes.Find(id);

            if (exMedico == null)
            {
                return HttpNotFound();
            }

            return View(exMedico);
        }

        // GET: ExMedicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExMedicoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExMedico exMedico)
        {
            if (ModelState.IsValid)
            {
                db.ExMedicoes.Add(exMedico);

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

            return View(exMedico);
        }

        // GET: ExMedicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exMedico = db.ExMedicoes.Find(id);

            if (exMedico == null)
            {
                return HttpNotFound();
            }

            return View(exMedico);
        }

        // POST: ExMedicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExMedico exMedico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exMedico).State = 
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

            return View(exMedico);
        }

        // GET: ExMedicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exMedico = db.ExMedicoes.Find(id);

            if (exMedico == null)
            {
                return HttpNotFound();
            }

            return View(exMedico);
        }

        // POST: ExMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var exMedico = 
                db.ExMedicoes.Find(id);

            db.ExMedicoes.Remove(exMedico);

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

            return View(exMedico);
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
