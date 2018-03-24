using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShahbazWebsite_MVCPlatform.Controllers
{
    public class TenantController : Controller
    {
        public IActionResult Index()
        {
            // Login check
            // If logged in, continue
            if (TempData.ContainsKey(key: "TenantLogin"))
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

        public IActionResult RequestsAndBookings()
        {
            if (TempData.ContainsKey(key: "TenantLogin"))
            {

                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult MaintenanceRequests()
        {
            if (TempData.ContainsKey(key: "TenantLogin"))
            {

                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult WebPayment()
        {
            if (TempData.ContainsKey(key: "TenantLogin"))
            {

                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult PasswordReset()
        {
            if (TempData.ContainsKey(key: "TenantLogin"))
            {

                return View();
            }
            else
            {

                return RedirectToAction("Login", "Login");
            }
        }



    }
}