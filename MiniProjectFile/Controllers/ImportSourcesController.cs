using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProjectFile.Models;

namespace MiniProjectFile.Controllers
{
    public class ImportSourcesController : Controller
    {
        private readonly EntityFrameWork _context;

        public ImportSourcesController(EntityFrameWork context)
        {
            _context = context;
        }

        // GET: ImportSources
        public async Task<IActionResult> Index()
        {
              return View(await _context.ImportSource.ToListAsync());
        }

        // GET: ImportSources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImportSource == null)
            {
                return NotFound();
            }

            var importSource = await _context.ImportSource
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importSource == null)
            {
                return NotFound();
            }

            return View(importSource);
        }

        // GET: ImportSources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImportSources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FileName,FilePath,FileFormat,CreatedBy,CreatedOn")] ImportSource importSource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(importSource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(importSource);
        }

        // GET: ImportSources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImportSource == null)
            {
                return NotFound();
            }

            var importSource = await _context.ImportSource.FindAsync(id);
            if (importSource == null)
            {
                return NotFound();
            }
            return View(importSource);
        }

        // POST: ImportSources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FileName,FilePath,FileFormat,CreatedBy,CreatedOn")] ImportSource importSource)
        {
            if (id != importSource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(importSource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportSourceExists(importSource.Id))
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
            return View(importSource);
        }

        // GET: ImportSources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImportSource == null)
            {
                return NotFound();
            }

            var importSource = await _context.ImportSource
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importSource == null)
            {
                return NotFound();
            }

            return View(importSource);
        }

        // POST: ImportSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImportSource == null)
            {
                return Problem("Entity set 'EntityFrameWork.ImportSource'  is null.");
            }
            var importSource = await _context.ImportSource.FindAsync(id);
            if (importSource != null)
            {
                _context.ImportSource.Remove(importSource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportSourceExists(int id)
        {
          return _context.ImportSource.Any(e => e.Id == id);
        }
    }
}
