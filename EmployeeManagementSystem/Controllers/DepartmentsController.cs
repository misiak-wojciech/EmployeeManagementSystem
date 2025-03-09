using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

  
        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentRepository.AddAsync(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _departmentRepository.UpdateAsync(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Departments/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department != null)
            {
                await _departmentRepository.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
