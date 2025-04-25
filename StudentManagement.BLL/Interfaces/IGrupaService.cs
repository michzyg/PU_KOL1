using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGrupaService
    {
        Task<IEnumerable<GrupaDTO>> GetAllAsync();
        Task<GrupaDTO> GetByIdAsync(int id);
        Task<GrupaDTO> AddAsync(GrupaDTO grupaDto);
        Task UpdateAsync(GrupaDTO grupaDto);
        Task DeleteAsync(int id);
    }
}