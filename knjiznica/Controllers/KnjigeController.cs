using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using knjiznica.Data;
using knjiznica.Models;

namespace knjiznica.Controllers
{
    public class KnjigeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KnjigeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Knjige
        public async Task<IActionResult> Index()
        {
            return View(await _context.Knjige.ToListAsync());
        }

        // GET: Knjige/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjige = await _context.Knjige
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knjige == null)
            {
                return NotFound();
            }

            return View(knjige);
        }

        // GET: Knjige/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Knjige/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,naslov,Izdavač,ISBN,datumIzdavanja")] Knjige knjige)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knjige);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(knjige);
        }

        // GET: Knjige/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjige = await _context.Knjige.FindAsync(id);
            if (knjige == null)
            {
                return NotFound();
            }
            return View(knjige);
        }

        // POST: Knjige/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,naslov,Izdavač,ISBN,datumIzdavanja")] Knjige knjige)
        {
            if (id != knjige.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knjige);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnjigeExists(knjige.Id))
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
            return View(knjige);
        }

        // GET: Knjige/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjige = await _context.Knjige
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knjige == null)
            {
                return NotFound();
            }

            return View(knjige);
        }

        // POST: Knjige/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var knjige = await _context.Knjige.FindAsync(id);
            _context.Knjige.Remove(knjige);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnjigeExists(int id)
        {
            return _context.Knjige.Any(e => e.Id == id);
        }
    }
}
