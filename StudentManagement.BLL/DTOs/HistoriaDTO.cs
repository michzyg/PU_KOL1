using System;
using DAL.Entities;

namespace BLL.DTOs
{
    public class HistoriaDTO
    {
        public int ID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? IDGrupy { get; set; }
        public string TypAkcji { get; set; }
        public DateTime Data { get; set; }
    }

    public class PagedHistoriaResultDTO
    {
        public IEnumerable<HistoriaDTO> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}