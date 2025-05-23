using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWeb.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "TEXT")]
        public string Title { get; set; } = null!;

        [Column(TypeName = "TEXT")]
        public string Genre { get; set; } = null!;

        [Display(Name = "Тривалість (хв)")]
        public int Duration { get; set; }
    }
}
