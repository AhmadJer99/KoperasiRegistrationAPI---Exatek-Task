namespace KoperasiRegistrationAPI.Helpers;

public static class CodeGenerator
{
    public static string GenerateCode(int length = 6)
    {
        var random = new Random();
        return string.Join("", Enumerable.Range(0, length).Select(_ => random.Next(0, 10)));
    }
}