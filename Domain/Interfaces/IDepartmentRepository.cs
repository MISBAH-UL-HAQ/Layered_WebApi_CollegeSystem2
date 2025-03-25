using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetByIdAsync(int id);
        Task<IEnumerable<Department>> GetAllAsync();
        Task AddAsync(Department entity);
        Task UpdateAsync(Department entity);
        Task DeleteAsync(Department entity);
        Task SaveChangesAsync();
    }

}
