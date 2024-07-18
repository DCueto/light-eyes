using light_eyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options){}

    public DbSet<Report> Report { get; set; }
    public DbSet<Section> Section { get; set; }
    public DbSet<Report_Section> ReportSections {get; set; }
    
    public DbSet<CheckList> CheckList { get; set; }
    
    public DbSet<CheckListItem> CheckListItem { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Report_Section>(x => x.HasKey(p => new { p.SectionId, p.ReportId }));
        
        builder.Entity<Report>()
            .HasMany(rs => rs.ReportSections)
            .WithOne(rp => rp.Report)
            .HasForeignKey(rp => rp.ReportId);

        builder.Entity<Section>()
            .HasMany(sc => sc.ReportSections)
            .WithOne(rs => rs.Section)
            .HasForeignKey(rp => rp.SectionId);

        
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        
    }
}