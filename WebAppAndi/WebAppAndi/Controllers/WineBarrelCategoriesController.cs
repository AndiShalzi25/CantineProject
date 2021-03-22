using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAndi.Data;
using WebAppAndi.Models;

namespace WebAppAndi.Controllers
{
    
    public class WineBarrelCategoriesController : Controller
    {
        private readonly Context _context;

        public WineBarrelCategoriesController(Context context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var context = _context.wineBarrelCategories.Include(w => w.SectorCategory);
            return View(await context.ToListAsync());
        }

        // GET: WineBarrelCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wineBarrelCategory = await _context.wineBarrelCategories
                .Include(w => w.SectorCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wineBarrelCategory == null)
            {
                return NotFound();
            }

            return View(wineBarrelCategory);
        }

        // GET: WineBarrelCategories/Create
        public IActionResult Create()
        {
            ViewData["SectorCategoryId"] = new SelectList(_context.sectorCategories, "Id", "Id");
            return View();
        }

        // POST: WineBarrelCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Code,Volume,type,SectorCategoryId")] WineBarrelCategory wineBarrelCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wineBarrelCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SectorCategoryId"] = new SelectList(_context.sectorCategories, "Id", "Id", wineBarrelCategory.SectorCategoryId);
            return View(wineBarrelCategory);
        }

        // GET: WineBarrelCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wineBarrelCategory = await _context.wineBarrelCategories.FindAsync(id);
            if (wineBarrelCategory == null)
            {
                return NotFound();
            }
            ViewData["SectorCategoryId"] = new SelectList(_context.sectorCategories, "Id", "Id", wineBarrelCategory.SectorCategoryId);
            return View(wineBarrelCategory);
        }

        // POST: WineBarrelCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Code,Volume,type,SectorCategoryId")] WineBarrelCategory wineBarrelCategory)
        {
            if (id != wineBarrelCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wineBarrelCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineBarrelCategoryExists(wineBarrelCategory.Id))
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
            ViewData["SectorCategoryId"] = new SelectList(_context.sectorCategories, "Id", "Id", wineBarrelCategory.SectorCategoryId);
            return View(wineBarrelCategory);
        }

        // GET: WineBarrelCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wineBarrelCategory = await _context.wineBarrelCategories
                .Include(w => w.SectorCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wineBarrelCategory == null)
            {
                return NotFound();
            }

            return View(wineBarrelCategory);
        }

        // POST: WineBarrelCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wineBarrelCategory = await _context.wineBarrelCategories.FindAsync(id);
            _context.wineBarrelCategories.Remove(wineBarrelCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WineBarrelCategoryExists(int id)
        {
            return _context.wineBarrelCategories.Any(e => e.Id == id);
        }
    }
}
