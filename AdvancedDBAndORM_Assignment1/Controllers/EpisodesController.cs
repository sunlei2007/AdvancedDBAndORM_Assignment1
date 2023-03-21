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
    public class EpisodesController : Controller
    {
        private readonly DBContext _context;

        public EpisodesController(DBContext context)
        {
            _context = context;
        }

        // GET: Episodes
        public async Task<IActionResult> Index()
        {
              return _context.Episodes != null ? 
                          View(await _context.Episodes.ToListAsync()) :
                          Problem("Entity set 'DBContext.Episodes'  is null.");
        }
        public async Task<IActionResult> GetByPodcastID(int podcastID)
        {

            var exp = from a in _context.Podcasts
                                join b in _context.PodcastEpisodes
                                on a.ID equals b.PodcastID
                                join c in _context.Episodes
                                on b.EpisodeID equals c.ID
                                select new { ID = c.ID, Name = c.Name, CreateDate = c.CreateDate,Duration=  ((c.Dration / 60).ToString("00") + ":" + (Math.Round((c.Dration % 60) * 1.0, 2)).ToString("00")), PodcastID = a.ID };

            if (podcastID != null)
                exp = exp.Where(e => e.PodcastID == podcastID);

            var result = await exp.ToListAsync();

            HashSet<EpisodeVM> episodeVMs = new HashSet<EpisodeVM>();
            foreach (var item in result)
            {
                episodeVMs.Add(new EpisodeVM(item.ID, item.Name, item.CreateDate.ToString("MM/dd/yyyy"),item.Duration));
            }

            return View("Index", episodeVMs);

        }
        // GET: Episodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }

            var episode = await _context.Episodes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        // GET: Episodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Episodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreateDate,ID,Name")] Episode episode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(episode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(episode);
        }

        // GET: Episodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }

            var episode = await _context.Episodes.FindAsync(id);
            if (episode == null)
            {
                return NotFound();
            }
            return View(episode);
        }

        // POST: Episodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreateDate,ID,Name")] Episode episode)
        {
            if (id != episode.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodeExists(episode.ID))
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
            return View(episode);
        }

        // GET: Episodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Episodes == null)
            {
                return NotFound();
            }

            var episode = await _context.Episodes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        // POST: Episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Episodes == null)
            {
                return Problem("Entity set 'DBContext.Episodes'  is null.");
            }
            var episode = await _context.Episodes.FindAsync(id);
            if (episode != null)
            {
                _context.Episodes.Remove(episode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodeExists(int id)
        {
          return (_context.Episodes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
