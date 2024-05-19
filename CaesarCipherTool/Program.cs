using System;

namespace CaesarCipherTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caesar Cipher Encryption/Decryption Tool");
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Encrypt a message");
                Console.WriteLine("2. Decrypt a message");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EncryptMessage();
                        break;
                    case "2":
                        DecryptMessage();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void EncryptMessage()
        {
            Console.Write("Enter the message to encrypt: ");
            string message = Console.ReadLine();
            Console.Write("Enter the shift key (1-25): ");
            if (int.TryParse(Console.ReadLine(), out int shiftKey) && shiftKey > 0 && shiftKey < 26)
            {
                string encryptedMessage = CaesarCipher(message, shiftKey);
                Console.WriteLine($"Encrypted message: {encryptedMessage}");
            }
            else
            {
                Console.WriteLine("Invalid shift key. Please enter a number between 1 and 25.");
            }
        }

        static void DecryptMessage()
        {
            Console.Write("Enter the message to decrypt: ");
            string message = Console.ReadLine();
            Console.Write("Enter the shift key (1-25): ");
            if (int.TryParse(Console.ReadLine(), out int shiftKey) && shiftKey > 0 && shiftKey < 26)
            {
                string decryptedMessage = CaesarCipher(message, -shiftKey);
                Console.WriteLine($"Decrypted message: {decryptedMessage}");
            }
            else
            {
                Console.WriteLine("Invalid shift key. Please enter a number between 1 and 25.");
            }
        }

        static string CaesarCipher(string message, int shift)
        {
            char[] buffer = message.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    letter = (char)(((letter + shift - offset + 26) % 26) + offset);
                    buffer[i] = letter;
                }
            }
            return new string(buffer);
        }
    }
}
