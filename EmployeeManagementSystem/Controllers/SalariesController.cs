using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Controllers
{
    public class SalariesController : Controller
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public SalariesController(ISalaryRepository salaryRepository, IEmployeeRepository employeeRepository)
        {
            _salaryRepository = salaryRepository;
            _employeeRepository = employeeRepository;
        }

   
        private async Task LoadCommonData()
        {
            var employees = await _employeeRepository.GetAllAsync();
            ViewBag.Employees = new SelectList(employees, "Id", "FullName");
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            var salaries = await _salaryRepository.GetAllAsync();
            return View(salaries);
        }

        // GET: Salaries/Create
        public async Task<IActionResult> Create()
        {
            await LoadCommonData();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salary salary)
        {
            if (ModelState.IsValid)
            {
                await _salaryRepository.AddAsync(salary);
                return RedirectToAction(nameof(Index));
            }

            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }

            await LoadCommonData(); 
            return View(salary);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Salary salary)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _salaryRepository.UpdateAsync(salary);
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _salaryRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
