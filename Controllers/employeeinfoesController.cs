using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tms2.Models;

namespace Tms2.Models
{
    public class employeeinfoesController : Controller
    {
        private readonly Transportcontext _context;

        public employeeinfoesController(Transportcontext context)
        {
            _context = context;
        }

        // GET: employeeinfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.empinfos.ToListAsync());
        }

        // GET: employeeinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeinfo = await _context.empinfos
                .FirstOrDefaultAsync(m => m.employeeid == id);
            if (employeeinfo == null)
            {
                return NotFound();
            }

            return View(employeeinfo);
        }

        // GET: employeeinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: employeeinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("employeeid,name,age,location,phoneno,vehicleID")] employeeinfo employeeinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeinfo);
        }

        // GET: employeeinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeinfo = await _context.empinfos.FindAsync(id);
            if (employeeinfo == null)
            {
                return NotFound();
            }
            return View(employeeinfo);
        }

        // POST: employeeinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("employeeid,name,age,location,phoneno,vehicleID")] employeeinfo employeeinfo)
        {
            if (id != employeeinfo.employeeid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeeinfoExists(employeeinfo.employeeid))
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
            return View(employeeinfo);
        }

        // GET: employeeinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeinfo = await _context.empinfos
                .FirstOrDefaultAsync(m => m.employeeid == id);
            if (employeeinfo == null)
            {
                return NotFound();
            }

            return View(employeeinfo);
        }

        // POST: employeeinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeinfo = await _context.empinfos.FindAsync(id);
            _context.empinfos.Remove(employeeinfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool employeeinfoExists(int id)
        {
            return _context.empinfos.Any(e => e.employeeid == id);
        }
    }
}
