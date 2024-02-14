using System.ComponentModel.DataAnnotations;

namespace YtBookStore1.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }
    }
}
