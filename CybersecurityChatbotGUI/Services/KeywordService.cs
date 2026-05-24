namespace CybersecurityChatbotGUI.Services
{
    public static class KeywordService
    {
        public static string GetResponseKey(string input)
        {
            string lower = input.ToLower();

            if (lower.Contains("password")) return "password_tips";
            if (lower.Contains("scam")) return "scam_tips";
            if (lower.Contains("privacy")) return "privacy_tips";
            if (lower.Contains("phishing")) return "phishing_tips";
            if (lower.Contains("safe browsing")) return "browsing_tips";

            return "default";
        }
    }
}
