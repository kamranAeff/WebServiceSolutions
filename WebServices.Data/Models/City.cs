using System.ComponentModel.DataAnnotations;

namespace WebServices.Data.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
