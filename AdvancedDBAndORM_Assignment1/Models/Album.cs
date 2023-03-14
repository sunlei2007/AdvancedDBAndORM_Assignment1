namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Album(string name)
        {
            Name = name;
        }
        public Album() { }
    }
}
