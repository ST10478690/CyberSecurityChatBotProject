namespace CyberSecurityChatBotGUI
{
    class MemoryManager
    {
        public string FavouriteTopic = "";

        public void SaveTopic(string topic)
        {
            FavouriteTopic = topic;
        }

        public string RecallTopic()
        {
            return FavouriteTopic;
        }
    }
}