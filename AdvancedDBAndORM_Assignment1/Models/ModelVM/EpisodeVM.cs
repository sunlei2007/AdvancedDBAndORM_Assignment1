using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace AdvancedDBAndORM_Assignment1.Models.ModelVM
{
    public class EpisodeVM
    {
        
        public int ID { get; set; }
        public int EpisodeID { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }

        public string Duration { get; set; }

        public EpisodeVM(int episodeID, string name, string createDate, string duration)
        {
            EpisodeID = episodeID;
            Name = name;
            CreateDate = createDate;
            Duration = duration;
        }
        public EpisodeVM() { }
    }
}
