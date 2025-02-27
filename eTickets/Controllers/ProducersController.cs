using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,PRofilePictureUrl,Bio")] Producer producer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(producer);
            //}
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);

            if (ProducerDetails == null) return View("Not Found!");
            return View(ProducerDetails);
        }


        //Get Producers/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);

            if (ProducerDetails == null) return View("Not Found!");
            return View(ProducerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ProducerID, FullName,PRofilePictureUrl,Bio")] Producer producer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(producer);
            //}

            await _service.UpdateAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get Producers/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);

            if (ProducerDetails == null) return View("Not Found!");
            return View(ProducerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProducerDetails = await _service.GetByIdAsync(id);

            if (ProducerDetails == null) return View("Not Found!");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
