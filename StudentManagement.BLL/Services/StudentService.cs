using BLL.DTOs;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        public Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task<StudentDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task<StudentDTO> AddAsync(StudentDTO studentDto, bool useStoredProcedure = false)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task UpdateAsync(StudentDTO studentDto)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException("Ta metoda powinna być zaimplementowana w warstwie BLL_EF");
        }
    }
}