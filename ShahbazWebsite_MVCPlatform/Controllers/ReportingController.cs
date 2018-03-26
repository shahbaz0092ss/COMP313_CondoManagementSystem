using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShahbazWebsite_MVCPlatform.Controllers
{
    public class ReportingController : Controller
    {

        // Nothing yet
        public IActionResult Reporting()
        {
            return View();
        }

        public IActionResult Reports_DailyRequestsAndBookings()
        {


            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                return View();

            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }

        }

        public IActionResult Reports_Maintenance()
        {
            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                return View();

            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Reports_TenantSearchDetails()
        {
            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                return View();

            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Reports_WebPayments()
        {
            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                return View();

            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult Reports_AggregateData()
        {
            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                return View();

            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }
        }

        // WebPayments
        //AggregateData
    }
}