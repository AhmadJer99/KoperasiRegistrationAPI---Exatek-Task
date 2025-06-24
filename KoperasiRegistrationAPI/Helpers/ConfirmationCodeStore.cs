using KoperasiRegistrationAPI.Models;

namespace KoperasiRegistrationAPI.Helpers;

public static class ConfirmationCodeStore
{
    private static Dictionary<string, ConfirmationCode> _codes = [];

    public static void StoreCode(string key, ConfirmationCode code) => _codes[key] = code;

    public static ConfirmationCode? GetCode(string key) => _codes.TryGetValue(key, out var code) ? code : null;

    public static void RemoveCode(string key) => _codes.Remove(key);
}

