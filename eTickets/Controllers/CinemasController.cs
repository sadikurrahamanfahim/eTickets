using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;
        public CinemasController(ICinemaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema Cinema)
        {
            //if (!ModelState.IsValid) // For Some reaqson Model state is invalid
            //{
            //    return View(Cinema);
            //}
            await _service.AddAsync(Cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get Cinemas/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);

            if (CinemaDetails == null) return View("Not Found!");
            return View(CinemaDetails);
        }


        //Get Cinemas/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);

            if (CinemaDetails == null) return View("Not Found!");
            return View(CinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Name,Logo,Description")] Cinema Cinema)
        {
            //if (!ModelState.IsValid) // For Some reaqson Model state is invalid
            //{
            //    return View(Cinema);
            //}

            await _service.UpdateAsync(Cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get Cinemas/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);

            if (CinemaDetails == null) return View("Not Found!");
            return View(CinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);

            if (CinemaDetails == null) return View("Not Found!");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
