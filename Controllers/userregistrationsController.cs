using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tms2.Models
{
    public class userregistrationsController : Controller
    {
        private readonly Transportcontext _context;

        public userregistrationsController(Transportcontext context)
        {
            _context = context;
        }

        // GET: userregistrations
        public async Task<IActionResult> Index()
        {
            return View(await _context.userregs.ToListAsync());
        }

        // GET: userregistrations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userregistration = await _context.userregs
                .FirstOrDefaultAsync(m => m.User_firstname == id);
            if (userregistration == null)
            {
                return NotFound();
            }

            return View(userregistration);
        }

        // GET: userregistrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: userregistrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_firstname,User_lastname,Password,CPassword")] userregistration userregistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userregistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userregistration);
        }

        // GET: userregistrations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userregistration = await _context.userregs.FindAsync(id);
            if (userregistration == null)
            {
                return NotFound();
            }
            return View(userregistration);
        }

        // POST: userregistrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("User_firstname,User_lastname,Password,CPassword")] userregistration userregistration)
        {
            if (id != userregistration.User_firstname)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userregistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userregistrationExists(userregistration.User_firstname))
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
            return View(userregistration);
        }

        // GET: userregistrations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userregistration = await _context.userregs
                .FirstOrDefaultAsync(m => m.User_firstname == id);
            if (userregistration == null)
            {
                return NotFound();
            }

            return View(userregistration);
        }

        // POST: userregistrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userregistration = await _context.userregs.FindAsync(id);
            _context.userregs.Remove(userregistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userregistrationExists(string id)
        {
            return _context.userregs.Any(e => e.User_firstname == id);
        }
    }
}
