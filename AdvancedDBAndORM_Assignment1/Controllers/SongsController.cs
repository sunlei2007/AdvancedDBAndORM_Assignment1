using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedDBAndORM_Assignment1.Data;
using AdvancedDBAndORM_Assignment1.Models;
using AdvancedDBAndORM_Assignment1.Models.ModelVM;

namespace AdvancedDBAndORM_Assignment1.Controllers
{
    public class SongsController : Controller
    {
        private readonly DBContext _context;

        public SongsController(DBContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            TempData["AlbumID"] = 0;
            var result = await GetList(null);
            return View(result);
        }
        public async Task<IActionResult> GetByAlbumID(int albumID)
        {
            TempData["AlbumID"] = albumID;
            var album= await _context.Albums.Where(e => e.ID == albumID).FirstAsync();
            ViewBag.AlbumName= album.Name;
            var result = await GetList(albumID);
            return View("Index", result);
             
        }

        public async Task<HashSet<SongVM>> GetList(int? albumID)
        {
            var exp =    from a in _context.Songs
                         join b in _context.SongVersions
                         on a.ID equals b.SongID                       
                         select new { ID = a.ID, Name = a.Name, SongVersionID = b.ID, AlbumID=b.AlbumID };

            if (albumID!=null)
                exp = exp.Where(e => e.AlbumID==albumID);

            var result = await exp.ToListAsync();
            HashSet<SongVM> songVMs = new HashSet<SongVM>();

            foreach (var item in result)
            {
                var playListName = await (from a in _context.PlayLists
                                          join b in _context.Librarys
                                          on a.LibraryID equals b.ID
                                          where a.SongVersionID == item.SongVersionID
                                          select b).FirstOrDefaultAsync();
                songVMs.Add(new SongVM(item.ID, item.Name, playListName == null ? "" : playListName.Name));
            }
            return songVMs;
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }
            
             
              return RedirectToAction(actionName: "Index", controllerName: "AddToPLayList", new { songID = id,AlbumID= TempData["AlbumID"]==null?0: Convert.ToInt16(TempData["AlbumID"]) });
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Song song)
        {
            if (id != song.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.ID))
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
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Songs == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Songs == null)
            {
                return Problem("Entity set 'DBContext.Songs'  is null.");
            }
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
          return _context.Songs.Any(e => e.ID == id);
        }
    }
}
