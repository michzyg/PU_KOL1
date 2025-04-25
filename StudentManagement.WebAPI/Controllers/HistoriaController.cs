using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaController : ControllerBase
    {
        private readonly IHistoriaService _historiaService;
        private readonly IMapper _mapper;

        public HistoriaController(IHistoriaService historiaService, IMapper mapper)
        {
            _historiaService = historiaService;
            _mapper = mapper;
        }

        // GET: api/Historia
        [HttpGet]
        [ProducesResponseType(typeof(PagedHistoriaResponseDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedHistoriaResponseDTO>> GetHistoria(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var historia = await _historiaService.GetPagedAsync(pageNumber, pageSize);
                return Ok(_mapper.Map<PagedHistoriaResponseDTO>(historia));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Historia
        [HttpPost]
        [ProducesResponseType(typeof(HistoriaResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HistoriaResponseDTO>> CreateHistoria(HistoriaRequestDTO historiaDto)
        {
            try
            {
                // Konwersja z HistoriaRequestDTO na HistoriaDTO
                var mappedHistoria = new HistoriaDTO
                {
                    Imie = historiaDto.Imie,
                    Nazwisko = historiaDto.Nazwisko,
                    IDGrupy = historiaDto.IDGrupy,
                    TypAkcji = historiaDto.TypAkcji,
                    Data = historiaDto.Data
                };

                var createdHistoria = await _historiaService.AddAsync(mappedHistoria);

                return CreatedAtAction(
                    nameof(GetHistoria),
                    new { pageNumber = 1, pageSize = 10 },
                    _mapper.Map<HistoriaResponseDTO>(createdHistoria));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}