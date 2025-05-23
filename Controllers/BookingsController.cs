using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using vmp_cinema.Data;

namespace vmp_lab1.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ISeanceService _seanceService;

        public BookingsController(IBookingService bookingService, ISeanceService seanceService)
        {
            _bookingService = bookingService;
            _seanceService = seanceService;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetAllAsync();
            return View(bookings);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _bookingService.GetByIdAsync(id.Value);
            if (booking == null) return NotFound();

            return View(booking);
        }

        // GET: Bookings/Create
        public async Task<IActionResult> Create()
        {
            var seances = await _seanceService.GetAllAsync();
            ViewData["SeanceId"] = new SelectList(seances, "Id", "Id");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerName,SeanceId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.AddAsync(booking);
                return RedirectToAction(nameof(Index));
            }

            var seances = await _seanceService.GetAllAsync();
            ViewData["SeanceId"] = new SelectList(seances, "Id", "Id", booking.SeanceId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _bookingService.GetByIdAsync(id.Value);
            if (booking == null) return NotFound();

            var seances = await _seanceService.GetAllAsync();
            ViewData["SeanceId"] = new SelectList(seances, "Id", "Id", booking.SeanceId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerName,SeanceId")] Booking booking)
        {
            if (id != booking.Id) return NotFound();

            if (ModelState.IsValid)
            {
                await _bookingService.UpdateAsync(booking);
                return RedirectToAction(nameof(Index));
            }

            var seances = await _seanceService.GetAllAsync();
            ViewData["SeanceId"] = new SelectList(seances, "Id", "Id", booking.SeanceId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _bookingService.GetByIdAsync(id.Value);
            if (booking == null) return NotFound();

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookingService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
