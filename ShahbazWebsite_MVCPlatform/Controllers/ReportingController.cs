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


         // POST
        public IActionResult Reports_TenantSearchDetails(string TenantSearch)
        {

                // For the view
                ViewData["TenantSearchRequested"] = TenantSearch;

                // Returning this model 
                var reportModel = new Reporting_UserDetails();


                //1. If only numbers, then let's do User.Id lookup
                //   NEXT: null checking in TenantSearch

                    if (System.Text.RegularExpressions.Regex.IsMatch(TenantSearch, "^[0-9]*$"))
                        {

                                // User.Id lookup in DB
                                var user =  _context.User.SingleOrDefault(m => m.UserId == Convert.ToInt32(TenantSearch));

                                        if (user == null)
                                        {
                                            ViewData["Message"] = "Not found in DB";
                                             reportModel = null;
                                        }else
                                                {
                                                //ViewData["UserFound"] = user.UserId;
                                                
                                               
                                                reportModel.User = user;
                                                
                                                var bookingList = _context.Booking
                                                                            .ToList()
                                                                            .Where(b => b.UserId == user.UserId);
                                                                            
                                                reportModel.Booking = bookingList;


                                                var maintenanceList = _context.Maintenance.ToList().Where(m => m.UserId == user.UserId); 
                                                reportModel.Maintenance = maintenanceList;


                                                var paymentList =_context.Payment.ToList().Where(p => p.UserId == user.UserId);
                                                reportModel.Payment = paymentList;
                                                
                                                }

                                

                        }

                    //1. If only letters and contains a space, then let's do user.FirstName and user.LastName lookup
                    //   NEXT: null checking in TenantSearch

                    if (System.Text.RegularExpressions.Regex.IsMatch(TenantSearch, "^[A-Za-z ]+$") && TenantSearch.Contains(" "))
                        {

                                // Split full name entered in search into 2
                                string[] names = TenantSearch.Split(" ");
                                string firstname = names[0];
                                string lastname = names[1];
                                
                                // user.FirstName and user.LastName lookup in DB
                                var user =  _context.User.SingleOrDefault(u => u.FirstName == firstname &&
                                                                               u.LastName == lastname);

                                        if (user == null)
                                        {
                                            ViewData["Message"] = "Not found in DB";
                                            reportModel = null;
                                        }else
                                                {
                                                //ViewData["UserFound"] = user.FirstName + " " + user.LastName;

                                                reportModel.User = user;
                                                
                                                var bookingList = _context.Booking
                                                                            .ToList()
                                                                            .Where(b => b.UserId == user.UserId);
                                                                            
                                                reportModel.Booking = bookingList;


                                                var maintenanceList = _context.Maintenance.ToList().Where(m => m.UserId == user.UserId); 
                                                reportModel.Maintenance = maintenanceList;


                                                var paymentList =_context.Payment.ToList().Where(p => p.UserId == user.UserId);
                                                reportModel.Payment = paymentList;
                                                }

                                

                        }


           
                    // If text entered in search is null

                    if (TenantSearch == null)
                    {
                    ViewData["Message"] = "Text entered is null";
                    reportModel = null;
                    }

                    // If only single word
                    if (System.Text.RegularExpressions.Regex.IsMatch(TenantSearch, "^[A-Za-z ]+$") && !TenantSearch.Contains(" "))
                    {
                    ViewData["Message"] = "Try entering first and last name both, or ID.  For example, John Smith or 128";

                    reportModel = null;
                    }

                     // If both number+text has been entered, e.g. (abc123)
                    if (System.Text.RegularExpressions.Regex.IsMatch(TenantSearch, "^([0-9]+[a-zA-Z]+|[a-zA-Z]+[0-9]+)[0-9a-zA-Z]*$") 
                                                                        && !TenantSearch.Contains(" "))
                    {
                    ViewData["Message"] = "Try entering text only with first and last name both. Or just enter ID.  For example, John Smith or 128";

                    reportModel = null;
                    }


                    
                   

                return View(reportModel);

            
        }

        public IActionResult Reports_TenantSearch()
        {

                return View();

            
        }


        // Web Paments report - Show all data
        public async Task<IActionResult> Reports_WebPayments()
        {
            var comp313MVCDatabaseContext = _context.Payment.Include(p => p.User);

            // Return entire list of payments
            return View(await comp313MVCDatabaseContext.ToListAsync());
        }

        public IActionResult Reports_AggregateData()
        {


                return View();
        }

        // WebPayments
        //AggregateData
    }
}