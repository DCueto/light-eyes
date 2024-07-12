using light_eyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options){}

    public DbSet<Report> Report { get; set; }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     base.OnModelCreating(builder);
    //     List<IdentityRole> roles = new List<IdentityRole>
    //     {
    //         new IdentityRole
    //         {
    //             Name = "Admin",
    //             NormalizedName = "ADMIN"
    //         },
    //         new IdentityRole
    //         {
    //             Name = "User",
    //             NormalizedName = "USER"
    //         }
    //     };
    //     builder.Entity<IdentityRole>().HasData(Roles);
    // }
}