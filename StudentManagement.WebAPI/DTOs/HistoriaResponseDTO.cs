using System;
using System.Collections.Generic;

namespace WebAPI.DTOs
{
    public class HistoriaResponseDTO
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? IDGrupy { get; set; }
        public string TypAkcji { get; set; }
        public DateTime Data { get; set; }
    }

    public class PagedHistoriaResponseDTO
    {
        public IEnumerable<HistoriaResponseDTO> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}