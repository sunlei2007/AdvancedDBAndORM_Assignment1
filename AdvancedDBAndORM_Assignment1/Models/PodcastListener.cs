 
using System.ComponentModel.DataAnnotations;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class PodcastListener
    {
        [Key]
        public int ID { get; set; }
   
        public Podcast Podcast { get; set; }
        public int PodcastID { get; set; }

        public Listener Listener { get; set; }
        public int ListenerID { get; set; }
        public PodcastListener(int podcastID,int listenerID)
        {
            PodcastID= podcastID;
            ListenerID = listenerID;
        }
        public PodcastListener() { }
    }
}
