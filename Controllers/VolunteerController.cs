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
    public class VolunteerController : Controller
    {
        private readonly MyDbContext _context;

        public VolunteerController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Volunteer
        [Authorize]
        public async Task<IActionResult> Index()
        {
              return _context.Volunteer != null ? 
                          View(await _context.Volunteer.ToListAsync()) :
                          Problem("Entity set 'MyDbContext.Volunteer'  is null.");
        }

        // GET: Volunteer/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Volunteer == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .FirstOrDefaultAsync(m => m.Volunteer_ID == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // GET: Volunteer/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Volunteer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Volunteer_ID,Name,DateOfBirth,Gender,Phone,Email,Address,Occupation,Education,Interest,Language,Password")] Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(volunteer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(volunteer);
        }

        // GET: Volunteer/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Volunteer == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Volunteer_ID,Name,DateOfBirth,Gender,Phone,Email,Address,Occupation,Education,Interest,Language,Password")] Volunteer volunteer)
        {
            if (id != volunteer.Volunteer_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volunteer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VolunteerExists(volunteer.Volunteer_ID))
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
            return View(volunteer);
        }

        // GET: Volunteer/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Volunteer == null)
            {
                return NotFound();
            }

            var volunteer = await _context.Volunteer
                .FirstOrDefaultAsync(m => m.Volunteer_ID == id);
            if (volunteer == null)
            {
                return NotFound();
            }

            return View(volunteer);
        }

        // POST: Volunteer/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Volunteer == null)
            {
                return Problem("Entity set 'MyDbContext.Volunteer'  is null.");
            }
            var volunteer = await _context.Volunteer.FindAsync(id);
            if (volunteer != null)
            {
                _context.Volunteer.Remove(volunteer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VolunteerExists(int id)
        {
          return (_context.Volunteer?.Any(e => e.Volunteer_ID == id)).GetValueOrDefault();
        }
    }
}
