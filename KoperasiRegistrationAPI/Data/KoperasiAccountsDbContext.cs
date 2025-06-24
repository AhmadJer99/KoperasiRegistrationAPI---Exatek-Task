using KoperasiRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KoperasiRegistrationAPI.Data;

public class KoperasiAccountsDbContext : DbContext
{
    public KoperasiAccountsDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<PinInfo> PinInfos { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // one-to-one relationship between Account and PinInfo
        modelBuilder.Entity<PinInfo>()
            .HasOne<Account>()                         // One Account
            .WithOne()                                 // Has One PinInfo
            .HasForeignKey<PinInfo>(p => p.AccountId); // FK is AccountId

        base.OnModelCreating(modelBuilder);
    }
}
