namespace PlatformBase.Domain;

public static class ApplicationMessage
{
    private const string CommonUserErrorMessage = "İşleminiz şu anda gerçekleştirilemiyor. Lütfen daha sonra tekrar deneyiniz.";

    private static readonly Dictionary<string, string> ErrorMessages = new Dictionary<string, string>()
    {

    };

    private static readonly Dictionary<string, string> UserMessages = new Dictionary<string, string>()
    {

    };

    public static string Message(this string code)
    {
        ErrorMessages.TryGetValue(code, out var errorMessage);
        return errorMessage;
    }

    public static string UserMessage(this string code)
    {
        UserMessages.TryGetValue(code, out var errorMessage);
        return errorMessage;
    }
}