namespace KoperasiRegistrationAPI.Interfaces;

public interface INotificationService
{
    void SendSms(string phoneNumber, string message);
    void SendEmail(string email, string message);
}