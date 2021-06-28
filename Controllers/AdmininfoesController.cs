using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tms2.Models
{
    public class AdmininfoesController : Controller
    {
        private readonly Transportcontext _context;

        public AdmininfoesController(Transportcontext context)
        {
            _context = context;
        }

        // GET: Admininfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.admininfos.ToListAsync());
        }

        // GET: Admininfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admininfo = await _context.admininfos
                .FirstOrDefaultAsync(m => m.Username == id);
            if (admininfo == null)
            {
                return NotFound();
            }

            return View(admininfo);
        }

        // GET: Admininfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admininfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password")] Admininfo admininfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admininfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admininfo);
        }

        // GET: Admininfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admininfo = await _context.admininfos.FindAsync(id);
            if (admininfo == null)
            {
                return NotFound();
            }
            return View(admininfo);
        }

        // POST: Admininfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password")] Admininfo admininfo)
        {
            if (id != admininfo.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admininfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmininfoExists(admininfo.Username))
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
            return View(admininfo);
        }

        // GET: Admininfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admininfo = await _context.admininfos
                .FirstOrDefaultAsync(m => m.Username == id);
            if (admininfo == null)
            {
                return NotFound();
            }

            return View(admininfo);
        }

        // POST: Admininfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var admininfo = await _context.admininfos.FindAsync(id);
            _context.admininfos.Remove(admininfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmininfoExists(string id)
        {
            return _context.admininfos.Any(e => e.Username == id);
        }
    }
}
