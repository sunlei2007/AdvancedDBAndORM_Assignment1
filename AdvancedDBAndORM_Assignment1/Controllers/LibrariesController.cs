using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedDBAndORM_Assignment1.Data;
using AdvancedDBAndORM_Assignment1.Models;

namespace AdvancedDBAndORM_Assignment1.Controllers
{
    public class LibrariesController : Controller
    {
        private readonly DBContext _context;

        public LibrariesController(DBContext context)
        {
            _context = context;
        }

        // GET: Libraries
        public async Task<IActionResult> Index()
        {
              return View(await _context.Librarys.ToListAsync());
        }

        // GET: Libraries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Librarys == null)
            {
                return NotFound();
            }

            var library = await _context.Librarys
                .FirstOrDefaultAsync(m => m.ID == id);
            if (library == null)
            {
                return NotFound();
            }

            return RedirectToAction(actionName: "Index", controllerName: "SongVersionPlayListVMs", new { playListID = id }); 
        }

        // GET: Libraries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Library library)
        {
            if (ModelState.IsValid)
            {
                _context.Add(library);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(library);
        }

        // GET: Libraries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Librarys == null)
            {
                return NotFound();
            }

            var library = await _context.Librarys.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Library library)
        {
            if (id != library.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(library);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryExists(library.ID))
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
            return View(library);
        }

        // GET: Libraries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Librarys == null)
            {
                return NotFound();
            }

            var library = await _context.Librarys
                .FirstOrDefaultAsync(m => m.ID == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // POST: Libraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Librarys == null)
            {
                return Problem("Entity set 'DBContext.Librarys'  is null.");
            }
            var library = await _context.Librarys.FindAsync(id);
            if (library != null)
            {
                _context.Librarys.Remove(library);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryExists(int id)
        {
          return _context.Librarys.Any(e => e.ID == id);
        }
    }
}
