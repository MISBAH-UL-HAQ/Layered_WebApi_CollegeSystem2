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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<StudentDTO> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return null;

            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                DepartmentId = student.DepartmentId
            };
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                DepartmentId = s.DepartmentId
            });
        }

        public async Task<StudentDTO> AddAsync(StudentDTO dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId
            };
            await _repository.AddAsync(student);
            await _repository.SaveChangesAsync();
            dto.Id = student.Id;
            return dto;
        }

        public async Task<StudentDTO> UpdateAsync(StudentDTO dto)
        {
            var student = await _repository.GetByIdAsync(dto.Id);
            if (student == null) return null;

            student.Name = dto.Name;
            student.DepartmentId = dto.DepartmentId;
            await _repository.UpdateAsync(student);
            await _repository.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            await _repository.DeleteAsync(student);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
