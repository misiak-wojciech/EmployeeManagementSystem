using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetAllAsync();
        Task<Salary> GetByIdAsync(int id);
        Task AddAsync(Salary salary);
        Task UpdateAsync(Salary salary);
        Task DeleteAsync(int id);
    }
}
