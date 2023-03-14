using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedDBAndORM_Assignment1.Data;
using AdvancedDBAndORM_Assignment1.Models.ModelVM;

namespace AdvancedDBAndORM_Assignment1.Controllers
{
    public class SongVersionPlayListVMsController : Controller
    {
        private readonly DBContext _context;

        public SongVersionPlayListVMsController(DBContext context)
        {
            _context = context;
        }

        // GET: SongVersionPlayListVMs
        public async Task<IActionResult> Index(int playListID)
        {
            
                var result = await (from e in _context.Songs
                                    join f in _context.SongVersions
                                    on e.ID equals f.SongID
                                    join m in _context.Albums
                                    on f.AlbumID equals m.ID
                                    join n in _context.Artists
                                    on f.ArtistID equals n.ID
                                    join g in _context.PlayLists
                                    on f.ID equals g.SongVersionID
                                    where g.LibraryID == playListID
                                    select (new { songName = e.Name, artistName = n.Name,albumName=m.Name,durationSec=f.Duration,duration=((f.Duration/60).ToString("00")+":"+ (Math.Round((f.Duration % 60)*1.0, 2)).ToString("00")),songVersionID =f.ID })).ToListAsync();

                 HashSet<SongVersionPlayListVM> SongVersionPlayListVMs= new HashSet<SongVersionPlayListVM>();

                foreach (var item in result)
                {
                SongVersionPlayListVMs.Add(new SongVersionPlayListVM(item.songVersionID, null, item.songName, null, item.artistName, null, item.albumName, null, item.duration,item.durationSec));
                }

               ViewBag.TotalSec = SongVersionPlayListVMs.Sum(e => e.DurationSec);
               ViewBag.ItemNum = SongVersionPlayListVMs.Count();

               var playList = await _context.Librarys.Where(e => e.ID == playListID).FirstOrDefaultAsync();
               if(playList!=null)
                 ViewBag.PlayListName=playList.Name;
               
                return View(SongVersionPlayListVMs);
             
        }

        // GET: SongVersionPlayListVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SongVersionPlayListVM == null)
            {
                return NotFound();
            }

            var songVersionPlayListVM = await _context.SongVersionPlayListVM
                .FirstOrDefaultAsync(m => m.ID == id);
            if (songVersionPlayListVM == null)
            {
                return NotFound();
            }

            return View(songVersionPlayListVM);
        }

        // GET: SongVersionPlayListVMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SongVersionPlayListVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SongVersionID,SongID,SongName,ArtistID,ArtistName,AlbumID,AlbumName,LibraryID,Duration")] SongVersionPlayListVM songVersionPlayListVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songVersionPlayListVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(songVersionPlayListVM);
        }

        // GET: SongVersionPlayListVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SongVersionPlayListVM == null)
            {
                return NotFound();
            }

            var songVersionPlayListVM = await _context.SongVersionPlayListVM.FindAsync(id);
            if (songVersionPlayListVM == null)
            {
                return NotFound();
            }
            return View(songVersionPlayListVM);
        }

        // POST: SongVersionPlayListVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SongVersionID,SongID,SongName,ArtistID,ArtistName,AlbumID,AlbumName,LibraryID,Duration")] SongVersionPlayListVM songVersionPlayListVM)
        {
            if (id != songVersionPlayListVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songVersionPlayListVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongVersionPlayListVMExists(songVersionPlayListVM.ID))
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
            return View(songVersionPlayListVM);
        }

        // GET: SongVersionPlayListVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            return View();
        }

        // POST: SongVersionPlayListVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (_context. == null)
            //{
            //    return Problem("Entity set 'DBContext.SongVersionPlayListVM'  is null.");
            //}
            var playListItem = await _context.PlayLists.Where(e=>e.SongVersionID == id).FirstOrDefaultAsync();
            if (playListItem != null)
            {
                _context.PlayLists.Remove(playListItem);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index), new { playListID = playListItem.LibraryID });
            }
            return Problem("Entity set 'DBContext.SongVersionPlayListVM'  is null.");

        }

        private bool SongVersionPlayListVMExists(int id)
        {
          return _context.SongVersionPlayListVM.Any(e => e.ID == id);
        }
    }
}
