using Microsoft.EntityFrameworkCore;

namespace ForgingAhead.Models
{
    public class ApplicationDbContext : DbContext
    {
        // Singleton
        public static readonly ApplicationDbContext _instance = new ApplicationDbContext();
        public static ApplicationDbContext Instance { get { return _instance; } }
        private ApplicationDbContext() { }

        // Data
        public DbSet<Character> Characters { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
    }
}
