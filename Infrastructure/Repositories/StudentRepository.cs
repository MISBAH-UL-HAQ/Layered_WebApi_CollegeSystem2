using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetByIdAsync(int id) => await _context.Students.FindAsync(id);
        public async Task<IEnumerable<Student>> GetAllAsync() => await _context.Students.ToListAsync();
        public async Task AddAsync(Student entity) => await _context.Students.AddAsync(entity);
        public async Task UpdateAsync(Student entity) => _context.Students.Update(entity);
        public async Task DeleteAsync(Student entity) => _context.Students.Remove(entity);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}

