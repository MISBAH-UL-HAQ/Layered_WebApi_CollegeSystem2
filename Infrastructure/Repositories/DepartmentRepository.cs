using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetByIdAsync(int id) => await _context.Departments.FindAsync(id);
        public async Task<IEnumerable<Department>> GetAllAsync() => await _context.Departments.ToListAsync();
        public async Task AddAsync(Department entity) => await _context.Departments.AddAsync(entity);
        public async Task UpdateAsync(Department entity) => _context.Departments.Update(entity);
        public async Task DeleteAsync(Department entity) => _context.Departments.Remove(entity);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}


