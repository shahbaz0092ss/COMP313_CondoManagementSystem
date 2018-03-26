using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShahbazWebsite_MVCPlatform.Models;

namespace ShahbazWebsite_MVCPlatform.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            // Login check
            // If logged in, continue



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

        public IActionResult AddRemoveUsers()
        {
            // Login check
            // If logged in, continue

            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {
                ViewData["Message"] = "Your application description page.";

                return View();
            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }

        }

        public IActionResult BookingsAndRequests()
        {

            // Login check
            // If logged in, continue

            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                ViewData["Message"] = "Your contact page.";

                return View();
            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }


        }

        public IActionResult MaintenanceRequests()
        {

            // Login check
            // If logged in, continue

            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                ViewData["Message"] = "Your contact page.";

                return View();
            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }


        }

        public IActionResult Error()
        {

            // Login check
            // If logged in, continue

            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {


                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            }
            else
            {
                // Take to Login page
                // Login action, in Login controller
                return RedirectToAction("Login", "Login");
            }


        }
    }
}
