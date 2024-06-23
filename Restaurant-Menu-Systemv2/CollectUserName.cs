using System.Text.RegularExpressions;

namespace Restaurant_Menu_System_V3
{
    public class OrderName
    {
        public string Name { get; set; }

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
                    Console.WriteLine("Enter a name using only alphabetical characters");
                }
            }
        }

        // method to validate the users name
        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }
    }

}
