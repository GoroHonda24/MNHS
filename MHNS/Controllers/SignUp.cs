using MHNS.Data;
using MHNS.Models;
using Microsoft.AspNetCore.Mvc;

namespace MHNS.Controllers
{
    public class SignUp : Controller
    {
        private readonly ApplicationDbContext _context;

        public SignUp(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}

