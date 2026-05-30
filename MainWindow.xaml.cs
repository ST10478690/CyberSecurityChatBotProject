using System;
using System.IO;
using System.Media;
using System.Windows;
using System.Threading.Tasks;

namespace CyberSecurityChatBotGUI
{
    public partial class MainWindow : Window
    {
        ChatbotManager chatbot = new ChatbotManager();
        SentimentAnalyzer sentiment = new SentimentAnalyzer();
        MemoryManager memory = new MemoryManager();

        public MainWindow()
        {
            InitializeComponent();

            PlayGreeting();

            ChatDisplay.Text += "Bot: Hello! Welcome to the Cybersecurity Awareness Bot.\n";
        }

        // 🌟 TYPING EFFECT
        private async Task ShowTypingEffect()
        {
            ChatDisplay.Text += "Bot is typing...\n";
            await Task.Delay(1200);
        }

        // 🌟 SAVE CHAT TO FILE
        private void SaveChatToFile(string message)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "chatlog.txt");
            File.AppendAllText(path, message + Environment.NewLine);
        }

        // 🌟 VOICE GREETING
        private void PlayGreeting()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets/greeting.wav");

                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
            catch
            {
                MessageBox.Show("Audio could not play.");
            }
        }

        // 🌟 MAIN CHAT FUNCTION
        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text;

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                ChatDisplay.Text += "Bot: Please enter a message.\n";
                return;
            }

            ChatDisplay.Text += "You: " + userMessage + "\n";
            SaveChatToFile("You: " + userMessage);

            // 🌟 MEMORY FEATURE
            if (userMessage.ToLower().Contains("i like"))
            {
                string topic = userMessage.Replace("I like", "");

                memory.SaveTopic(topic);

                await ShowTypingEffect();
                string msg = "I will remember that you like " + topic;

                ChatDisplay.Text += "Bot: " + msg + "\n";
                SaveChatToFile("Bot: " + msg);

                UserInput.Clear();
                return;
            }

            if (userMessage.ToLower().Contains("what do i like"))
            {
                await ShowTypingEffect();

                string msg = "You told me you like " + memory.RecallTopic();

                ChatDisplay.Text += "Bot: " + msg + "\n";
                SaveChatToFile("Bot: " + msg);

                UserInput.Clear();
                return;
            }

            // 🌟 SENTIMENT FEATURE
            string emotionResponse = sentiment.DetectEmotion(userMessage);

            if (!string.IsNullOrEmpty(emotionResponse))
            {
                await ShowTypingEffect();

                ChatDisplay.Text += "Bot: " + emotionResponse + "\n";
                SaveChatToFile("Bot: " + emotionResponse);

                UserInput.Clear();
                return;
            }

            // 🌟 NORMAL CHATBOT RESPONSE
            string response = chatbot.GetResponse(userMessage);

            await ShowTypingEffect();

            ChatDisplay.Text += "Bot: " + response + "\n";
            SaveChatToFile("Bot: " + response);

            UserInput.Clear();
        }
    }
}