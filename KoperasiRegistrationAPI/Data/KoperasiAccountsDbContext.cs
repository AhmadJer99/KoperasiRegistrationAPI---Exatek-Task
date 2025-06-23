using KoperasiRegistrationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KoperasiRegistrationAPI.Data;

public class KoperasiAccountsDbContext : DbContext
{
    public KoperasiAccountsDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Account> Accounts { get; set; }
}
