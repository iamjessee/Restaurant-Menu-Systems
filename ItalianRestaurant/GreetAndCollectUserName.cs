using System.Text.RegularExpressions;

namespace ItalianRestaurant
{
    public class GreetAndCollectUserName
    {
        /// <summary>
        /// gets the user's name
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// greets the user and collects a name for the order
        /// </summary>
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

        /// <summary>
        /// validates the username to only include letters and spaces 
        /// as well as the name is between 1 and 26 characters long
        /// </summary>
        /// <param name="name">the name to validate</param>
        /// <returns>true if name is valid, otherwise false</returns>
        public bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]{1,26}$");
        }
    }
}