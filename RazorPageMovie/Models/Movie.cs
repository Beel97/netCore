using System.ComponentModel.DataAnnotations;

namespace RazorPageMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RelaseDate { get; set; }
        public string? Genere { get; set; }
        public decimal? Price { get; set; }
    }
}
