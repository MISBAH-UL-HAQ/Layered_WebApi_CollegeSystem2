using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }


        public async Task<DepartmentDTO> GetByIdAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);
            if (department == null) return null;

            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name
            };
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllAsync()
        {
            var departments = await _repository.GetAllAsync();
            return departments.Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name
            });
        }

        public async Task<DepartmentDTO> AddAsync(DepartmentDTO dto)
        {
            var department = new Department { Name = dto.Name };
            await _repository.AddAsync(department);
            await _repository.SaveChangesAsync();
            dto.Id = department.Id;
            return dto;
        }

        public async Task<DepartmentDTO> UpdateAsync(DepartmentDTO dto)
        {
            var department = await _repository.GetByIdAsync(dto.Id);
            if (department == null) return null;

            department.Name = dto.Name;
            await _repository.UpdateAsync(department);
            await _repository.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _repository.GetByIdAsync(id);
            if (department == null) return false;

            await _repository.DeleteAsync(department);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
