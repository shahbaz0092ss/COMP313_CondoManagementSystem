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
    public class TimelinesController: Controller
    {


        private readonly comp313MVCDatabaseContext _context;

        public TimelinesController(comp313MVCDatabaseContext context)
        {
            _context = context;
        }


        
        public IActionResult TimelinesBookings_Months()
        {

            return View();


        }


        // Return JSON: Bookings data 
        public JsonResult TimelinesBookings_Months_JSON()
        {

                // Returning this list of model type to view (in our case, the layout)
                var listOfTimelinesEvents = new List<Timelines_Event>();

                var dbContext = _context.Booking.Include(b => b.User);
     
                var dbContextList = dbContext.ToList();


                foreach (var Booking in dbContextList)
                {

                    // If/Then...Next..
                    // Color based on status

                    var colorCode = "";
                    DateTime endDate;

                    if (Booking.Status == "Approved" || Booking.Status == "approved" )
                    {
                    colorCode = "green";
                    }
                     if (Booking.Status == "Declined" || Booking.Status == "declined" )
                    {
                    colorCode = "grey";
                    }
                    if (Booking.Status == "Pending" || Booking.Status == "pending" )
                    {
                    colorCode = "businessblue";
                    }

                    //FIX: If end date is null, set to this date 
                    //     For displaying purpose.
                    if (Booking.EndDate == null)
                    {
                    endDate = new DateTime(2018,4,1);
                    }
                    else
                    {
                    
                    // From nullable type Booking.EndDate to non-nullable type endDate
                    endDate = Booking.EndDate.Value;
                    
                    //FIX: Add 1 more day to display event properly on fullcalendar
                    endDate = endDate.AddDays(1);
                    }


                    listOfTimelinesEvents.Add(new Timelines_Event() { title = "ID: " + Booking.BookingId +
                                                                               "  Booking - " +
                                                                               "  Type: " + Booking.Category + 
                                                                               ". " + Booking.Status,
                                                                      start = Booking.StartDate,
                                                                      end = endDate,
                                                                      url = "/Bookings/Details?id=" + Booking.BookingId,
                                                                      status = Booking.Status,
                                                                      type = Booking.Category,
                                                                      color = colorCode,
                                                                      displayEventEnd = false,
                                                                      displayEventTime = false,
                                                                      overlap = false

                                                                     });

                  
                }


            return Json(listOfTimelinesEvents);

           // NOTE: return Json() will do the JSON serialization automatically for List.
        }


         // 
        public IActionResult TimelinesBookings_Week()
        {
            return View();
        }

         
        public IActionResult TimelinesMaintenances_Months()
        {
            return View();
        }

        
        // Return JSON: Maintenance data 
        public JsonResult TimelinesMaintenances_Months_JSON()
        {

                // Returning this list of model type to view (in our case, the layout)
                var listOfTimelinesEvents = new List<Timelines_Event>();

                var dbContext = _context.Maintenance.Include(b => b.User);
     
                var dbContextList = dbContext.ToList();


                foreach (var Maintenance in dbContextList)
                {

                    // If/Then...Next..
                    // Color based on status

                    var colorCode = "";
                    DateTime endDate;


                    if (Maintenance.Status == "Closed" || Maintenance.Status == "closed" 
                                                       || Maintenance.Status == "Completed" 
                                                       || Maintenance.Status == "completed")
                    {
                    colorCode = "green";
                    }
                    if (Maintenance.Status == "Pending" || Maintenance.Status == "pending" 
                                                    || Maintenance.Status == "Open"
                                                    || Maintenance.Status == "open")
                    {
                    colorCode = "businessblue";
                    }
                    if (Maintenance.Category == "Emergency" || Maintenance.Category == "emergency" )
                    {
                    colorCode = "red";
                    }



                    //FIX: If end date is null, set to todays date 
                    //     For display purpose.
                    //     Add 1 more day to display event properly on fullcalendar
                    if (Maintenance.EndDate == null)
                    {
                    
                    DateTime todaysDate = DateTime.Today;
                    endDate = todaysDate.AddDays(1);

                    }
                    else
                    {
                    
                    // From nullable type Booking.EndDate to non-nullable type endDate
                    endDate = Maintenance.EndDate.Value;
                    
                    //FIX: Add 1 more day to display event properly on fullcalendar
                    endDate = endDate.AddDays(1);
                    }


                    listOfTimelinesEvents.Add(new Timelines_Event() { title = "ID: " + Maintenance.MaintenanceId +
                                                                               "  Maintenance - " +
                                                                               "  Type: " + Maintenance.Category + 
                                                                               ". " + Maintenance.Status +
                                                                               " Comments: " + Maintenance.Note,
                                                                      start = Maintenance.StartDate,
                                                                      end = endDate,
                                                                      url = "/Maintenances/Details?id=" + Maintenance.MaintenanceId,
                                                                      status = Maintenance.Status,
                                                                      type = Maintenance.Category,
                                                                      color = colorCode,
                                                                      displayEventEnd = false,
                                                                      displayEventTime = false,
                                                                      overlap = false

                                                                     });

                  
                }


            return Json(listOfTimelinesEvents);
        }

         // 
        public IActionResult TimelinesMaintenances_Week()
        {
            return View();
        }

        
    }
}