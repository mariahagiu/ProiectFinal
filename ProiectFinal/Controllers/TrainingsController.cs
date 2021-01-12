using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Data;
using ProiectFinal.Models;
using ProiectFinal.Views;

namespace ProiectFinal.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly ProgramContext _context;

        public TrainingsController(ProgramContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public async Task<IActionResult> Index(string sortOrder, string currentFilter,string searchString, int? pageNumber)
        {
            
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DurationSortParm"] = sortOrder == "Duration" ? "Duration_desc" : "Duration";
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var trainings = from b in _context.Trainings
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                trainings = trainings.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    trainings = trainings.OrderByDescending(b => b.Name);
                    break;
                case "Duration":
                    trainings = trainings.OrderBy(b => b.Duration);
                    break;
                case "Duration_desc":
                    trainings = trainings.OrderByDescending(b => b.Duration);
                    break;
                default:
                    trainings = trainings.OrderBy(b => b.Name);
                    break;
            }
            int pageSize = 4;
            return View(await PaginatedList<Training>.CreateAsync(trainings.AsNoTracking(), pageNumber ?? 1, pageSize));
            
            
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .Include(s => s.Appointments)
                .ThenInclude(f => f.Instructor)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Type,Duration,Difficulty,Days")] Training training)
        {
            try
            {
                if (ModelState.IsValid)
            {
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            }
            catch (DbUpdateException /* ex*/)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists ");
            }
            return View(training);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var training = await _context.Trainings.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Training>(training,"",
                s => s.Name, s => s.Type, s => s.Duration, s=>s.Difficulty, s=>s.Days))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists");
                }
            }
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Trainings
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (training == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                "Delete failed. Try again";
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var training = await _context.Trainings.FindAsync(id);
            if (training == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool TrainingExists(int id)
        {
            return _context.Trainings.Any(e => e.ID == id);
        }
    }
}
