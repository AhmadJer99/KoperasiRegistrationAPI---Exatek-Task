namespace KoperasiRegistrationAPI.DTOs;

public class VerifyCodeRequest
{
    public string SessionId { get; set; }
    public string ContactValue { get; set; } // Email or Phone
    public string Code { get; set; }
}

