namespace Restaurant_Menu_System_V3;

public class OrderName
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
}