using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IGrupaRepository
    {
        Task<IEnumerable<Grupa>> GetAllAsync();
        Task<Grupa> GetByIdAsync(int id);
        Task<Grupa> AddAsync(Grupa grupa);
        Task UpdateAsync(Grupa grupa);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}