using System.ComponentModel.DataAnnotations;

namespace szakmai_eb.Models
{
    public class Szakma
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string SzakmaNev { get; set; }

        public ICollection<Versenyzo>? Versenyzok { get; set; }
    }
}