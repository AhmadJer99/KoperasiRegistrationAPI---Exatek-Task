namespace KoperasiRegistrationAPI.DTOs;

public class PolicyAcceptanceRequest
{
    public string SessionId { get; set; }
    public bool IsAccepted { get; set; }
}
