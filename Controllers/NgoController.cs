using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_NGO_HubConnect.Data;
using Project_NGO_HubConnect.Models;

namespace NGO_HubConnect.Controllers
{
    public class NgoController : Controller
    {
        private readonly MyDbContext _context;

        public NgoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Ngo
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var isAdmin = User.IsInRole("Admin");

            if (isAdmin)
            {
                var allNgos = await _context.Ngo.ToListAsync();
                return View(allNgos);
            }
            else
            {
                return _context.Ngo != null ?
                        View(await _context.Ngo.Where(n => n.IsApproved).ToListAsync()) :
                        Problem("Entity set 'MyDbContext.Ngo' is null.");
            }
        }

        // GET: Ngo/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ngo == null)
            {
                return NotFound();
            }

            var ngo = await _context.Ngo
                .FirstOrDefaultAsync(m => m.NGO_id == id && m.IsApproved);
            if (ngo == null)
            {
                return NotFound();
            }

            return View(ngo);
        }

        // GET: Ngo/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ngo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NGO_id,Organization_Name,Darpan_ID,Email,Vision,Phone,Address,Website,YearOfEstablishment,KeyFocusAreas")] Ngo ngo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ngo);
        }

        // GET: Ngo/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ngo == null)
            {
                return NotFound();
            }

            var ngo = await _context.Ngo.FindAsync(id);
            if (ngo == null)
            {
                return NotFound();
            }
            return View(ngo);
        }

        // POST: Ngo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NGO_id,Organization_Name,Darpan_ID,Email,Vision,Phone,Address,Website,YearOfEstablishment,KeyFocusAreas")] Ngo ngo)
        {
            if (id != ngo.NGO_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgoExists(ngo.NGO_id))
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
            return View(ngo);
        }

        // GET: Ngo/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ngo == null)
            {
                return NotFound();
            }

            var ngo = await _context.Ngo
                .FirstOrDefaultAsync(m => m.NGO_id == id);
            if (ngo == null)
            {
                return NotFound();
            }

            return View(ngo);
        }

        // POST: Ngo/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ngo == null)
            {
                return Problem("Entity set 'MyDbContext.Ngo'  is null.");
            }
            var ngo = await _context.Ngo.FindAsync(id);
            if (ngo != null)
            {
                _context.Ngo.Remove(ngo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Ngo/Approve
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngo = await _context.Ngo.FindAsync(id);
            if (ngo == null)
            {
                return NotFound();
            }

            ngo.IsApproved = true;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // POST: Ngo/Disapprove
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Disapprove(int? NGO_id)
        {
            if (NGO_id == null)
            {
                return NotFound();
            }

            var ngo = await _context.Ngo.FindAsync(NGO_id);
            if (ngo == null)
            {
                return NotFound();
            }

            ngo.IsApproved = false; // Mark the NGO as disapproved
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool NgoExists(int id)
        {
          return (_context.Ngo?.Any(e => e.NGO_id == id)).GetValueOrDefault();
        }
    }
}
