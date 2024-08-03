using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MHNS.Models;

namespace MHNS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}