 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tms2.Models
{
    public class vehicleinformationsController : Controller
    {
        private readonly Transportcontext _context;

        public vehicleinformationsController(Transportcontext context)
        {
            _context = context;
        }

        // GET: vehicleinformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.vehicleinfos.ToListAsync());
        }

        // GET: vehicleinformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleinformation = await _context.vehicleinfos
                .FirstOrDefaultAsync(m => m.vehiclenumber == id);
            if (vehicleinformation == null)
            {
                return NotFound();
            }

            return View(vehicleinformation);
        }

        // GET: vehicleinformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: vehicleinformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("vehiclenumber,capacity,seat,operable")] vehicleinformation vehicleinformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleinformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleinformation);
        }

        // GET: vehicleinformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleinformation = await _context.vehicleinfos.FindAsync(id);
            if (vehicleinformation == null)
            {
                return NotFound();
            }
            return View(vehicleinformation);
        }

        // POST: vehicleinformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("vehiclenumber,capacity,seat,operable")] vehicleinformation vehicleinformation)
        {
            if (id != vehicleinformation.vehiclenumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleinformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!vehicleinformationExists(vehicleinformation.vehiclenumber))
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
            return View(vehicleinformation);
        }

        // GET: vehicleinformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleinformation = await _context.vehicleinfos
                .FirstOrDefaultAsync(m => m.vehiclenumber == id);
            if (vehicleinformation == null)
            {
                return NotFound();
            }

            return View(vehicleinformation);
        }

        // POST: vehicleinformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleinformation = await _context.vehicleinfos.FindAsync(id);
            _context.vehicleinfos.Remove(vehicleinformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool vehicleinformationExists(int id)
        {
            return _context.vehicleinfos.Any(e => e.vehiclenumber == id);
        }
    }
}
