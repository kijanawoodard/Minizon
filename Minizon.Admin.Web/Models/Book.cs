using System.ComponentModel.DataAnnotations;

namespace Minizon.Admin.Web.Models
{
    public class Book
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
    }
}