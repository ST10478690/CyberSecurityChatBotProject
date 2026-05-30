namespace CyberSecurityChatBotGUI
{
    class SentimentAnalyzer
    {
        public string DetectEmotion(string input)
        {
            input = input.ToLower();

            if (input.Contains("sad") || input.Contains("worried") || input.Contains("scared"))
            {
                return "I'm here for you 💙 Cybersecurity can feel overwhelming, but I will help you step by step.";
            }

            else if (input.Contains("happy") || input.Contains("good"))
            {
                return "That's great to hear 😄 Let's keep learning safely online!";
            }

            else if (input.Contains("confused"))
            {
                return "No worries 😊 I will explain things simply for you.";
            }

            return "";
        }
    }
}