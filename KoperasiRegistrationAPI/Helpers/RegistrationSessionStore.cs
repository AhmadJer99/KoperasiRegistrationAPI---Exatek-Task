using KoperasiRegistrationAPI.DTOs;

namespace KoperasiRegistrationAPI.Helpers;

public class RegistrationSession
{
    public RegisterRequest? RegistrationData { get; set; }
    public bool IsEmailVerified { get; set; } = false;
    public bool IsPhoneVerified { get; set; } = false;
    public bool IsPolicyAccepted { get; set; } = false;
}

public static class RegistrationSessionStore
{
    private static Dictionary<string, RegistrationSession> _sessions = new();

    public static string CreateSession(RegisterRequest data)
    {
        var sessionId = Guid.NewGuid().ToString();
        _sessions[sessionId] = new RegistrationSession { RegistrationData = data };
        return sessionId;
    }

    public static RegistrationSession? GetSession(string sessionId)
    {
        _sessions.TryGetValue(sessionId, out var session);
        return session;
    }

    public static void RemoveSession(string sessionId) => _sessions.Remove(sessionId);
}

