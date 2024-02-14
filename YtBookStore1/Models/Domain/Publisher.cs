using System.ComponentModel.DataAnnotations;

namespace YtBookStore1.Models.Domain
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public String PublisherName { get; set; }
    }
}
