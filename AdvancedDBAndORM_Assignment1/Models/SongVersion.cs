using AdvancedDBAndORM_Assignment1.Models.ModelVM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class SongVersion
    {
        public int ID { get; set; }
       
        public int SongID { get; set; }

        //[ForeignKey("SongID")]
        //[Column(nameof(this.Song.ID))]
        public Song Song { get; set; }

        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        public int AlbumID { get; set; }
        public Album Album { get; set; }

        [Range(0,3600*100)]
        public int Duration { get; set; }

        public SongVersion(int songID,int artistID,int albumID,int duration)
        {
            SongID= songID;
            ArtistID= artistID;
            AlbumID= albumID;
            Duration= duration;
        }
        public SongVersion() { }
    }
}
