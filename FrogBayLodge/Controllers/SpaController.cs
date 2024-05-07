using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrogBayLodge.Data;
using FrogBayLodge.Models;

namespace FrogBayLodge.Controllers
{
    public class SpaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spa
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spa.ToListAsync());
        }

        // GET: Spa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spa = await _context.Spa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spa == null)
            {
                return NotFound();
            }

            return View(spa);
        }

        // GET: Spa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Package,Price,Description")] Spa spa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spa);
        }

        // GET: Spa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spa = await _context.Spa.FindAsync(id);
            if (spa == null)
            {
                return NotFound();
            }
            return View(spa);
        }

        // POST: Spa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Package,Price,Description")] Spa spa)
        {
            if (id != spa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaExists(spa.Id))
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
            return View(spa);
        }

        // GET: Spa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spa = await _context.Spa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spa == null)
            {
                return NotFound();
            }

            return View(spa);
        }

        // POST: Spa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spa = await _context.Spa.FindAsync(id);
            if (spa != null)
            {
                _context.Spa.Remove(spa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaExists(int id)
        {
            return _context.Spa.Any(e => e.Id == id);
        }
    }
}
