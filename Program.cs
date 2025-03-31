using System;
using System.Media;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

namespace CybersecurityAwarenessBot
{
    class Program
    {
        private const string APP_NAME = "Hercules Chatbot"; // Chatbot Name

        public static void Main()
        {
            Console.Title = $"{APP_NAME} - Digital Safety Assistant";

            // ✅ Play the welcome audio file
            PlayWelcomeAudio();

            // ✅ Display ASCII Art
            DisplayTitle();

            // ✅ Start user interaction
            HandleUserInteraction();
        }

        // ✅ Function to play the WAV audio file
        private static void PlayWelcomeAudio()
        {
            try
            {
                string audioFilePath = "Sounds/Fortunate.wav"; // Ensure this file is in the same directory as the program

                if (File.Exists(audioFilePath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioFilePath))
                    {
                        player.PlaySync(); // Play and wait for completion
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Welcome audio file not found.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing audio: {ex.Message}");
                Console.ResetColor();
            }
        }

        // ✅ Function to display ASCII Art
        static void DisplayTitle()
        {
            string title = @"
  _,  ,  ,__   _,,_   _,  _, _,,  , ,_   ___,___,,  ,    _   ,  , _   ,_   _,,  ,  _, _, _,     __   _,  ___,                                                                     
 /    \_/'|_) /_,|_) (_, /_,/  |  | |_) ' | ' |  \_/    '|\  | ,|'|\  |_) /_,|\ | /_,(_,(_,    '|_) / \,' |                                                                       
'\_  , /`_|_)'\_'| \  _)'\_'\_'\__|'| \  _|_, | , /`     |-\ |/\| |-\'| \'\_ |'\|'\_  _) _)    _|_)'\_/   |                                                                       
   `(_/ '       `'  `'     `  `   ` '  `'     '(_/       '  `'  ` '  `'  `  `'  `   `'  '     '     '     '                                                                       
";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        // ✅ Function to display a divider for better UI
        static void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-------------------------------------------------\n");
            Console.ResetColor();
        }

        // ✅ Function to create a typing effect
        static void SimulateTyping(string text, int delay = 50)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // ✅ Function to handle user interaction
        static void HandleUserInteraction()
        {
            DisplayDivider();
            Console.Write("\nPlease enter your name: ");
            string userName = Console.ReadLine()?.Trim();

            while (string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nCybersecurity Bot: Please enter a valid name: ");
                Console.ResetColor();
                userName = Console.ReadLine()?.Trim();
            }

            Console.WriteLine($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot!");
            DisplayDivider();

            SimulateTyping("I'm here to help you stay safe online.\n\n", 50);
            Console.WriteLine("Choose a cybersecurity topic:\n1. Phishing\n2. Password Security\n3. Malware & Viruses\n4. Privacy & Data Protection\nType a number or a related question.");

            while (true)
            {
                DisplayDivider();
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nCybersecurity Bot: Please type something so I can assist you.");
                    Console.ResetColor();
                    continue;
                }

                if (userInput == "exit")
                {
                    SimulateTyping("Goodbye! Stay safe online. 😊", 50);
                    break;
                }

                RespondToUserInput(userInput);
            }
        }

        // ✅ Function to respond based on user input
        static void RespondToUserInput(string input)
        {
            if (input == "1" || Regex.IsMatch(input, @"\b(phishing|scam|fraud)\b"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCybersecurity Bot: Phishing is when attackers try to trick you into giving away personal information.");
                SimulateTyping("Always verify the sender and NEVER click suspicious links or attachments!", 40);
            }
            else if (input == "2" || Regex.IsMatch(input, @"\b(password|security)\b"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCybersecurity Bot: Strong passwords are the foundation of online security.");
                SimulateTyping("Use at least 12 characters, including symbols, numbers, and uppercase/lowercase letters.", 40);
                SimulateTyping("Consider using a password manager for extra protection!", 40);
            }
            else if (input == "3" || Regex.IsMatch(input, @"\b(virus|malware|ransomware)\b"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCybersecurity Bot: Malicious software (malware) can harm your system.");
                SimulateTyping("Always install antivirus software and avoid downloading files from unknown sources.", 40);
            }
            else if (input == "4" || Regex.IsMatch(input, @"\b(privacy|data)\b"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nCybersecurity Bot: Your personal data is valuable.");
                SimulateTyping("Be careful what you share online and use strong privacy settings.", 40);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCybersecurity Bot: I didn't quite understand that. Please choose a topic (1-4) or rephrase your question.");
            }

            Console.ResetColor();
        }
    }
}
