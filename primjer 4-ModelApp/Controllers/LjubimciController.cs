﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using primjer_4_ModelApp.Data;
using primjer_4_ModelApp.Models;

namespace primjer_4_ModelApp.Controllers
{
    public class LjubimciController : Controller
    {
        private readonly kb _context;

        public LjubimciController(kb context)
        {
            _context = context;
        }

        // GET: Ljubimci
        public async Task<IActionResult> Index()
        {
            var kb = _context.Ljubimac.Include(l => l.Vrsta);
            return View(await kb.ToListAsync());
        }

        // GET: Ljubimci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljubimac = await _context.Ljubimac
                .Include(l => l.Vrsta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ljubimac == null)
            {
                return NotFound();
            }

            return View(ljubimac);
        }

        // GET: Ljubimci/Create
        public IActionResult Create()
        {
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv");
            return View();
        }

        // POST: Ljubimci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,DatRod,Opis,VrstaId")] Ljubimac ljubimac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ljubimac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv", ljubimac.VrstaId);
            return View(ljubimac);
        }

        // GET: Ljubimci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljubimac = await _context.Ljubimac.FindAsync(id);
            if (ljubimac == null)
            {
                return NotFound();
            }
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv", ljubimac.VrstaId);
            return View(ljubimac);
        }

        // POST: Ljubimci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,DatRod,Opis,VrstaId")] Ljubimac ljubimac)
        {
            if (id != ljubimac.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ljubimac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LjubimacExists(ljubimac.Id))
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
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv", ljubimac.VrstaId);
            return View(ljubimac);
        }

        // GET: Ljubimci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ljubimac = await _context.Ljubimac
                .Include(l => l.Vrsta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ljubimac == null)
            {
                return NotFound();
            }

            return View(ljubimac);
        }

        // POST: Ljubimci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ljubimac = await _context.Ljubimac.FindAsync(id);
            _context.Ljubimac.Remove(ljubimac);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LjubimacExists(int id)
        {
            return _context.Ljubimac.Any(e => e.Id == id);
        }
    }
}
