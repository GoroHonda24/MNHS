using MHNS.Models;
using Microsoft.AspNetCore.Identity;

namespace MHNS.Services
{
    public class PasswordHasherService
    {
        private readonly PasswordHasher<Student> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<Student>();
        }

        public string HashPassword(Student student, string password)
        {
            return _passwordHasher.HashPassword(student, password);
        }

        public PasswordVerificationResult VerifyHashedPassword(Student student, string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(student, hashedPassword, providedPassword);
        }
    }
}
