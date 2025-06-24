using KoperasiRegistrationAPI.Interfaces;

namespace KoperasiRegistrationAPI.Services;

public class MockNotificationService : INotificationService
{
    public void SendSms(string phoneNumber, string message)
    {
        Console.WriteLine($"[Mock SMS] To: {phoneNumber} | Message: {message}");
    }

    public void SendEmail(string email, string message)
    {
        Console.WriteLine($"[Mock Email] To: {email} | Message: {message}");
    }
}