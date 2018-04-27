using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ShahbazWebsite_MVCPlatform.Models;

namespace ShahbazWebsite_MVCPlatform.Controllers
{
    public class TenantBookingsController : Controller
    {
        private readonly comp313MVCDatabaseContext _context;

        public TenantBookingsController(comp313MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: TenantBookings
        public async Task<IActionResult> Index()
        {
         
            // NEXT: 
            // Get UserId from session
         
            // Hardcoded for testing purposes
            // Just get result for UserId #1
            // var comp313MVCDatabaseContext = _context.Booking.Where(b => b.User.UserId == 1);
            
            var UserID = HttpContext.Session.GetInt32("_UserID");
            var comp313MVCDatabaseContext = _context.Booking.Where(b => b.User.UserId == UserID);

            return View(await comp313MVCDatabaseContext.ToListAsync());

        }

        // GET: TenantBookings/Create
        public IActionResult Create()
        {
           
            // Hardcoded for testing
            // ViewData["UserId"] = 1;

            return View();
        }

        // POST: TenantBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,UserId,Category,StartDate,EndDate,TimeFrom,TimeTo,BookingDetail,Status")] Booking booking)
        {
            booking.Status = "Pending";

            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", booking.UserId);
            
           return View(booking);
        }
        
        
        

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingId == id);
        }
    }
}
