using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public enum TypAkcji
    {
        Usuwanie,
        Edycja
    }

    public class Historia
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Imie { get; set; }

        [Required]
        [StringLength(100)]
        public string Nazwisko { get; set; }

        public int? IDGrupy { get; set; }

        [Required]
        public TypAkcji TypAkcji { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}