using ChiangMaiUniversity.DAL;
using ChiangMaiUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiangMaiUniversity.Controllers
{
    public class HomeController : Controller
    {
        private ChiangMaiUniversityContext db = new ChiangMaiUniversityContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //IQueryable<EnrollmentDateGroup> vm = from s in db.Students
            //                                     group s by s.EnrollmentDate into g
            //                                     select new EnrollmentDateGroup()
            //                                     {
            //                                         EnrollmentDate = g.Key,
            //                                         StudentCount = g.Count()
            //                                     };
            // Create and execute raw SQL
            string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                + "FROM Student GROUP BY EnrollmentDate";
            IEnumerable<EnrollmentDateGroup> vm = db.Database.SqlQuery<EnrollmentDateGroup>(query);
            return View(vm.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}