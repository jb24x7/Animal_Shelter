using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Pet> Pets { get; set; }

    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}