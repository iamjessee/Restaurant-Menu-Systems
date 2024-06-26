using System.Text.RegularExpressions;

namespace Restaurant_Menu_System_V3
{
    public class OrderName
    {
        private string name;

        // Property to get and set the name
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        // greets user and prompts them to enter a name to personalize their order
        public void DisplayGreetingAndCollectName()
        {
            Console.WriteLine("Hello, Welcome to Bullard's Bussin' Burritos.");

            while (true)
            {
                Console.WriteLine("Please enter a name for this order: ");
                string input = Console.ReadLine();

                if (IsValidName(input))
                {
                    Name = input;
                    Console.WriteLine($"Welcome {Name} Please use the numbers provided when making a selection.");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a name using only alphabetical characters and less than 26 characters");
                }
            }
        }

        // method to validate the users name
        // Ensures the name consists of alphabetical characters and spaces only, and is between 1 and 26 characters long
        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]{1,26}$");
        }
    }

}
