using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Repositories.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    public class PositionsController : Controller
    {
        private readonly IPositionRepository _positionRepository;

        
        public PositionsController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            if (ModelState.IsValid)
            {
               
                await _positionRepository.AddAsync(position);
                return RedirectToAction(nameof(Index)); 
            }

            return View(position); 
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound(); 
            }

            return View(position); 
        }

        // POST: Positions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Position position)
        {
            if (id != position.Id)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                await _positionRepository.UpdateAsync(position);
                return RedirectToAction(nameof(Index)); 
            }

            return View(position); 
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound(); 
            }

            return View(position); 
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            if (position != null)
            {
                await _positionRepository.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

      

        // GET: Positions
        public async Task<IActionResult> Index()
        {
          
            var positions = await _positionRepository.GetAllAsync();
            return View(positions); 
        }
    }
}
