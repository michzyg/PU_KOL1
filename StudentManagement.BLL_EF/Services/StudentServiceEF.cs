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
    public class StudentServiceEF : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IHistoriaRepository _historiaRepository;

        public StudentServiceEF(IStudentRepository studentRepository, IHistoriaRepository historiaRepository)
        {
            _studentRepository = studentRepository;
            _historiaRepository = historiaRepository;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();
            return students.Select(s => new StudentDTO
            {
                ID = s.ID,
                Imie = s.Imie,
                Nazwisko = s.Nazwisko,
                IDGrupy = s.IDGrupy,
                NazwaGrupy = s.Grupa?.Nazwa
            });
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
                return null;

            return new StudentDTO
            {
                ID = student.ID,
                Imie = student.Imie,
                Nazwisko = student.Nazwisko,
                IDGrupy = student.IDGrupy,
                NazwaGrupy = student.Grupa?.Nazwa
            };
        }

        public async Task<StudentDTO> AddAsync(StudentDTO studentDto, bool useStoredProcedure = false)
        {
            var student = new Student
            {
                Imie = studentDto.Imie,
                Nazwisko = studentDto.Nazwisko,
                IDGrupy = studentDto.IDGrupy
            };

            Student result;
            if (useStoredProcedure)
            {
                result = await _studentRepository.AddUsingStoredProcedureAsync(student);
            }
            else
            {
                result = await _studentRepository.AddAsync(student);
            }

            return new StudentDTO
            {
                ID = result.ID,
                Imie = result.Imie,
                Nazwisko = result.Nazwisko,
                IDGrupy = result.IDGrupy,
                NazwaGrupy = result.Grupa?.Nazwa
            };
        }

        public async Task UpdateAsync(StudentDTO studentDto)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(studentDto.ID);
            if (existingStudent == null)
                throw new KeyNotFoundException($"Student o ID {studentDto.ID} nie został znaleziony");

            // Zapisz historię przed aktualizacją
            await _historiaRepository.AddAsync(new Historia
            {
                Imie = existingStudent.Imie,
                Nazwisko = existingStudent.Nazwisko,
                IDGrupy = existingStudent.IDGrupy,
                TypAkcji = TypAkcji.Edycja,
                Data = DateTime.Now
            });

            // Aktualizuj dane studenta
            existingStudent.Imie = studentDto.Imie;
            existingStudent.Nazwisko = studentDto.Nazwisko;
            existingStudent.IDGrupy = studentDto.IDGrupy;

            await _studentRepository.UpdateAsync(existingStudent);
        }

        public async Task DeleteAsync(int id)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);
            if (existingStudent == null)
                throw new KeyNotFoundException($"Student o ID {id} nie został znaleziony");

            // Zapisz historię przed usunięciem
            await _historiaRepository.AddAsync(new Historia
            {
                Imie = existingStudent.Imie,
                Nazwisko = existingStudent.Nazwisko,
                IDGrupy = existingStudent.IDGrupy,
                TypAkcji = TypAkcji.Usuwanie,
                Data = DateTime.Now
            });

            await _studentRepository.DeleteAsync(id);
        }
    }
}