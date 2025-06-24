namespace KoperasiRegistrationAPI.Models;

public class ConfirmationCode
{
    public string?   ContactType { get; set; } // Email or Phone
    public string? ContactValue { get; set; }
    public string? Code { get; set; }
    public DateTime Expiry { get; set; }
}