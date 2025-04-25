using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class HistoriaRequestDTO
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(50, ErrorMessage = "Imię nie może przekraczać 50 znaków")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(100, ErrorMessage = "Nazwisko nie może przekraczać 100 znaków")]
        public string Nazwisko { get; set; }

        public int? IDGrupy { get; set; }

        [Required(ErrorMessage = "Typ akcji jest wymagany")]
        public string TypAkcji { get; set; }

        [Required(ErrorMessage = "Data jest wymagana")]
        public DateTime Data { get; set; }
    }
}