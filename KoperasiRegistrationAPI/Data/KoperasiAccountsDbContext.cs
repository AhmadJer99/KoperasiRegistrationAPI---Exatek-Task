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
        modelBuilder.Entity<Account>()
        .HasOne(a => a.PinInfo)
        .WithOne(p => p.Account)
        .HasForeignKey<PinInfo>(p => p.AccountId);

        base.OnModelCreating(modelBuilder);
    }
}
