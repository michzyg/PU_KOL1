using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class GrupaRequestDTO
    {
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(100, ErrorMessage = "Nazwa nie może przekraczać 100 znaków")]
        public string Nazwa { get; set; }
    }

    public class GrupaUpdateRequestDTO : GrupaRequestDTO
    {
        [Required(ErrorMessage = "ID jest wymagane")]
        public int ID { get; set; }
    }
}