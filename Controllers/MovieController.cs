using Microsoft.AspNetCore.Mvc;
using CinemaWeb.Models;

namespace CinemaWeb.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Add()
        {
            ViewBag.Message = "Сторінка додавання нового фільму";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Success = $"Фільм \"{movie.Title}\" успішно додано!";
            }
            return View(movie);
        }
    }
}
