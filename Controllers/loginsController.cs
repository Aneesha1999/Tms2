using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tms2.Models
{
    public class loginsController : Controller
    {
        private readonly Transportcontext _context;

        public loginsController(Transportcontext context)
        {
            _context = context;
        }

        // GET: logins
        public async Task<IActionResult> Index()
        {
            return View(await _context.login.ToListAsync());
        }

        // GET: logins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.login
                .FirstOrDefaultAsync(m => m.username == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: logins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create([Bind("username,password")] login login)
        {
          
            {
                userregistration ur = (from i in _context.userregs
                                       where i.User_firstname == login.username && i.Password == login.password
                                       select i).FirstOrDefault();
                if (ur != null)
                {
                    string username = ur.User_firstname;
                    HttpContext.Session.SetString("User_firstname", username);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction("Create", "logins");

                }

            }
        }

        // GET: logins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var login = await _context.login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: logins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("username,password")] login login)
        {
            if (id != login.username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!loginExists(login.username))
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
            return View(login);
        }

        // GET: logins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.login
                .FirstOrDefaultAsync(m => m.username == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var login = await _context.login.FindAsync(id);
            _context.login.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool loginExists(string id)
        {
            return _context.login.Any(e => e.username == id);
        }
    }
}
