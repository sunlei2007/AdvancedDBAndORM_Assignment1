using System.ComponentModel.DataAnnotations;

namespace AdvancedDBAndORM_Assignment1.Models
{
    public class Episode
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Must be there character at least!")]
        [Display(Name = "Episode Name")]
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int Dration { get; set; }

        public Episode(string name,DateTime createDate,int duration)
        {
            Name = name;
            CreateDate = createDate;
            Dration=duration;
        }
        public Episode() { }
    }
}
