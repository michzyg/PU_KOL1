using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> GetByIdAsync(int id);
        Task<StudentDTO> AddAsync(StudentDTO studentDto, bool useStoredProcedure = false);
        Task UpdateAsync(StudentDTO studentDto);
        Task DeleteAsync(int id);
    }
}