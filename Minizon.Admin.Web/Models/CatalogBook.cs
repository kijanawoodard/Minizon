using System.ComponentModel.DataAnnotations;

namespace Minizon.Admin.Web.Models
{
    public class CatalogBook
    {
        //todo: investigate how to do it via conventions (Raven 2.0+)
        public string Id { get { return "Books/" + ISBN; } }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }   
        [Required]
        public double SuggestedPrice { get; set; }
    }
}