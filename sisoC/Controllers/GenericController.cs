namespace sisoC.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using sisoC.Models;

    public class GenericController : Controller
    {
        private SisoCdataContext db = new SisoCdataContext();

        // GET: Generic
        //public ActionResult Index()
        //{
        //return View();
        //}

        public JsonResult GetCities(int stateID)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var cities = db.Cities.
                Where(c => c.StateID == stateID);

            return Json(cities);
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