using Microsoft.AspNetCore.Mvc;
using Parashka_KakashkaASP.NET.Models;
using System.Diagnostics;

namespace Parashka_KakashkaASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Katalog()
        {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
