using Microsoft.AspNetCore.Mvc;
using MHNS.Models;
using MHNS.Services;
using MHNS.Data; 
using Microsoft.Extensions.Logging;

namespace MHNS.Controllers
{
    public class SignUpController : Controller
    {
        private readonly PasswordHasherService _passwordHasherService;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SignUpController> _logger;

        public SignUpController(PasswordHasherService passwordHasherService, ApplicationDbContext context, ILogger<SignUpController> logger)
        {
            _passwordHasherService = passwordHasherService;
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    student.Password = _passwordHasherService.HashPassword(student, student.Password);
                    student.ConfirmPassword = student.Password; // Ensure ConfirmPassword is not saved

                    _context.Students.Add(student);
                    _context.SaveChanges();
                    _logger.LogInformation("Student {Email} registered successfully.", student.Email);
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while saving the student.");

                    // Capture detailed error information
                    var errorDetails = new List<string> { ex.Message };
                    if (ex.InnerException != null)
                    {
                        errorDetails.Add(ex.InnerException.Message);
                        if (ex.InnerException.InnerException != null)
                        {
                            errorDetails.Add(ex.InnerException.InnerException.Message);
                        }
                    }

                    return Json(new { success = false, message = "An error occurred while saving the entity changes.", errors = errorDetails });
                }
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, errors });
        }



    }
}
