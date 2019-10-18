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
    public class MovieCreditsController : Controller
    {
        private readonly MQDatabaseContext _context;

        public MovieCreditsController(MQDatabaseContext context)
        {
            _context = context;
        }

        // GET: MovieCredits
        public async Task<IActionResult> Index()
        {
            var mQDatabaseContext = _context.MovieCredit.Include(m => m.Credit).Include(m => m.Movie);
            return View(await mQDatabaseContext.ToListAsync());
        }

        // GET: MovieCredits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCredit = await _context.MovieCredit
                .Include(m => m.Credit)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieCredit == null)
            {
                return NotFound();
            }

            return View(movieCredit);
        }

        // GET: MovieCredits/Create
        public IActionResult Create()
        {
            ViewData["CreditId"] = new SelectList(_context.Credits, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            return View();
        }

        // POST: MovieCredits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,CreditId")] MovieCredit movieCredit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieCredit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreditId"] = new SelectList(_context.Credits, "Id", "Id", movieCredit.CreditId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieCredit.MovieId);
            return View(movieCredit);
        }

        // GET: MovieCredits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCredit = await _context.MovieCredit.FindAsync(id);
            if (movieCredit == null)
            {
                return NotFound();
            }
            ViewData["CreditId"] = new SelectList(_context.Credits, "Id", "Id", movieCredit.CreditId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieCredit.MovieId);
            return View(movieCredit);
        }

        // POST: MovieCredits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,CreditId")] MovieCredit movieCredit)
        {
            if (id != movieCredit.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieCredit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieCreditExists(movieCredit.MovieId))
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
            ViewData["CreditId"] = new SelectList(_context.Credits, "Id", "Id", movieCredit.CreditId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieCredit.MovieId);
            return View(movieCredit);
        }

        // GET: MovieCredits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieCredit = await _context.MovieCredit
                .Include(m => m.Credit)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movieCredit == null)
            {
                return NotFound();
            }

            return View(movieCredit);
        }

        // POST: MovieCredits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieCredit = await _context.MovieCredit.FindAsync(id);
            _context.MovieCredit.Remove(movieCredit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieCreditExists(int id)
        {
            return _context.MovieCredit.Any(e => e.MovieId == id);
        }
    }
}
