using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Repositories.Concrete
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _context;

        public LeaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Leave>> GetAllAsync()
        {
            return await _context.Leaves
                .Include(l => l.Employee) 
                .ToListAsync();
        }

     
        public async Task<Leave> GetByIdAsync(int id)
        {
           return await _context.Leaves
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(l => l.Id == id);

            
        }


        public async Task AddAsync(Leave leave)
        {
            await _context.Leaves.AddAsync(leave);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Leave leave)
        {
            _context.Leaves.Update(leave);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
                await _context.SaveChangesAsync();
            }
        }
    }

}
