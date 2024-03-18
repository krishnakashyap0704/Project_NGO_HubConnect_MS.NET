using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGO_HubConnect.Models;
using Project_NGO_HubConnect.Data;

namespace NGO_HubConnect.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AspNetUserController : Controller
    {
        private readonly MyDbContext _context;

        public AspNetUserController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AspNetUser
        public async Task<IActionResult> Index()
        {
              return _context.aspnetusers != null ? 
                          View(await _context.aspnetusers.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.aspnetusers'  is null.");
        }

        // GET: AspNetUser/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.aspnetusers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.aspnetusers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // GET: AspNetUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateOfBirth,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Gender")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUser);
        }

        // GET: AspNetUser/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.aspnetusers == null)
            {
                return NotFound();
            }

            var aspNetUser = await _context.aspnetusers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUser == null)
            {
                return NotFound();
            }

            return View(aspNetUser);
        }

        // POST: AspNetUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.aspnetusers == null)
            {
                return Problem("Entity set 'MyDbContext.aspnetusers'  is null.");
            }
            var aspNetUser = await _context.aspnetusers.FindAsync(id);
            if (aspNetUser != null)
            {
                _context.aspnetusers.Remove(aspNetUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUserExists(string id)
        {
          return (_context.aspnetusers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
