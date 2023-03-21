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
    public class ListenersController : Controller
    {
        private readonly DBContext _context;

        public ListenersController(DBContext context)
        {
            _context = context;
        }

        // GET: Listeners
        public async Task<IActionResult> Index()
        {
              return _context.Listeners != null ? 
                          View(await _context.Listeners.ToListAsync()) :
                          Problem("Entity set 'DBContext.Listeners'  is null.");
        }

        // GET: Listeners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Listeners == null)
            {
                return NotFound();
            }

            var listener = await _context.Listeners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listener == null)
            {
                return NotFound();
            }
            
             return RedirectToAction(actionName: "GetList", controllerName: "Podcasts", new { lsID = id });
        }

        // GET: Listeners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listeners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Listener listener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listener);
        }

        // GET: Listeners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Listeners == null)
            {
                return NotFound();
            }

            var listener = await _context.Listeners.FindAsync(id);
            if (listener == null)
            {
                return NotFound();
            }
            return View(listener);
        }

        // POST: Listeners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Listener listener)
        {
            if (id != listener.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListenerExists(listener.ID))
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
            return View(listener);
        }

        // GET: Listeners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Listeners == null)
            {
                return NotFound();
            }

            var listener = await _context.Listeners
                .FirstOrDefaultAsync(m => m.ID == id);
            if (listener == null)
            {
                return NotFound();
            }

            return View(listener);
        }

        // POST: Listeners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Listeners == null)
            {
                return Problem("Entity set 'DBContext.Listeners'  is null.");
            }
            var listener = await _context.Listeners.FindAsync(id);
            if (listener != null)
            {
                _context.Listeners.Remove(listener);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListenerExists(int id)
        {
          return (_context.Listeners?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
