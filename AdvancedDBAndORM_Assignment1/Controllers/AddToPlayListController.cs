using AdvancedDBAndORM_Assignment1.Data;
using AdvancedDBAndORM_Assignment1.Models;
using AdvancedDBAndORM_Assignment1.Models.ModelVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AdvancedDBAndORM_Assignment1.Controllers
{
    public class AddToPlayListController : Controller
    {
        private readonly DBContext _context;
        public AddToPlayListController(DBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int songID,int AlbumID)
        {
            var song= await _context.Songs.FirstAsync(e => e.ID == songID);
            TempData["SongID"] = songID;
            TempData["AlbumID"] = AlbumID;

            ViewBag.SongName=song.Name;
          
            List<Library> libraries = await _context.Librarys.ToListAsync();
            SongPlayListVM vm = new SongPlayListVM(libraries);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Add(int libraryID)
        {
            if (ModelState.IsValid)
            {
                SongVersion songVersion =await _context.SongVersions.Where(e => e.SongID == Convert.ToInt16(TempData["SongID"])).FirstAsync();
                var playList = await _context.PlayLists.Where(e => e.LibraryID == libraryID && e.SongVersionID == songVersion.ID).FirstOrDefaultAsync();
                if (playList != null)
                {
                    return Problem("The song has added to the playlist.");
                }
                _context.PlayLists.Add(new PlayList(libraryID, songVersion.ID));
                await _context.SaveChangesAsync();
                if(Convert.ToInt16(TempData["AlbumID"])==0)
                     return RedirectToAction(actionName: "Index", controllerName: "Songs");
                else
                    return RedirectToAction(actionName: "GetByAlbumID", controllerName: "Songs", new { albumID= Convert.ToInt16(TempData["AlbumID"]) });
            }

            return View();
        }
    }
}
