namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Artist(string name)
        {
            Name = name;
        }
        public Artist() { }
    }
}
