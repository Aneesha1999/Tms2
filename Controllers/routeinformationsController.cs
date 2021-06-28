using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tms2.Models
{
    public class routeinformationsController : Controller
    {
        private readonly Transportcontext _context;

        public routeinformationsController(Transportcontext context)
        {
            _context = context;
        }

        // GET: routeinformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.routeinfos.ToListAsync());
        }

        // GET: routeinformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeinformation = await _context.routeinfos
                .FirstOrDefaultAsync(m => m.rootnumber == id);
            if (routeinformation == null)
            {
                return NotFound();
            }

            return View(routeinformation);
        }

        // GET: routeinformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: routeinformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rootnumber,vehiclenumber,stops")] routeinformation routeinformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routeinformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routeinformation);
        }

        // GET: routeinformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeinformation = await _context.routeinfos.FindAsync(id);
            if (routeinformation == null)
            {
                return NotFound();
            }
            return View(routeinformation);
        }

        // POST: routeinformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rootnumber,vehiclenumber,stops")] routeinformation routeinformation)
        {
            if (id != routeinformation.rootnumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routeinformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!routeinformationExists(routeinformation.rootnumber))
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
            return View(routeinformation);
        }

        // GET: routeinformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routeinformation = await _context.routeinfos
                .FirstOrDefaultAsync(m => m.rootnumber == id);
            if (routeinformation == null)
            {
                return NotFound();
            }

            return View(routeinformation);
        }

        // POST: routeinformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routeinformation = await _context.routeinfos.FindAsync(id);
            _context.routeinfos.Remove(routeinformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool routeinformationExists(int id)
        {
            return _context.routeinfos.Any(e => e.rootnumber == id);
        }
    }
}
