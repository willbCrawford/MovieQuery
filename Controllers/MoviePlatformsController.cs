using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieQuery.Data;
using MovieQuery.Models;

namespace MovieQuery.Controllers
{
    public class MoviePlatformsController : Controller
    {
        private readonly MQDatabaseContext _context;

        public MoviePlatformsController(MQDatabaseContext context)
        {
            _context = context;
        }

        // GET: MoviePlatforms
        public async Task<IActionResult> Index()
        {
            var mQDatabaseContext = _context.MoviePlatform.Include(m => m.Movie).Include(m => m.Platform);
            return View(await mQDatabaseContext.ToListAsync());
        }

        // GET: MoviePlatforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePlatform = await _context.MoviePlatform
                .Include(m => m.Movie)
                .Include(m => m.Platform)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (moviePlatform == null)
            {
                return NotFound();
            }

            return View(moviePlatform);
        }

        // GET: MoviePlatforms/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Title");
            return View();
        }

        // POST: MoviePlatforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,PlatformId")] MoviePlatform moviePlatform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviePlatform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", moviePlatform.MovieId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Title", moviePlatform.PlatformId);
            return View(moviePlatform);
        }

        // GET: MoviePlatforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePlatform = await _context.MoviePlatform.FindAsync(id);
            if (moviePlatform == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", moviePlatform.MovieId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Title", moviePlatform.PlatformId);
            return View(moviePlatform);
        }

        // POST: MoviePlatforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,PlatformId")] MoviePlatform moviePlatform)
        {
            if (id != moviePlatform.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviePlatform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviePlatformExists(moviePlatform.MovieId))
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
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title", moviePlatform.MovieId);
            ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "Title", moviePlatform.PlatformId);
            return View(moviePlatform);
        }

        // GET: MoviePlatforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviePlatform = await _context.MoviePlatform
                .Include(m => m.Movie)
                .Include(m => m.Platform)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (moviePlatform == null)
            {
                return NotFound();
            }

            return View(moviePlatform);
        }

        // POST: MoviePlatforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviePlatform = await _context.MoviePlatform.FindAsync(id);
            _context.MoviePlatform.Remove(moviePlatform);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviePlatformExists(int id)
        {
            return _context.MoviePlatform.Any(e => e.MovieId == id);
        }
    }
}
