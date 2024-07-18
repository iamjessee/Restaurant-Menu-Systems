using System.Text.RegularExpressions;

namespace Restaurant_Menu_System_V3;

public partial class OrderName
{
    // Property to get and set the name
    public string? Name { get; private set; }

    // Greets the user and prompts them to enter a name for the order
    public void GreetAndCollectName()
    {
        Console.WriteLine("Hello, Welcome to Bullard's Bussin' Burritos.");

        while (true)
        {
            Console.WriteLine("Please enter a name for this order: ");
            if (IsValidName(Name = Console.ReadLine()))
            {
                Console.WriteLine($"Welcome {Name} Please use the numbers provided when making a selection.");
                break;
            }
            else
            {
                Console.WriteLine("Enter a name using only alphabetical characters and less than 26 characters");
            }
        }
    }

    // Validates the user's name to ensure it contains only alphabetical characters and spaces, and is between 1 and 26 characters long
    public static bool IsValidName(string? name) => name != null && MyRegex().IsMatch(name);

    [GeneratedRegex(@"^[a-zA-Z\s]{1,26}$")]
    private static partial Regex MyRegex();
}