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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // GET: api/Student
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentResponseDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<StudentResponseDTO>>> GetStudents()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<StudentResponseDTO>>(students));
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentResponseDTO>> GetStudent(int id)
        {
            var student = await _studentService.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentResponseDTO>(student));
        }

        // POST: api/Student
        [HttpPost]
        [ProducesResponseType(typeof(StudentResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StudentResponseDTO>> CreateStudent(StudentRequestDTO studentDto)
        {
            try
            {
                var mappedStudent = _mapper.Map<StudentDTO>(studentDto);
                var createdStudent = await _studentService.AddAsync(mappedStudent, studentDto.UseStoredProcedure);

                return CreatedAtAction(
                    nameof(GetStudent),
                    new { id = createdStudent.ID },
                    _mapper.Map<StudentResponseDTO>(createdStudent));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateRequestDTO studentDto)
        {
            if (id != studentDto.ID)
            {
                return BadRequest("ID w URL nie zgadza się z ID w ciele żądania");
            }

            try
            {
                var mappedStudent = _mapper.Map<StudentDTO>(studentDto);
                await _studentService.UpdateAsync(mappedStudent);

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

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentService.DeleteAsync(id);
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