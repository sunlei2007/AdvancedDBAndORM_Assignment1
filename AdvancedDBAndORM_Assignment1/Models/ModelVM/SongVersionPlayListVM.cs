using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace AdvancedDBAndORM_Assignment1.Models.ModelVM
{
    public class SongVersionPlayListVM
    {
       public int ID { get; set; }
        public int SongVersionID { get; set; }

        public int? SongID { get; set; }
        public string SongName { get; set; }
        public int? ArtistID { get; set; }
        public string ArtistName { get; set; }
        public int?  AlbumID { get; set; }
        public string AlbumName { get; set; }

        public string? LibraryID { get; set; }

        public string Duration { get; set; }

        public int DurationSec { get; set; }

        public SongVersionPlayListVM(int songVersionID, int? songID, string songName, int? artistID, string artistName, int? albumID, string albumName, string? libraryID, string duration,int durationSec)
        {
            SongVersionID = songVersionID;
            SongID = songID;
            SongName = songName;
            ArtistID = artistID;
            ArtistName = artistName;
            AlbumID = albumID;
            AlbumName = albumName;
            LibraryID = libraryID;
            Duration = duration;
            DurationSec = durationSec;
;        }

        public SongVersionPlayListVM() { }
    }
}
