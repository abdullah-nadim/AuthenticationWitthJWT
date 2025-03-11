using AuthenticationWitthJWT.Entitys;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationWitthJWT.Contexts
{
    public class AuthContext : DbContext
    {
        public AuthContext()
        {
            
        }
        public AuthContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NADIM-PC\\SQLEXPRESS01;Database=AuthDB;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<User> Users { get; set; }  
    }
}
