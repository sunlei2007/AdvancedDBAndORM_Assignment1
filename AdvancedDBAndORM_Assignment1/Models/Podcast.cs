 
using System.ComponentModel.DataAnnotations;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Podcast
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be there character at least!")]
        [Display(Name = "Pod Name")]
        public string Name { get; set; }

        public Artist Artist { get; set; }
        public int ArtistID { get; set; }
        public Podcast(string name,int artistID)
        {
            ArtistID = artistID;
            Name = name;
        }
        public Podcast() { }
    }
}
