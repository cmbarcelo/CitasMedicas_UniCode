using CitasMedicas_UniCode.Models.ModelCustom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasMedicas_UniCode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Calendario());
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new Calendario();
            var events = new List<Calendario>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-11);

            for (var i = 1; i <= 5; i++)
            {
                events.Add(new Calendario()
                {
                    id = i,
                    title = "Event " + i,
                    start = start.ToString(),
                    end = end.ToString(),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }


            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}