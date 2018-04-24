
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
    public class TenantMaintenancesController : Controller
    {
        private readonly comp313MVCDatabaseContext _context;

        public TenantMaintenancesController(comp313MVCDatabaseContext context)
        {
            _context = context;
        }

        // GET: Tenant Maintenance requests
        public async Task<IActionResult> Index()
        {

            // NEXT: 
            // Get UserId from session

            // Just get result for UserId #1
            var comp313MVCDatabaseContext = _context.Maintenance.Where(m => m.User.UserId == 1);
            return View(await comp313MVCDatabaseContext.ToListAsync());

        }

        // GET: TenantMaintenances/Create
        public IActionResult Create()
        {

            ViewData["UserId"] = 1;

            return View();
        }

        // POST: TenantMaintenances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaintenanceId,UserId,Category,StartDate,EndDate,MaintenanceDetail,Status,DollarAmount,Note")] Maintenance maintenance)
        {
            maintenance.Status = "Pending";

            if (ModelState.IsValid)
            {
                _context.Add(maintenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", maintenance.UserId);

            return View(maintenance);
        }




        private bool MaintenanceExists(int id)
        {
            return _context.Maintenance.Any(e => e.MaintenanceId == id);
        }

    }
}
