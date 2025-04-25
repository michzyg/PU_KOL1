using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GrupaService : IGrupaService
    {
        public Task<IEnumerable<GrupaDTO>> GetAllAsync()
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task<GrupaDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task<GrupaDTO> AddAsync(GrupaDTO grupaDto)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task UpdateAsync(GrupaDTO grupaDto)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }
    }
}