using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace szakmai_eb.Models
{
    public class Versenyzo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nev { get; set; }

        [ForeignKey(nameof(Szakma))]
        public string SzakmaId { get; set; }
        public Szakma? Szakma { get; set; }

        [ForeignKey(nameof(Orszag))]
        public string OrszagId { get; set; }
        public Orszag? Orszag { get; set; }

        [Required]
        public int Pont { get; set; }
    }
}