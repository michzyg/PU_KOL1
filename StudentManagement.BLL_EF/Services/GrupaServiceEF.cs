using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL_EF.Services
{
    public class GrupaServiceEF : IGrupaService
    {
        private readonly IGrupaRepository _grupaRepository;

        public GrupaServiceEF(IGrupaRepository grupaRepository)
        {
            _grupaRepository = grupaRepository;
        }

        public async Task<IEnumerable<GrupaDTO>> GetAllAsync()
        {
            var grupy = await _grupaRepository.GetAllAsync();
            return grupy.Select(g => new GrupaDTO
            {
                ID = g.ID,
                Nazwa = g.Nazwa,
                LiczbaStudentow = g.Studenci?.Count ?? 0
            });
        }

        public async Task<GrupaDTO> GetByIdAsync(int id)
        {
            var grupa = await _grupaRepository.GetByIdAsync(id);
            if (grupa == null)
                return null;

            return new GrupaDTO
            {
                ID = grupa.ID,
                Nazwa = grupa.Nazwa,
                LiczbaStudentow = grupa.Studenci?.Count ?? 0
            };
        }

        public async Task<GrupaDTO> AddAsync(GrupaDTO grupaDto)
        {
            var grupa = new Grupa
            {
                Nazwa = grupaDto.Nazwa
            };

            var result = await _grupaRepository.AddAsync(grupa);

            return new GrupaDTO
            {
                ID = result.ID,
                Nazwa = result.Nazwa,
                LiczbaStudentow = 0
            };
        }

        public async Task UpdateAsync(GrupaDTO grupaDto)
        {
            var existingGrupa = await _grupaRepository.GetByIdAsync(grupaDto.ID);
            if (existingGrupa == null)
                throw new KeyNotFoundException($"Grupa o ID {grupaDto.ID} nie została znaleziona");

            existingGrupa.Nazwa = grupaDto.Nazwa;

            await _grupaRepository.UpdateAsync(existingGrupa);
        }

        public async Task DeleteAsync(int id)
        {
            var existingGrupa = await _grupaRepository.GetByIdAsync(id);
            if (existingGrupa == null)
                throw new KeyNotFoundException($"Grupa o ID {id} nie została znaleziona");

            await _grupaRepository.DeleteAsync(id);
        }
    }
}