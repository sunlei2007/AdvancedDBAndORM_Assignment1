 
using System.ComponentModel.DataAnnotations;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Listener
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be there character at least!")]
        [Display(Name = "Listener Name")]
        public string Name { get; set; }
         
        public Listener(string name)
        {
            Name = name;
        }
        public Listener() { }
    }
}
