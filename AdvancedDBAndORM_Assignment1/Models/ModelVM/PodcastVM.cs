using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace AdvancedDBAndORM_Assignment1.Models.ModelVM
{
    public class PodcastVM
    {
        
        public int ID { get; set; }
        public int PodcastID { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }

        public PodcastVM(int podcastID, string name, string artistName)
        {

            PodcastID = podcastID;
            Name = name;
            ArtistName = artistName;
        }
        public PodcastVM() { }
    }
}
