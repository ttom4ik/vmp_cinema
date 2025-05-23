using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using vmp_cinema.Data;

namespace vmp_lab1.Controllers
{
    public class SeancesController : Controller
    {
        private readonly ISeanceService _seanceService;
        private readonly IFilmService _filmService;

        public SeancesController(ISeanceService seanceService, IFilmService filmService)
        {
            _seanceService = seanceService;
            _filmService = filmService;
        }

        // GET: Seances
        public async Task<IActionResult> Index()
        {
            var seances = await _seanceService.GetAllAsync();
            return View(seances);
        }

        // GET: Seances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var seance = await _seanceService.GetByIdAsync(id.Value);
            if (seance == null)
                return NotFound();

            return View(seance);
        }

        // GET: Seances/Create
        public async Task<IActionResult> Create()
        {
            var films = await _filmService.GetAllAsync();
            ViewData["FilmId"] = new SelectList(films, "Id", "Id");
            return View();
        }

        // POST: Seances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,FilmId")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                await _seanceService.AddAsync(seance);
                return RedirectToAction(nameof(Index));
            }

            var films = await _filmService.GetAllAsync();
            ViewData["FilmId"] = new SelectList(films, "Id", "Id", seance.FilmId);
            return View(seance);
        }

        // GET: Seances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var seance = await _seanceService.GetByIdAsync(id.Value);
            if (seance == null)
                return NotFound();

            var films = await _filmService.GetAllAsync();
            ViewData["FilmId"] = new SelectList(films, "Id", "Id", seance.FilmId);
            return View(seance);
        }

        // POST: Seances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,FilmId")] Seance seance)
        {
            if (id != seance.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _seanceService.UpdateAsync(seance);
                return RedirectToAction(nameof(Index));
            }

            var films = await _filmService.GetAllAsync();
            ViewData["FilmId"] = new SelectList(films, "Id", "Id", seance.FilmId);
            return View(seance);
        }

        // GET: Seances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var seance = await _seanceService.GetByIdAsync(id.Value);
            if (seance == null)
                return NotFound();

            return View(seance);
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _seanceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
