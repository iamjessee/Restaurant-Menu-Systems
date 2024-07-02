using System.Text.RegularExpressions;

namespace Restaurant_Menu_System_V3
{
    public class OrderName
    {
        private string _name;

        // Property to get and set the name
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        // Greets the user and prompts them to enter a name for the order
        public void GreetAndCollectName()
        {
            Console.WriteLine("Hello, Welcome to Bullard's Bussin' Burritos.");

            while (true)
            {
                Console.WriteLine("Please enter a name for this order: ");
                string input = Console.ReadLine();

                if (IsValidName(input))
                {
                    _name = input;
                    Console.WriteLine($"Welcome {_name} Please use the numbers provided when making a selection.");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a name using only alphabetical characters and less than 26 characters");
                }
            }
        }

        // Validates the user's name to ensure it contains only alphabetical characters and spaces, and is between 1 and 26 characters long
        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]{1,26}$");
        }
    }
}