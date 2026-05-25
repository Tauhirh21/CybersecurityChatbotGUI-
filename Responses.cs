using System.Collections.Generic;

public static class Responses
{
    public static Dictionary<string, string> GetResponses()
    {
        return new Dictionary<string, string>
        {
            { "password", "Use strong passwords!" },
            { "scam", "Never share personal info!" },
            { "privacy", "Check your privacy settings!" }
        };
    }
}
