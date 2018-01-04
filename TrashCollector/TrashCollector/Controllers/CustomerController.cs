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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAddress(AddressViewModel model)
        {
            return View();
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