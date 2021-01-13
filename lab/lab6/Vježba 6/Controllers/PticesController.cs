using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vježba_6.Data;
using Vježba_6.Models;

namespace Vježba_6.Controllers
{
    public class PticesController : Controller
    {
        private readonly PticeContext _context;

        public PticesController(PticeContext context)
        {
            _context = context;
        }

        // GET: Ptices
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ptice.ToListAsync());
        }

        // GET: Ptices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ptice = await _context.Ptice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ptice == null)
            {
                return NotFound();
            }

            return View(ptice);
        }

        // GET: Ptices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ptices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Vrsta,DatSnimanja")] Ptice ptice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ptice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ptice);
        }

        // GET: Ptices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ptice = await _context.Ptice.FindAsync(id);
            if (ptice == null)
            {
                return NotFound();
            }
            return View(ptice);
        }

        // POST: Ptices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Vrsta,DatSnimanja")] Ptice ptice)
        {
            if (id != ptice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ptice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PticeExists(ptice.Id))
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
            return View(ptice);
        }

        // GET: Ptices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ptice = await _context.Ptice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ptice == null)
            {
                return NotFound();
            }

            return View(ptice);
        }

        // POST: Ptices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ptice = await _context.Ptice.FindAsync(id);
            _context.Ptice.Remove(ptice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PticeExists(int id)
        {
            return _context.Ptice.Any(e => e.Id == id);
        }
    }
}
