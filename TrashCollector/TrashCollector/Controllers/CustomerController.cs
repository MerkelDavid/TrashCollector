using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
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
                foreach(var user in context.Adresses)
                {
                    if(user.CustomerID == CurrentUser)
                    {
                        ViewBag.Data = user;
                    }
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult EditAddress(Adress model)
        {
            var CurrentUser = User.Identity.GetUserId();
            model.CustomerID = CurrentUser;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                bool UserExists = false;
                foreach (var user in context.Adresses)
                {
                    if (user.CustomerID == CurrentUser)
                    {
                        user.Address = model.Address;
                        user.City = model.City;
                        user.State = model.State;
                        user.ZipCode = user.ZipCode;
                        UserExists = true;
                    }
                }

                if (UserExists == false)
                {
                    context.Adresses.Add(model);
                }

                context.SaveChanges();
            }
            ViewBag.Message = "Your address has been updated";
            return RedirectToAction("index", "Customer");
        }

        public ActionResult MakePayments()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> MakePayments(PaymentViewModel model)
        {
            return View();
        }

        public ActionResult ChangeSchedule()
        {
            var CurrentUser = User.Identity.GetUserId();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                foreach (var user in context.Schedule)
                {
                    if (user.Customer == CurrentUser)
                    {
                        ViewBag.Data = user;
                    }
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult ChangeSchedule(Schedule model)
        { 
            string CurrentUser = User.Identity.GetUserId();
            model.Customer = CurrentUser;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                bool UserExists = false;
                foreach(var user in context.Schedule)
                {
                    if(String.Equals(user.Customer,CurrentUser))
                    {
                        user.Day = model.Day;
                        user.VacationMode = model.VacationMode;
                        UserExists = true;
                    }
                }
                
                if (UserExists == false)
                {
                    context.Schedule.Add(model);
                }

                context.SaveChanges();
            }
            ViewBag.Message = "Your Schedule has been updated";
            return RedirectToAction("index", "Customer");

        }
    }
}