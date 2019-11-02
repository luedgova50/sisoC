namespace sisoC.Controllers
{
    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using sisoC.Helpers;
    using sisoC.Models;

    public class DocumentTypesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: DocumentTypes
        public ActionResult Index()
        {
            return View(db.DocumentTypes.ToList());
        }

        // GET: DocumentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var documentType = 
                db.DocumentTypes.Find(id);

            if (documentType == null)
            {
                return HttpNotFound();
            }

            return View(documentType);
        }

        // GET: DocumentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.DocumentTypes.Add(documentType);

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

            return View(documentType);
        }

        // GET: DocumentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var documentType = 
                db.DocumentTypes.Find(id);

            if (documentType == null)
            {
                return HttpNotFound();
            }

            return View(documentType);
        }

        // POST: DocumentTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentType documentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentType).
                    State = 
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

            return View(documentType);
        }

        // GET: DocumentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var documentType = 
                db.DocumentTypes.Find(id);

            if (documentType == null)
            {
                return HttpNotFound();
            }

            return View(documentType);
        }

        // POST: DocumentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var documentType = 
                db.DocumentTypes.Find(id);

            db.DocumentTypes.Remove(documentType);
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
