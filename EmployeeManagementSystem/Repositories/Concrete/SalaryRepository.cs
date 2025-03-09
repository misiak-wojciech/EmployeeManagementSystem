using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repositories.Concrete
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<Salary>> GetAllAsync()
        {
            return await _context.Salaries
                .Include(s => s.Employee) 
                .ToListAsync();  
        }

       
        public async Task<Salary> GetByIdAsync(int id)
        {
           return  await _context.Salaries
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task AddAsync(Salary salary)
        {
            _context.Salaries.Add(salary);
            await _context.SaveChangesAsync();
        }

    
        public async Task UpdateAsync(Salary salary)
        {
            _context.Salaries.Update(salary);
            await _context.SaveChangesAsync();
        }

  
        public async Task DeleteAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
                await _context.SaveChangesAsync();
            }
        }
    }
}
