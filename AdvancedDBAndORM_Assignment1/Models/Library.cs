namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Library
    {
        public int ID { get; set; }
        public string Name { get; set; }

        
        public Library(string name)
        {
            Name = name;
           
        }
        public Library() { }
    }
}
