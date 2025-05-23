using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vmp_cinema.Data;

namespace vmp_lab1.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            var films = await _filmService.GetAllAsync(searchString);
            return View(films);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var film = await _filmService.GetByIdAsync(id.Value);
            if (film == null)
                return NotFound();

            return View(film);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre")] Film film)
        {
            if (ModelState.IsValid)
            {
                await _filmService.AddAsync(film);
                return RedirectToAction(nameof(Index));
            }

            return View(film);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var film = await _filmService.GetByIdAsync(id.Value);
            if (film == null)
                return NotFound();

            return View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre")] Film film)
        {
            if (id != film.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _filmService.UpdateAsync(film);
                return RedirectToAction(nameof(Index));
            }

            return View(film);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var film = await _filmService.GetByIdAsync(id.Value);
            if (film == null)
                return NotFound();

            return View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _filmService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
