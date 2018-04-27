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

            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {

            var comp313MVCDatabaseContext = _context.Booking.Include(b => b.User);
            return View(await comp313MVCDatabaseContext.ToListAsync());

            }
            else
            {
               
                return RedirectToAction("Login", "Login");
            }


        }

           // GET: Maintenances report - Show all data
        public async Task<IActionResult> Reports_Maintenance()
        {

             if (TempData.ContainsKey(key: "EmployeeLogin"))
            {

            var comp313MVCDatabaseContext = _context.Maintenance.Include(m => m.User);
            return View(await comp313MVCDatabaseContext.ToListAsync());
             
            }
             
            else
            {
               
                return RedirectToAction("Login", "Login");
            }
        }


         // POST
        public IActionResult Reports_TenantSearchDetails(string TenantSearch)
        {

             if (TempData.ContainsKey(key: "EmployeeLogin"))
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
             
            else
            {
               
                return RedirectToAction("Login", "Login");
            }

            
        }

        public IActionResult Reports_TenantSearch()
        {
            if (TempData.ContainsKey(key: "EmployeeLogin"))
            {

                return View();

                }
             
            else
            {
               
                return RedirectToAction("Login", "Login");
            }


            
        }


        // Web Paments report - Show all data
        public async Task<IActionResult> Reports_WebPayments()
        {

         if (TempData.ContainsKey(key: "EmployeeLogin"))
            {

            var comp313MVCDatabaseContext = _context.Payment.Include(p => p.User);

            // Return entire list of payments
            return View(await comp313MVCDatabaseContext.ToListAsync());


          }
             
            else
            {
               
                return RedirectToAction("Login", "Login");
            }

        }


        public IActionResult Reports_AggregateData()
        {
                
             if (TempData.ContainsKey(key: "EmployeeLogin"))
            {

                // Returning this model 
                var reportmodel = new Reporting_Aggregates();

                reportmodel.User_TotalEmployees =  _context.User.Count(u => u.UserType == "Employee" ||  u.UserType == "employee");
                reportmodel.User_TotalTenants =  _context.User.Count(u => u.UserType == "Tenant" ||  u.UserType == "tenant");

                reportmodel.Booking_TotalParking =  _context.Booking.Count(b => b.Category == "Parking" ||  b.Category == "parking");
                reportmodel.Booking_TotalGuestParking =  _context.Booking.Count(b => b.Category == "Guest Parking" ||  b.Category == "guest parking"
                                                                                 ||  b.Category == "Guest parking" ||  b.Category == "guest Parking");
                reportmodel.Booking_TotalPartyHall =  _context.Booking.Count(b => b.Category == "Party Hall" ||  b.Category == "party hall"
                                                                                 ||  b.Category == "Party hall" || b.Category == "party Hall");


                reportmodel.Maintenance_TotalRepair = _context.Maintenance.Count(m => m.Category == "Repair" || m.Category == "repair");
                reportmodel.Maintenance_TotalEmergency = _context.Maintenance.Count(m => m.Category == "Emergency" || m.Category == "emergency");
                reportmodel.Maintenance_TotalElectrical = _context.Maintenance.Count(m => m.Category == "Electrical" || m.Category == "electrical");
                reportmodel.Maintenance_TotalPlumbing  = _context.Maintenance.Count(m => m.Category == "Plumbing " || m.Category == "plumbing");
                reportmodel.Maintenance_TotalHVAC = _context.Maintenance.Count(m => m.Category == "HVAC" || m.Category == "hvac");
                reportmodel.Maintenance_TotalCleaning  = _context.Maintenance.Count(m => m.Category == "Cleaning" || m.Category == "cleaning");

                // .Value used for:
                // https://stackoverflow.com/questions/5995317/how-to-convert-c-sharp-nullable-int-to-int
                reportmodel.Maintenance_TotalDollarAmount = _context.Maintenance.Sum(m => m.DollarAmount).Value;



                reportmodel.Payment_TotalUsers = _context.Payment.Select(p => p.UserId.Value).Distinct().Count();
                reportmodel.Payment_TotalAmountPaid = _context.Payment.Sum(p => p.AmountPaid).Value;

                reportmodel.Payment_TotalUsersRent = _context.Payment.Where(p => p.TypeOfPayment == "Rent" ||
                                                                                 p.TypeOfPayment == "rent")
                                                                     .Select(p => p.UserId.Value).Distinct().Count();


                reportmodel.Payment_TotalRentPaid =_context.Payment.Where(p => p.TypeOfPayment == "Rent" ||
                                                                           p.TypeOfPayment == "rent")   
                                                               .Sum(p => p.AmountPaid.Value);


            reportmodel.Payment_TotalLockerRental =_context.Payment.Where(p => p.TypeOfPayment == "Locker Rental" ||
                                                                               p.TypeOfPayment == "locker rental" ||  
                                                                               p.TypeOfPayment == "Locker rental" ||
                                                                               p.TypeOfPayment == "locker Rental") 
                                                               .Sum(p => p.AmountPaid.Value);

             reportmodel.Payment_TotalPremiumCleaning =_context.Payment.Where(p => p.TypeOfPayment == "Premium Cleaning" ||
                                                                               p.TypeOfPayment == "premium pleaning" ||  
                                                                               p.TypeOfPayment == "Premium cleaning" ||
                                                                               p.TypeOfPayment == "premium Cleaning") 
                                                               .Sum(p => p.AmountPaid.Value);



                return View(reportmodel);

            }
             
            else
            {
               
                return RedirectToAction("Login", "Login");
            }
        }

        // WebPayments
        //AggregateData
    }
}