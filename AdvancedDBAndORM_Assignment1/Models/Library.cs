using System.ComponentModel.DataAnnotations;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Library
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be there character at least!")]
        [Display(Name = "Library Name")]
        public string Name { get; set; }

        
        public Library(string name)
        {
            Name = name;
           
        }
        public Library() { }
    }
}
