using System.ComponentModel.DataAnnotations;

namespace szakmai_eb.Models
{
    public class Orszag
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string OrszagNev { get; set; }

        public ICollection<Versenyzo>? Versenyzok { get; set; }
    }
}