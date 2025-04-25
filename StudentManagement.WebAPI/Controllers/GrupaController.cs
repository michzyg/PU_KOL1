using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupaController : ControllerBase
    {
        private readonly IGrupaService _grupaService;
        private readonly IMapper _mapper;

        public GrupaController(IGrupaService grupaService, IMapper mapper)
        {
            _grupaService = grupaService;
            _mapper = mapper;
        }

        // GET: api/Grupa
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GrupaResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GrupaResponseDTO>>> GetGrupy()
        {
            var grupy = await _grupaService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<GrupaResponseDTO>>(grupy));
        }

        // GET: api/Grupa/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GrupaResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GrupaResponseDTO>> GetGrupa(int id)
        {
            var grupa = await _grupaService.GetByIdAsync(id);

            if (grupa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GrupaResponseDTO>(grupa));
        }

        // POST: api/Grupa
        [HttpPost]
        [ProducesResponseType(typeof(GrupaResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GrupaResponseDTO>> CreateGrupa(GrupaRequestDTO grupaDto)
        {
            try
            {
                var mappedGrupa = _mapper.Map<GrupaDTO>(grupaDto);
                var createdGrupa = await _grupaService.AddAsync(mappedGrupa);

                return CreatedAtAction(
                    nameof(GetGrupa),
                    new { id = createdGrupa.ID },
                    _mapper.Map<GrupaResponseDTO>(createdGrupa));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Grupa/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateGrupa(int id, GrupaUpdateRequestDTO grupaDto)
        {
            if (id != grupaDto.ID)
            {
                return BadRequest("ID w URL nie zgadza się z ID w ciele żądania");
            }

            try
            {
                var mappedGrupa = _mapper.Map<GrupaDTO>(grupaDto);
                await _grupaService.UpdateAsync(mappedGrupa);

                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Grupa/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGrupa(int id)
        {
            try
            {
                await _grupaService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}