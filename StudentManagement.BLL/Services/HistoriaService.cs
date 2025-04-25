using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class HistoriaService : IHistoriaService
    {
        public Task<PagedHistoriaResultDTO> GetPagedAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task<HistoriaDTO> AddAsync(HistoriaDTO historiaDto)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }
    }
}