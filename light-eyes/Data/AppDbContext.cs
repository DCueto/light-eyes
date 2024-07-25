using light_eyes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace light_eyes.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions options) : base(options){}

    public DbSet<CheckList> CheckList { get; set; }
    public DbSet<CheckListItem> CheckListItem { get; set; }
    public DbSet<CheckListItemOption> CheckListItemOption { get; set; }
    
    public DbSet<Report> Report { get; set; }
    public DbSet<ReportControlData> ReportControlData { get; set; }
    public DbSet<ReportCheckListItem> ReportCheckListItems { get; set; }
    public DbSet<ReportCheckListItemOption> ReportCheckListItemOptions { get; set; }
    public DbSet<Client> Clients { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
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

        // CheckList
        builder.Entity<CheckList>()
            .HasMany<CheckListItem>(c => c.CheckListItems)
            .WithOne(c => c.CheckList)
            .HasForeignKey(c => c.CheckListId);

        builder.Entity<CheckListItem>()
            .HasMany<CheckListItemOption>(i => i.CheckListItemOptions)
            .WithOne(o => o.CheckListItem)
            .HasForeignKey(o => o.CheckListItemId);
        
        // Report
        builder.Entity<Report>()
            .HasMany<ReportCheckListItem>(r => r.ReportCheckListItems)
            .WithOne(r => r.Report)
            .HasForeignKey(r => r.ReportId);

        builder.Entity<Report>()
            .HasOne<Client>(r => r.Client)
            .WithMany(c => c.Reports)
            .HasForeignKey(r => r.ClientId);

        builder.Entity<Report>()
            .HasOne<CheckList>(r => r.CheckList)
            .WithMany(c => c.Reports)
            .HasForeignKey(r => r.CheckListId);

        builder.Entity<Report>()
            .HasOne<ReportControlData>(r => r.ReportControlData)
            .WithOne(r => r.Report)
            .HasForeignKey<Report>(r => r.ReportControlDataId);
        
        // ReportCheckListItem
        builder.Entity<ReportCheckListItem>()
            .HasMany<ReportCheckListItemOption>(r => r.ReportCheckListItemOptions)
            .WithOne(r => r.ReportCheckListItem)
            .HasForeignKey(r => r.ReportCheckListItemId);

        builder.Entity<ReportCheckListItem>()
            .HasOne<CheckListItem>(r => r.CheckListItem)
            .WithMany(c => c.ReportCheckListItems)
            .HasForeignKey(r => r.CheckListItemId);
        
        // ReportCheckListItemOption
        builder.Entity<ReportCheckListItemOption>()
            .HasOne<CheckListItemOption>(r => r.CheckListItemOption)
            .WithMany(c => c.ReportCheckListItemOptions)
            .HasForeignKey(r => r.CheckListItemOptionId);

    }
}