using KoperasiRegistrationAPI.Data;
using KoperasiRegistrationAPI.Interfaces;
using KoperasiRegistrationAPI.Models;

namespace KoperasiRegistrationAPI.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly KoperasiAccountsDbContext _context;

    public AccountRepository(KoperasiAccountsDbContext context)
    {
        _context = context;
    }

    public async Task RegisterAccountAsync(Account account)
    {
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account cannot be null.");

        }
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }
}