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
    public class PodcastsController : Controller
    {
        private readonly DBContext _context;

        public PodcastsController(DBContext context)
        {
            _context = context;
        }

        // GET: Podcasts
        public async Task<IActionResult> Index()
        {
            var exp = from a in _context.Podcasts
                      join b in _context.Artists
                      on a.ArtistID equals b.ID
                      select new { ID = a.ID, Name = a.Name, ArtistName = b.Name };
            
            var result = await exp.ToListAsync();
            HashSet<PodcastVM> podcastVMs = new HashSet<PodcastVM>();

            foreach (var item in result)
            {
                podcastVMs.Add(new PodcastVM(item.ID, item.Name,item.ArtistName));
            }
           

            return View(podcastVMs);
        }

        public async Task<IActionResult> GetList(int? lsID)
        {
            var exp = from a in _context.Podcasts
                      join b in _context.PodcastListeners
                      on a.ID equals b.PodcastID
                      join c in _context.Listeners
                      on b.ListenerID equals c.ID
                      join d in _context.Artists
                      on a.ArtistID equals d.ID
                      select new { ID = a.ID, Name = a.Name, ArtistName =d.Name, ListenerID=c.ID };

            if (lsID != null)
                exp = exp.Where(e => e.ListenerID == lsID);

            var result = await exp.ToListAsync();
            HashSet<PodcastVM> podcastVMs = new HashSet<PodcastVM>();

            foreach (var item in result)
            {
                podcastVMs.Add(new PodcastVM(item.ID, item.Name, item.ArtistName));
            }


            return View("Index",podcastVMs);
        }

        // GET: Podcasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Podcasts == null)
            {
                return NotFound();
            }

            return RedirectToAction(actionName: "GetByPodcastID", controllerName: "Episodes", new { podcastID = id });
        }

        // GET: Podcasts/Create
        public IActionResult Create()
        {
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ID", "Name");
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,ArtistID")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ID", "Name", podcast.ArtistID);
            return View(podcast);
        }

        // GET: Podcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Podcasts == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcasts.FindAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ID", "Name", podcast.ArtistID);
            return View(podcast);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ArtistID")] Podcast podcast)
        {
            if (id != podcast.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastExists(podcast.ID))
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
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ID", "Name", podcast.ArtistID);
            return View(podcast);
        }

        // GET: Podcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Podcasts == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcasts
                .Include(p => p.Artist)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Podcasts == null)
            {
                return Problem("Entity set 'DBContext.Podcasts'  is null.");
            }
            var podcast = await _context.Podcasts.FindAsync(id);
            if (podcast != null)
            {
                _context.Podcasts.Remove(podcast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PodcastExists(int id)
        {
          return (_context.Podcasts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
