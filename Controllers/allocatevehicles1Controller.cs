using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tms2.Models
{
    public class allocatevehicles1Controller : Controller
    {
        private readonly Transportcontext _context;

        public allocatevehicles1Controller(Transportcontext context)
        {
            _context = context;
        }

        // GET: allocatevehicles1
        public async Task<IActionResult> Index()
        {
            return View(await _context.allocatevehicles.ToListAsync());
        }

        // GET: allocatevehicles1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocatevehicle = await _context.allocatevehicles
                .FirstOrDefaultAsync(m => m.Employeename == id);
            if (allocatevehicle == null)
            {
                return NotFound();
            }

            return View(allocatevehicle);
        }

        // GET: allocatevehicles1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: allocatevehicles1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employeename,Employeelocation,Empphoneno,Employeeage,vehicleallocationtoEmployee")] allocatevehicle allocatevehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocatevehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allocatevehicle);
        }

        // GET: allocatevehicles1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocatevehicle = await _context.allocatevehicles.FindAsync(id);
            if (allocatevehicle == null)
            {
                return NotFound();
            }
            return View(allocatevehicle);
        }

        // POST: allocatevehicles1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Employeename,Employeelocation,Empphoneno,Employeeage,vehicleallocationtoEmployee")] allocatevehicle allocatevehicle)
        {
            if (id != allocatevehicle.Employeename)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocatevehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!allocatevehicleExists(allocatevehicle.Employeename))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(allocatevehicle);
        }

        // GET: allocatevehicles1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocatevehicle = await _context.allocatevehicles
                .FirstOrDefaultAsync(m => m.Employeename == id);
            if (allocatevehicle == null)
            {
                return NotFound();
            }

            return View(allocatevehicle);
        }

        // POST: allocatevehicles1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var allocatevehicle = await _context.allocatevehicles.FindAsync(id);
            _context.allocatevehicles.Remove(allocatevehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool allocatevehicleExists(string id)
        {
            return _context.allocatevehicles.Any(e => e.Employeename == id);
        }
    }
}
