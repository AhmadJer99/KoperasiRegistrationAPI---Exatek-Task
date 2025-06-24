using KoperasiRegistrationAPI.Models;

namespace KoperasiRegistrationAPI.Interfaces;

public interface IAccountRepository
{
    Task RegisterAccountAsync(Account account);
}
