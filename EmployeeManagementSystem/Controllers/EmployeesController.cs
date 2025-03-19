using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IPositionRepository positionRepository,
            IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _departmentRepository = departmentRepository;
        }

        // Helper method to load common data for dropdowns
        private async Task LoadCommonData()
        {
            var positions = await _positionRepository.GetAllAsync();
            var departments = await _departmentRepository.GetAllAsync();

            ViewBag.Positions = new SelectList(positions, "Id", "Title");
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
        }

        // GET: Employees/Create
        public async Task<IActionResult> Create()
        {
            await LoadCommonData();
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.AddAsync(employee);
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetEmployeesWithDetailsAsync();
            return View(employees);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await LoadCommonData();  
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employeeRepository.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));
            }

           
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            await LoadCommonData();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeRepository.DeleteAsync(id);  
            return RedirectToAction(nameof(Index)); 
        }
    }
}
