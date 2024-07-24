using System.Text.RegularExpressions;

namespace ItalianRestaurant
{
    public class GreetAndCollectUserName
    {
        public string UserName { get; private set; }

        // greet user and collect a name for order
        public void GreetAndCollectName()
        {
            Console.WriteLine("Hello, Welcome to Pasta Palooza.");

            Console.WriteLine("Please enter a name for this order: ");
            string input = Console.ReadLine();

            if (IsValidName(input))
            {
                UserName = input;
                Console.WriteLine($"Welcome {UserName}, please use the numbers provided when making a selection.");
            }
            else
            {
                Console.WriteLine("Enter a name using only alphabetical characters and less than 26 characters");
            }

        }

        // validates the user's name to ensure it contains only alphabetical characters and spaces, and is between 1 and 26 characters long
        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]{1,26}$");
        }
    }
}