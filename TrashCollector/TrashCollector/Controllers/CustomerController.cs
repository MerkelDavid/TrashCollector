using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {

        ApplicationDbContext context;
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditAddress()
        {
            var CurrentUser = User.Identity.GetUserId();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var user = context.Adresses.Find(CurrentUser);
                ViewBag.name = user;
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditAddress(Adress model)
        {
            model.CustomerID = User.Identity.GetUserId();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Adresses.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("index", "Customer");
        }

        public ActionResult MakePayments()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MakePayments(PaymentViewModel model)
        {
            return View();
        }

        public ActionResult ChangeSchedule()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeSchedule(ScheduleViewModel model)
        {
            return View();
        }
    }
}