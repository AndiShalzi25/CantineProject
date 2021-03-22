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
    [ApiController]
    [Route("api/{controller}")]
    public class SectorCategoriesController : Controller
    {
        private readonly Context _context;

        public SectorCategoriesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.sectorCategories.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorCategory = await _context.sectorCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sectorCategory == null)
            {
                return NotFound();
            }

            return View(sectorCategory);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [Route("Post")]
      
        public async Task<IActionResult> Create(SectorCategory sectorCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectorCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectorCategory);
        }

        // GET: SectorCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorCategory = await _context.sectorCategories.FindAsync(id);
            if (sectorCategory == null)
            {
                return NotFound();
            }
            return View(sectorCategory);
        }

       
        [HttpPut]
        [Route("Put/{id}")]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Code,IsActive")] SectorCategory sectorCategory)
        {
            if (id != sectorCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectorCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorCategoryExists(sectorCategory.Id))
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
            return View(sectorCategory);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorCategory = await _context.sectorCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sectorCategory == null)
            {
                return NotFound();
            }

            return View(sectorCategory);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sectorCategory = await _context.sectorCategories.FindAsync(id);
            _context.sectorCategories.Remove(sectorCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorCategoryExists(int id)
        {
            return _context.sectorCategories.Any(e => e.Id == id);
        }
    }
}
