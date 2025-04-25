using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL_EF.Services
{
    public class HistoriaServiceEF : IHistoriaService
    {
        private readonly IHistoriaRepository _historiaRepository;

        public HistoriaServiceEF(IHistoriaRepository historiaRepository)
        {
            _historiaRepository = historiaRepository;
        }

        public async Task<PagedHistoriaResultDTO> GetPagedAsync(int pageNumber, int pageSize)
        {
            var (items, totalCount) = await _historiaRepository.GetPagedAsync(pageNumber, pageSize);

            return new PagedHistoriaResultDTO
            {
                Items = items.Select(h => new HistoriaDTO
                {
                    ID = h.ID,
                    Imie = h.Imie,
                    Nazwisko = h.Nazwisko,
                    IDGrupy = h.IDGrupy,
                    TypAkcji = h.TypAkcji.ToString(),
                    Data = h.Data
                }),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        // Dodana brakująca metoda
        public async Task<HistoriaDTO> AddAsync(HistoriaDTO historiaDto)
        {
            TypAkcji typAkcji;
            if (!Enum.TryParse<TypAkcji>(historiaDto.TypAkcji, out typAkcji))
            {
                throw new ArgumentException("Nieprawidłowy typ akcji. Dozwolone wartości: Usuwanie, Edycja");
            }

            var historia = new Historia
            {
                Imie = historiaDto.Imie,
                Nazwisko = historiaDto.Nazwisko,
                IDGrupy = historiaDto.IDGrupy,
                TypAkcji = typAkcji,
                Data = historiaDto.Data
            };

            await _historiaRepository.AddAsync(historia);

            // Ustawiamy ID po dodaniu
            historiaDto.ID = historia.ID;
            return historiaDto;
        }
    }
}