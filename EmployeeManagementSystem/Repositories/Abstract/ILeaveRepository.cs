using EmployeeManagementSystem.Models;

public interface ILeaveRepository
{
    Task<IEnumerable<Leave>> GetAllAsync();      
    Task<Leave> GetByIdAsync(int id);            
    Task AddAsync(Leave leave);                  
    Task UpdateAsync(Leave leave);                
    Task DeleteAsync(int id);                     
}
