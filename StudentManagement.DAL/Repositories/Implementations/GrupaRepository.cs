using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class GrupaRepository : IGrupaRepository
    {
        private readonly ApplicationDbContext _context;

        public GrupaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grupa>> GetAllAsync()
        {
            return await _context.Grupy.ToListAsync();
        }

        public async Task<Grupa> GetByIdAsync(int id)
        {
            return await _context.Grupy
                .Include(g => g.Studenci)
                .FirstOrDefaultAsync(g => g.ID == id);
        }

        public async Task<Grupa> AddAsync(Grupa grupa)
        {
            _context.Grupy.Add(grupa);
            await _context.SaveChangesAsync();
            return grupa;
        }

        public async Task UpdateAsync(Grupa grupa)
        {
            _context.Entry(grupa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var grupa = await _context.Grupy.FindAsync(id);
            if (grupa != null)
            {
                _context.Grupy.Remove(grupa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Grupy.AnyAsync(g => g.ID == id);
        }
    }
}