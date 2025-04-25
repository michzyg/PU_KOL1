using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHistoriaService
    {
        Task<PagedHistoriaResultDTO> GetPagedAsync(int pageNumber, int pageSize);
        Task<HistoriaDTO> AddAsync(HistoriaDTO historiaDto);
    }
}