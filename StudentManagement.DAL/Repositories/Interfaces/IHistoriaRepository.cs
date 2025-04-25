using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IHistoriaRepository
    {
        Task<(IEnumerable<Historia> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
        Task AddAsync(Historia historia);
    }
}