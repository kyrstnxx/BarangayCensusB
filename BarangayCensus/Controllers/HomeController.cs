using BarangayCensus.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarangayCensus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.TotalResidents = await _db.Residents.CountAsync();
                ViewBag.TotalVoters = await _db.Residents.CountAsync(r => r.IsVoter);
                ViewBag.TotalSeniors = await _db.Residents.CountAsync(r => r.IsSeniorCitizen);
                ViewBag.TotalPWD = await _db.Residents.CountAsync(r => r.IsPWD);
                ViewBag.RecentResidents = await _db.Residents
                    .OrderByDescending(r => r.DateRegistered)
                    .Take(5)
                    .ToListAsync();
            }
            return View();
        }
    }
}