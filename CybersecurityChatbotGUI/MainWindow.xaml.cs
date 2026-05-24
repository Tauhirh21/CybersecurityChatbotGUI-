using System;
using System.Windows;
using System.Windows.Input;
using CybersecurityChatbotGUI.Services;
using CybersecurityChatbotGUI.Utils;

namespace CybersecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        private string _userName = "";

        public MainWindow()
        {
            InitializeComponent();
            AsciiArtBlock.Text = AsciiArtHelper.GetLogo();
            AudioService.PlayGreeting();
            AppendMessage("Bot", "Hello! What's your name?");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessInput();
        }

        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ProcessInput();
        }

        private void ProcessInput()
        {
            string input = UserInput.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                AppendMessage("System", "Please type something.");
                UserInput.Clear();
                return;
            }

            AppendMessage("You", input);
            UserInput.Clear();

            // First, capture the user's name
            if (string.IsNullOrEmpty(_userName))
            {
                _userName = input;
                AppendMessage("Bot", $"Nice to meet you, {_userName}! Ask me about passwords, scams, privacy, phishing, or safe browsing.");
                return;
            }


            // Use KeywordService to find which topic
            string key = KeywordService.GetResponseKey(input);
            // Use ResponseService to get a random response for that topic
            string response = ResponseService.GetRandomResponse(key);
            AppendMessage("Bot", response);
        }

        private void AppendMessage(string sender, string message)
        {
            ChatHistory.Items.Add($"[{DateTime.Now:HH:mm:ss}] {sender}: {message}");
            // Auto-scroll to the latest message
            ChatHistory.ScrollIntoView(ChatHistory.Items[ChatHistory.Items.Count - 1]);
        }
    }
}

