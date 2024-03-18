using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGO_HubConnect.Models;
using Project_NGO_HubConnect.Data;


namespace NGO_HubConnect.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly MyDbContext _context;

        public EnrollmentsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {

            //var myDbContext = _context.Enrollment.Include(e => e.Event).Include(e => e.User);
            return View(await _context.Enrollment.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Event)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Email == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        //public IActionResult Create(String Email, String EventId)
        //{
        //    ViewData["EventId"] = new SelectList(_context.Event, "Event_ID", "EventType", EventId);
        //    ViewData["Email"] = new SelectList(_context.Users, "Id", "Id", Email);
        //    return View();
        //}

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,EventId,EventName,Location")] Enrollment enrollment)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                //}
                //ViewData["EventId"] = enrollment.EventId;
                //ViewData["Email"] = enrollment.Email;
                ViewData["Message"] = "You are succuesfully Registered for the event";
                return View(enrollment);
            }
            catch (DbUpdateException ex)
            {
                ViewData["Message"] = "You are already Registered for the event";
                return View(enrollment);
            }
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Enrollment == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Event, "Event_ID", "EventType", enrollment.EventId);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Id", enrollment.Email);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,EventId")] Enrollment enrollment)
        {
            if (id != enrollment.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Email))
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
            ViewData["EventId"] = new SelectList(_context.Event, "Event_ID", "EventType", enrollment.EventId);
            ViewData["Email"] = new SelectList(_context.Users, "Id", "Id", enrollment.Email);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _context.Enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    var enrollment = await _context.Enrollment
        //        .Include(e => e.Event)
        //        .Include(e => e.User)
        //        .FirstOrDefaultAsync(m => m.Email == id);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(enrollment);
        //}

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("Email,EventId,EventName,Location")] Enrollment enrollment)
        {
            if (_context.Enrollment == null)
            {
                return Problem("Entity set 'MyDbContext.Enrollment'  is null.");
            }

            if (enrollment != null)
            {
                _context.Enrollment.Remove(enrollment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(string id)
        {
            return (_context.Enrollment?.Any(e => e.Email == id)).GetValueOrDefault();
        }
    }
}
