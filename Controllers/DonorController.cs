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
    public class DonorController : Controller
    {
        private readonly MyDbContext _context;

        public DonorController(MyDbContext context)
        {
            _context = context;
        }
        // GET: Donor
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.Donor != null ? 
                          View(await _context.Donor.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Donor'  is null.");
        }

        // GET: Donor/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Donor == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor
                .FirstOrDefaultAsync(m => m.Donor_ID == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // GET: Donor/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Donor_ID,Name,DateOfBirth,Email,Phone,Address,DonorType,Password")] Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donor);
        }

        // GET: Donor/Edit/5
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Donor == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor);
        }

        // POST: Donor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Donor_ID,Name,DateOfBirth,Email,Phone,Address,DonorType,Password")] Donor donor)
        {
            if (id != donor.Donor_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.Donor_ID))
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
            return View(donor);
        }

        // GET: Donor/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Donor == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor
                .FirstOrDefaultAsync(m => m.Donor_ID == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: Donor/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Donor == null)
            {
                return Problem("Entity set 'MyDbContext.Donor'  is null.");
            }
            var donor = await _context.Donor.FindAsync(id);
            if (donor != null)
            {
                _context.Donor.Remove(donor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult DonorBase()
        {
            return View();
        }

        private bool DonorExists(int id)
        {
          return (_context.Donor?.Any(e => e.Donor_ID == id)).GetValueOrDefault();
        }
    }
}
