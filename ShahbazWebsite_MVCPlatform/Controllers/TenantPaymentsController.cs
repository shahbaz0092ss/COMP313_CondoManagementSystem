

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
    public class TenantPaymentsController : Controller
    {
        private readonly comp313MVCDatabaseContext _context;

        public TenantPaymentsController(comp313MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: TenantPayments - Per User
        public async Task<IActionResult> Index()
        {
            // NEXT: 
            // Get UserId from session

            // FOR NOW:
            // Just get result for UserId #1
            var comp313MVCDatabaseContext = _context.Payment.Where(p => p.User.UserId == 1);
            return View(await comp313MVCDatabaseContext.ToListAsync());
        }


        // GET: TenantPayments/Create
        public IActionResult Create()
        {
            // NEXT: 
            // Get UserId from session

            // FOR NOW:
            // Just get result for UserId #1

            ViewData["UserId"] = 1;
            return View();
        }

        // POST: TenantPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,UserId,AmountPaid,TypeOfPayment")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", payment.UserId);

            return View(payment);
        }


        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentId == id);
        }
    }
}
