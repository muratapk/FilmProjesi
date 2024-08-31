using System.ComponentModel.DataAnnotations;

namespace FilmApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        
    }
}
