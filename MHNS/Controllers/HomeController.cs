using MHNS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Linq;
using MHNS.Data;
using MHNS.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace MHNS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly PasswordHasherService _passwordHasherService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, PasswordHasherService passwordHasherService)
        {
            _logger = logger;
            _context = context;
            _passwordHasherService = passwordHasherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Students
                    .SingleOrDefaultAsync(s => s.Email == model.LoginIdentifier || s.StudentIdNumber == model.LoginIdentifier);

                if (user != null)
                {
                    var passwordVerificationResult = _passwordHasherService.VerifyHashedPassword(user, user.Password, model.Password);
                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            // Additional properties here
                        };

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        _logger.LogInformation("User {Email} logged in successfully.", user.Email);
                        return Json(new { success = true });
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Json(new { success = false });
        }


        public IActionResult Privacy()
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
