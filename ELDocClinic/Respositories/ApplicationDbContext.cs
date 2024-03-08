using ELDocClinic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELDocClinic.Respositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().Property<bool>("IsDeleted");
            modelBuilder.Entity<ApplicationUser>().Property<DateTime>("CreatedAt");
            modelBuilder.Entity<ApplicationUser>().Property<DateTime>("LastUpdatedAt");
            modelBuilder.Entity<ApplicationUser>().HasDiscriminator<ushort>("Discriminator");
            base.OnModelCreating(modelBuilder);
        }
    }
}
