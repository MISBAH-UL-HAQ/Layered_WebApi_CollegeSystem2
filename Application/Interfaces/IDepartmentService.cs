using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> GetByIdAsync(int id);
        Task<IEnumerable<DepartmentDTO>> GetAllAsync();
        Task<DepartmentDTO> AddAsync(DepartmentDTO dto);
        Task<DepartmentDTO> UpdateAsync(DepartmentDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
