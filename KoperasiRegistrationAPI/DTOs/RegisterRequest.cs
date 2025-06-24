namespace KoperasiRegistrationAPI.DTOs;

public class RegisterRequest
{
    public string? CustomerName { get; set; }
    public string? ICNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}