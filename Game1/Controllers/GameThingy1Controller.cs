using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Game1.Data;
using Game1.Models;

namespace Game1.Controllers
{
    public class GameThingy1Controller : Controller
    {
        private readonly Game1Context _context;

        public GameThingy1Controller(Game1Context context)
        {
            _context = context;
        }

        // GET: GameThingy1
        public async Task<IActionResult> Index()
        {
              return _context.GameThingy1 != null ? 
                          View(await _context.GameThingy1.ToListAsync()) :
                          Problem("Entity set 'Game1Context.GameThingy1'  is null.");
        }

        // GET: GameThingy1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GameThingy1 == null)
            {
                return NotFound();
            }

            var gameThingy1 = await _context.GameThingy1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameThingy1 == null)
            {
                return NotFound();
            }

            return View(gameThingy1);
        }

        // GET: GameThingy1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameThingy1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] GameThingy1 gameThingy1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameThingy1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gameThingy1);
        }

        // GET: GameThingy1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GameThingy1 == null)
            {
                return NotFound();
            }

            var gameThingy1 = await _context.GameThingy1.FindAsync(id);
            if (gameThingy1 == null)
            {
                return NotFound();
            }
            return View(gameThingy1);
        }

        // POST: GameThingy1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] GameThingy1 gameThingy1)
        {
            if (id != gameThingy1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameThingy1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameThingy1Exists(gameThingy1.Id))
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
            return View(gameThingy1);
        }

        // GET: GameThingy1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GameThingy1 == null)
            {
                return NotFound();
            }

            var gameThingy1 = await _context.GameThingy1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameThingy1 == null)
            {
                return NotFound();
            }

            return View(gameThingy1);
        }

        // POST: GameThingy1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GameThingy1 == null)
            {
                return Problem("Entity set 'Game1Context.GameThingy1'  is null.");
            }
            var gameThingy1 = await _context.GameThingy1.FindAsync(id);
            if (gameThingy1 != null)
            {
                _context.GameThingy1.Remove(gameThingy1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameThingy1Exists(int id)
        {
          return (_context.GameThingy1?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
