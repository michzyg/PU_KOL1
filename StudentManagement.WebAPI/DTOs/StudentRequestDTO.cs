using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class StudentRequestDTO
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(50, ErrorMessage = "Imię nie może przekraczać 50 znaków")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(100, ErrorMessage = "Nazwisko nie może przekraczać 100 znaków")]
        public string Nazwisko { get; set; }

        public int? IDGrupy { get; set; }

        public bool UseStoredProcedure { get; set; }
    }

    public class StudentUpdateRequestDTO : StudentRequestDTO
    {
        [Required(ErrorMessage = "ID jest wymagane")]
        public int ID { get; set; }
    }
}