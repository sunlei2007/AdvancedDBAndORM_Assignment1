 
using System.ComponentModel.DataAnnotations;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class PodcastEpisode
    {
        [Key]
        public int ID { get; set; }
   
        public Podcast Podcast { get; set; }
        public int PodcastID { get; set; }

        public Episode Episode { get; set; }
        public int EpisodeID { get; set; }
        public PodcastEpisode(int podcastID,int episodeID)
        {
            PodcastID = podcastID;
            EpisodeID = episodeID;
        }
        public PodcastEpisode() { }
    }
}
