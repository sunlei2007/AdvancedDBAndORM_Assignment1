namespace AdvancedDBAndORM_Assignment1.Models
{
    public class PlayList
    {
        public int ID { get; set; }

        public int LibraryID { get; set; }

        public Library Library { get; set; }

        public int SongVersionID { get; set; }
        public SongVersion SongVersion { get; set; }

        public PlayList(int libraryID, int songVersionID)
        {
        
            LibraryID = libraryID;          
            SongVersionID = songVersionID;
            
        }
        public PlayList() { }
    }
}
