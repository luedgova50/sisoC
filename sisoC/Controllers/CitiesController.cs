namespace sisoC.Controllers
{
    using sisoC.Helpers;
    using sisoC.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    public class CitiesController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Cities
        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.State);

            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var city = db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.StateID = 
                new SelectList( 
                    ComboBoxStateHelper.
                    GetStates(), 
                    "StateID", 
                    "Name");

            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);

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

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetStates(), 
                "StateID", 
                "Name", 
                city.StateID);

            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var city = db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetStates(), 
                    "StateID", 
                    "Name", 
                    city.StateID);

            return View(city);
        }

        // POST: Cities/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).
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

            ViewBag.StateID = 
                new SelectList(
                    ComboBoxStateHelper.
                    GetStates(), 
                    "StateID", 
                    "Name", 
                    city.StateID);

            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var city = db.Cities.Find(id);

            if (city == null)
            {
                return HttpNotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var city = db.Cities.Find(id);

            db.Cities.Remove(city);

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
