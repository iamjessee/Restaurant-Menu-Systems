namespace Restaurant_Menu_System_V3;

public static class UserName
{
    // Property to get and set the name
    public static string? Name { get; private set; }

    // Greets the user and prompts them to enter a name for the order
    public static void GreetAndCollectName()
    {
        WriteLine("Hello, Welcome to Bullard's Bussin' Burritos.");

        while (true)
        {
            WriteLine("Please enter a name for this order: ");
            if (IsValidName(Name = ReadLine()))
            {
                WriteLine($"Welcome {Name} Please use the numbers provided when making a selection.");
                break;
            }
            else
            {
                WriteLine("Enter a name using only alphabetical characters and less than 26 characters");
            }
        }
    }
}