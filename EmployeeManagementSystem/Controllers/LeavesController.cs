using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Controllers
{
    public class LeavesController : Controller
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public LeavesController(ILeaveRepository leaveRepository, IEmployeeRepository employeeRepository)
        {
            _leaveRepository = leaveRepository;
            _employeeRepository = employeeRepository;
        }

        
        private async Task SetViewData()
        {
            
            var employees = await _employeeRepository.GetAllAsync();
            ViewData["Employees"] = new SelectList(employees, "Id", "FullName");

            
            ViewData["LeaveTypes"] = Enum.GetValues(typeof(LeaveType))
                .Cast<LeaveType>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();

            ViewData["LeaveStatuses"] = Enum.GetValues(typeof(LeaveStatus))
                .Cast<LeaveStatus>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                })
                .ToList();
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            var leaves = await _leaveRepository.GetAllAsync();
            return View(leaves);
        }

        // GET: Leaves/Create
        public async Task<IActionResult> Create()
        {
            await SetViewData(); 
            return View();
        }

        // POST: Leaves/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Leave leave)
        {
            if (ModelState.IsValid)
            {
                await _leaveRepository.AddAsync(leave);
                return RedirectToAction(nameof(Index));
            }

           
            return View(leave);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var leave = await _leaveRepository.GetByIdAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            
            await SetViewData();
            return View(leave);
        }

        // POST: Leaves/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Leave leave)
        {
            if (id != leave.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _leaveRepository.UpdateAsync(leave);
                return RedirectToAction(nameof(Index));
            }

            return View(leave);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var leave = await _leaveRepository.GetByIdAsync(id);
            if (leave == null)
            {
                return NotFound();
            }

            return View(leave);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           

                await _leaveRepository.DeleteAsync(id);
                 return RedirectToAction(nameof(Index));
        }
    }
}
