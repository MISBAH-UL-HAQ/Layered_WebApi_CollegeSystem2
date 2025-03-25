using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDTO> GetByIdAsync(int id);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<StudentDTO> AddAsync(StudentDTO dto);
        Task<StudentDTO> UpdateAsync(StudentDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
