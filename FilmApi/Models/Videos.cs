using System.ComponentModel.DataAnnotations;

namespace FilmApi.Models
{
    public class Videos
    {

        [Key]
        public int VideoId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        virtual public Category? Category { get; set; }
        public int? Year { get; set; }
        public string Country { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string Film { get; set; } = string.Empty;
        public string Actors { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Teaser { get; set; } = string.Empty;
    }
}
