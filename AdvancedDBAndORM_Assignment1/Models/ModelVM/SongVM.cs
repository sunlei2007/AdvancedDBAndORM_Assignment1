using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace AdvancedDBAndORM_Assignment1.Models.ModelVM
{
    public class SongVM
    {
        
        public int ID { get; set; }
        public int SongID { get; set; }
        public string Name { get; set; }
        public string PlayListName { get; set; }

        public SongVM(int songID, string name, string playListName)
        {

            SongID = songID;
            Name = name;
            PlayListName = playListName;
        }
        public SongVM() { }
    }
}
