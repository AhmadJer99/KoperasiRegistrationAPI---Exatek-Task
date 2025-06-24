namespace KoperasiRegistrationAPI.Models;

public class PinInfo
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public string? PinCode { get; set; }
    public bool IsConfirmed { get; set; }
}

