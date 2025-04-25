using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class HistoriaRepository : IHistoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public HistoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Historia> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _context.Historia.CountAsync();

            var items = await _context.Historia
                .OrderByDescending(h => h.Data)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task AddAsync(Historia historia)
        {
            _context.Historia.Add(historia);
            await _context.SaveChangesAsync();
        }
    }
}