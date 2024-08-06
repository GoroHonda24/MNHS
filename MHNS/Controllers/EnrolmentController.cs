using Microsoft.AspNetCore.Mvc;
using MHNS.Models;

namespace MHNS.Controllers
{
    public class EnrolmentController : Controller
    {
        [HttpGet]
        public IActionResult EnrolmentForm(string firstName, string middleName, string lastName)
        {
            var enrolmentForm = new EnrolmentForm
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName
                // Map other fields as necessary
            };

            return View(enrolmentForm); // Corrected variable name
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnrolmentForm(EnrolmentForm model)
        {
            if (ModelState.IsValid)
            {
                // Save the model to the database or process it as needed
                // For demonstration, we're just returning the model to the success view
                return View("Success", model);
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
