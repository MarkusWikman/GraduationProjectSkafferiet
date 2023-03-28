using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GraduationProjectSkafferiet.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        // Denna konstruktor krävs för att konfigurationen ska fungera
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
        base(options)
        {
        }
        // Exponerar våra databas-modeller via properties av typen DbSet<T> 
        public DbSet<UserInventory> UserInventories { get; set; }

    }
}
