using System.ComponentModel.DataAnnotations;

namespace CinemaWeb.Models
{
    public class Movie
    {
        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }

        [Display(Name = "Тривалість (хв)")]
        public int Duration { get; set; }
    }
}
