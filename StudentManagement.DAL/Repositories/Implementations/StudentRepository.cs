using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Studenci
                .Include(s => s.Grupa)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Studenci
                .Include(s => s.Grupa)
                .FirstOrDefaultAsync(s => s.ID == id);
        }

        public async Task<Student> AddAsync(Student student)
        {
            _context.Studenci.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> AddUsingStoredProcedureAsync(Student student)
        {
            // Parametry dla procedury składowanej
            var imieParam = new SqlParameter("@Imie", student.Imie);
            var nazwiskoParam = new SqlParameter("@Nazwisko", student.Nazwisko);
            var idGrupyParam = student.IDGrupy.HasValue
                ? new SqlParameter("@IDGrupy", student.IDGrupy.Value)
                : new SqlParameter("@IDGrupy", DBNull.Value);
            var idParam = new SqlParameter
            {
                ParameterName = "@ID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            // Wykonaj procedurę składowaną
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC DodajStudenta @Imie, @Nazwisko, @IDGrupy, @ID OUTPUT",
                imieParam, nazwiskoParam, idGrupyParam, idParam);

            // Pobierz ID z parametru wyjściowego
            int newId = (int)idParam.Value;

            // Pobierz nowo utworzonego studenta
            return await GetByIdAsync(newId);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Studenci.FindAsync(id);
            if (student != null)
            {
                _context.Studenci.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Studenci.AnyAsync(s => s.ID == id);
        }
    }
}