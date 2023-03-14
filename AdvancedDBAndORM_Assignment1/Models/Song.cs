namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Song
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Song(string name) 
        { 
            Name = name;
        }
        public Song() { }
    }
}
