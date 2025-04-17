using System.ComponentModel.DataAnnotations;

namespace Blog_WebAPI.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; } //Max 100
        [StringLength(5000)]
        public string Content { get; set; } //Max 5000
        public DateTime Date { get; set; }
    }
}
