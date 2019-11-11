namespace sisoC.Controllers
{    
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using PagedList;
    using sisoC.Helpers;
    using sisoC.Models;

    public class OtherExamsController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: OtherExams
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);

            return View(
                db.OtherExams.
                OrderBy(oe => oe.Description)
                .ToPagedList((int)page, 6));
        }

        // GET: OtherExams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var otherExam = db.OtherExams.Find(id);

            if (otherExam == null)
            {
                return HttpNotFound();
            }

            return View(otherExam);
        }

        // GET: OtherExams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherExams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OtherExam otherExam)
        {
            if (ModelState.IsValid)
            {
                db.OtherExams.Add(otherExam);

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

            return View(otherExam);
        }

        // GET: OtherExams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var otherExam = db.OtherExams.Find(id);

            if (otherExam == null)
            {
                return HttpNotFound();
            }

            return View(otherExam);
        }

        // POST: OtherExams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OtherExam otherExam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherExam).State = 
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

            return View(otherExam);
        }

        // GET: OtherExams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var otherExam = db.OtherExams.Find(id);

            if (otherExam == null)
            {
                return HttpNotFound();
            }

            return View(otherExam);
        }

        // POST: OtherExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var otherExam = 
                db.OtherExams.Find(id);

            db.OtherExams.Remove(otherExam);

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

            return View(otherExam);
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
