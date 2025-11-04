using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateOnly PublishedDate { get; set; }
    }
}
