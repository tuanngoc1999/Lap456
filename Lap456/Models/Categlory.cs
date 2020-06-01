using System.ComponentModel.DataAnnotations;

namespace Lap456.Models
{
    public class Categlory
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}