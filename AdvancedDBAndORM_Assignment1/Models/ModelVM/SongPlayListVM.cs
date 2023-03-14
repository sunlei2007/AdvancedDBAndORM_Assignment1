using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace AdvancedDBAndORM_Assignment1.Models.ModelVM
{
    public class SongPlayListVM
    {
        

        public List<SelectListItem> Libraries { get; set; } = new List<SelectListItem>();
        public string LibraryID { get; set; }

        public SongPlayListVM(List<Library> labraries)
        {
            

            foreach (Library a in labraries)
            {
                Libraries.Add(new SelectListItem(a.Name, a.ID.ToString()));
            }
          
        }
        public SongPlayListVM() { }
    }
}
