using System;

namespace BLL.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? IDGrupy { get; set; }
        public string NazwaGrupy { get; set; }
    }
}