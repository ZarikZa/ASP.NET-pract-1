using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parashka_KakashkaASP.NET.Models;

namespace Parashka_KakashkaASP.NET.Controllers
{
    public class ProductController : Controller
    {
        public RpmContext db;

        public ProductController(RpmContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Katalog()
        {
            return View(await db.Unitazs.ToListAsync());
        }

        public IActionResult Korzina()
        {
            return View();
        }
        public IActionResult Izbrannoe()
        {
            return View();
        }
        public IActionResult Podrobnee()
        {
            return View();
        }
    }
}
