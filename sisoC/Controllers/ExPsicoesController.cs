namespace sisoC.Controllers
{
    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class ExPsicoesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: ExPsicoes
        public ActionResult Index()
        {
            return View(db.ExPsicoes.ToList());
        }

        // GET: ExPsicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exPsico = db.ExPsicoes.Find(id);

            if (exPsico == null)
            {
                return HttpNotFound();
            }

            return View(exPsico);
        }

        // GET: ExPsicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExPsicoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExPsico exPsico)
        {
            if (ModelState.IsValid)
            {
                db.ExPsicoes.Add(exPsico);

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

            return View(exPsico);
        }

        // GET: ExPsicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exPsico = db.ExPsicoes.Find(id);

            if (exPsico == null)
            {
                return HttpNotFound();
            }

            return View(exPsico);
        }

        // POST: ExPsicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExPsico exPsico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exPsico).State = 
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

            return View(exPsico);
        }

        // GET: ExPsicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var exPsico = db.ExPsicoes.Find(id);

            if (exPsico == null)
            {
                return HttpNotFound();
            }

            return View(exPsico);
        }

        // POST: ExPsicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var exPsico = 
                db.ExPsicoes.Find(id);

            db.ExPsicoes.Remove(exPsico);

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

            return View(exPsico);
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
