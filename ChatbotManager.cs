using System;
using System.Collections.Generic;

namespace CyberSecurityChatBotGUI
{
    class ChatbotManager
    {
        Random random = new Random();

        List<string> phishingResponses = new List<string>()
        {
            "Avoid clicking suspicious links.",
            "Never trust emails asking for passwords.",
            "Phishing scams often pretend to be trusted companies."
        };

        public string GetResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("password"))
            {
                return "Use strong passwords with symbols and numbers.";
            }

            else if (input.Contains("phishing"))
            {
                int index = random.Next(phishingResponses.Count);

                return phishingResponses[index];
            }

            else if (input.Contains("privacy"))
            {
                return "Protect your personal information online.";
            }

            else if (input.Contains("scam"))
            {
                return "Be careful of online scams and fake websites.";
            }

            else
            {
                return "I do not understand. Please try again.";
            }
        }
    }
}