using CRUDA13net6.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDA13net6.DBO
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
