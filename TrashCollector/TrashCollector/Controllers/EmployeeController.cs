using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            int EmployeeZipCode = 53154;
            List<string> Customers = new List<string>();
            List<Adress> RouteInfo = new List<Adress>();
            DateTime DayOfTheWeek = DateTime.Now;

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                foreach(var user in context.Schedule)
                {
                    if(String.Equals(user.Day, Convert.ToString(DayOfTheWeek.DayOfWeek)) && !user.VacationMode)
                    {
                        Customers.Add(user.Customer);
                    }
                }
                foreach(var user in context.Adresses)
                {
                    bool isGarbageDay = false;
                    for(int i = 0; i < Customers.Count; i++)
                    {
                        if(Customers[i] == user.CustomerID)
                        {
                            isGarbageDay = true;
                        }
                    }
                    if(isGarbageDay && user.ZipCode == EmployeeZipCode)
                    {
                        RouteInfo.Add(user);
                    }
                }


            }
            return View(RouteInfo);
        }
    }
}