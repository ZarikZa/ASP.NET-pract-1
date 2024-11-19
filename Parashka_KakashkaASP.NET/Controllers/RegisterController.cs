using Microsoft.AspNetCore.Mvc;
using Parashka_KakashkaASP.NET.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace Parashka_KakashkaASP.NET.Controllers
{
    public class RegisterController : Controller
    {

        private readonly RpmContext _pmContext;

        public RegisterController(RpmContext pmContext)
        {
            _pmContext = pmContext;
        }

        [HttpGet]
        public IActionResult Autoriz()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Autoriz(string email, string password)
        {
            string hashedPassword = HashPassword(password);

            var user = _pmContext.Clients.FirstOrDefault(u=>u.Loginn == email && u.Pass == hashedPassword);
            if (user != null)
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.ClientName),
                    new Claim(ClaimTypes.Email, user.Loginn),
                    //new Claim(ClaimTypes.Role, user.Role == 1 ? "Customer" : "OtherRole")
                };
                
                var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);
                return RedirectToAction("Katalog", "Product");
            }
            ViewBag.ErrorMessage = "Ты даун";
            return View();
        }


        private string HashPassword(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string clientSurname, string clientName, string? clientMiddleName, string loginn, string pass)
        {
            if(_pmContext.Clients.Any(u => u.Loginn == loginn))
            {
                ViewBag.ErrorMessage = "Пользователь уже есть";
                return View();
            }

            string hasheedPasword = HashPassword(pass);

            var user = new Client
            {
                ClientName = clientName,
                ClientMiddleName = clientMiddleName,   
                ClientSurname = clientSurname,
                Loginn = loginn,
                Pass = hasheedPasword
            };

            _pmContext.Clients.Add(user);
            await _pmContext.SaveChangesAsync();

            return RedirectToAction("Autoriz", "Register");
        }
    }
}
