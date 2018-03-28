using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShahbazWebsite_MVCPlatform.Models;

namespace ShahbazWebsite_MVCPlatform.Controllers


{
    public class ReportingController : Controller
    {


        private readonly comp313MVCDatabaseContext _context;

        public ReportingController(comp313MVCDatabaseContext context)
        {
            _context = context;
        }

        // Default index - Nothing yet
        public IActionResult Reporting()
        {
            return View();
        }

          // GET: Bookings and Requests report - Show all data
        public async Task<IActionResult> Reports_DailyRequestsAndBookings()
        {

            var comp313MVCDatabaseContext = _context.Booking.Include(b => b.User);
            return View(await comp313MVCDatabaseContext.ToListAsync());


        }

           // GET: Maintenances report - Show all data
        public async Task<IActionResult> Reports_Maintenance()
        {
            var comp313MVCDatabaseContext = _context.Maintenance.Include(m => m.User);
            return View(await comp313MVCDatabaseContext.ToListAsync());
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