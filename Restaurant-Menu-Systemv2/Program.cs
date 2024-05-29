class Program
{
    static void Main(string[] args)
    {
        // customer greeting message
        Console.WriteLine("Hello, Welcome to Bullard's Bussin' Burritos.");
        Console.WriteLine("Please use the numbers provided when making a selection.");

        //list to store add-on choices
        List<string> allAddonChoices = new List<string>();
        // list to store burrito choices
        List<string> burritoChoices = new List<string>();

        // variable to hold cost of customer order and tax rates
        decimal cost = 0.00m;
        decimal tax = 0.00m;
        decimal taxRate = 0.08m;

        ChooseTortilla(burritoChoices);
        ChooseProtein(burritoChoices, ref cost);
        AddExtraProtein(ref cost);
        ChooseRice(burritoChoices);
        ChooseBeans(burritoChoices);
        ChooseAddons(allAddonChoices);

        Console.WriteLine($"Your order is complete: {GetOrderDescription(burritoChoices, allAddonChoices)}");
        Console.WriteLine($"Your total is: ${CalculateTax(ref cost, ref taxRate, ref tax)} after tax");
    }

    // prompts user to enter their tortilla choice
    static void ChooseTortilla(List<string> burritoChoices)
    {
        Console.WriteLine("\nTORTILLA CHOICE: 1. FLOUR 2. CORN 3. SPICY CAYENNE ");
        int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3);

        switch (tortillaChoice)
        {
            case 1:
                Console.WriteLine("You have chosen a Flour tortilla.");
                burritoChoices.Add("Flour Tortilla");
                break;
            case 2:
                Console.WriteLine("You have chosen a Corn tortilla.");
                burritoChoices.Add("Corn Tortilla");
                break;
            case 3:
                Console.WriteLine("You have chosen a Spicy Cayenne tortilla.");
                burritoChoices.Add("Spicy Cayenne Tortilla");
                break;
        }
    }

    // prompts user to enter their Protein choice
    static void ChooseProtein(List<string> burritoChoices, ref decimal cost)
    {
        Console.WriteLine("\nPROTEIN CHOICE: 1. STEAK $12.99 2. PORK $12.99 3. CHICKEN $9.99 4. CHORIZO $13.99");
        int proteinChoice = GetIntegerInput("Enter your protein choice: ", 1, 4);

        switch (proteinChoice)
        {
            case 1:
                Console.WriteLine($"You have chosen Steak. Your new total is: ${cost += 12.99m}");
                burritoChoices.Add("Steak");
                break;
            case 2:
                Console.WriteLine($"You have chosen Pork. Your new total is: ${cost += 12.99m}");
                burritoChoices.Add("Pork");
                break;
            case 3:
                Console.WriteLine($"You have chosen Chicken. Your new total is: ${cost += 9.99m}");
                burritoChoices.Add("Chicken");
                break;
            case 4:
                Console.WriteLine($"You have chosen Chorizo. Your new total is: ${cost += 13.99m}");
                burritoChoices.Add("Chorizo");
                break;
        }
    }

    // prompts user if they would to double their Protein choice
    static void AddExtraProtein(ref decimal cost)
    {
        while (true)
        {
            Console.WriteLine("\nWould you like to double your protein for $1.99 (Y/N)?");
            string response = Console.ReadLine().ToUpper();
            if (response == "Y")
            {
                Console.WriteLine($"You have chosen double protein. Your new total is: ${cost += 1.99m}");
                break;
            }
            else if (response == "N")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter Y/N to continue.");
            }
        }
    }

    // prompts user to enter their Rice choice
    static void ChooseRice(List<string> burritoChoices)
    {
        Console.WriteLine("\nRICE: 1. SPANISH RICE 2. CILANTRO LIME RICE 3. BROWN RICE 4. NO RICE");
        int riceChoice = GetIntegerInput("Enter your rice choice: ", 1, 4);

        switch (riceChoice)
        {
            case 1:
                Console.WriteLine("You have chosen Spanish Rice.");
                burritoChoices.Add("Spanish Rice");
                break;
            case 2:
                Console.WriteLine("You have chosen Cilantro Lime Rice.");
                burritoChoices.Add("Cilantro Lime Rice");
                break;
            case 3:
                Console.WriteLine("You have chosen Brown Rice.");
                burritoChoices.Add("Brown Rice");
                break;
            case 4:
                Console.WriteLine("You have chosen No Rice.");
                burritoChoices.Add("No Rice");
                break;
        }
    }

    // prompts user to enter their Bean choice
    static void ChooseBeans(List<string> burritoChoices)
    {
        Console.WriteLine("\nBEANS: 1. BLACK BEANS 2. PINTO BEANS 3. REFRIED BEANS 4. NO BEANS");
        int beanChoice = GetIntegerInput("Enter your bean choice: ", 1, 4);

        switch (beanChoice)
        {
            case 1:
                Console.WriteLine("You have chosen Black Beans.");
                burritoChoices.Add("Black Beans");
                break;
            case 2:
                Console.WriteLine("You have chosen Pinto Beans.");
                burritoChoices.Add("Pinto Beans");
                break;
            case 3:
                Console.WriteLine("You have chosen Refried Beans.");
                burritoChoices.Add("Refried Beans");
                break;
            case 4:
                Console.WriteLine("You have chosen No Beans.");
                burritoChoices.Add("No Beans");
                break;
        }
    }
    // prompts user to enter their add-on choices and lets them keep adding more if they choose
    static void ChooseAddons(List<string> allAddonChoices)
    {
        bool addMoreAddons = true;
        do
        {
            Console.WriteLine("\nADD-ONS: 1. GRILLED CORN SALSA 2. LETTUCE 3. ONIONS 4. SOUR CREAM 5. POTATOES 6. CHEESE");
            int addonChoice = GetIntegerInput("Enter your add-on choice: ", 1, 6);

            switch (addonChoice)
            {
                case 1:
                    AddAddon("Grilled Corn Salsa", allAddonChoices);
                    break;
                case 2:
                    AddAddon("Lettuce", allAddonChoices);
                    break;
                case 3:
                    AddAddon("Onions", allAddonChoices);
                    break;
                case 4:
                    AddAddon("Sour Cream", allAddonChoices);
                    break;
                case 5:
                    AddAddon("Potatoes", allAddonChoices);
                    break;
                case 6:
                    AddAddon("Cheese", allAddonChoices);
                    break;
            }

            Console.WriteLine("Would you like to pick another add-on? (Y/N)");
            string userResponse = Console.ReadLine().ToUpper();
            if (userResponse == "Y")
            {
                addMoreAddons = true;
            }
            else if (userResponse == "N")
            {
                addMoreAddons = false;
            }
            else
            {
                Console.WriteLine("Please enter Y/N to continue.");
            }
            

        } while (addMoreAddons);
    }
    //puts user add-on choice into list and prevents user from entering the same add-on choice more than once
    static void AddAddon(string addon, List<string> allAddonChoices)
    {
        if (!allAddonChoices.Contains(addon))
        {
            allAddonChoices.Add(addon);
        }
        else
        {
            Console.WriteLine("You cannot add the same option twice. Please pick another option.");
        }
    }

    // displays users order and cost total
    static string GetOrderDescription(List<string> burritoChoices, List<string> allAddonChoices)
    {
        string burrito = string.Join(", ", burritoChoices);
        string addons = string.Join(", ", allAddonChoices);
        return $"You have chosen a {burrito} with the add-on choices of: {addons}.";
    }

    // verifies the users input is valid for their choices
    static int GetIntegerInput(string message, int minValue, int maxValue)
    {
        int input;
        while (true)
        {
            Console.Write(message);
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("That is not a number...Please enter one of the provided numbers");
            }
            else if (input < minValue || input > maxValue)
            {
                Console.WriteLine("Error! Please enter one of the provided numbers");
            }
            else
            {
                return input;
            }
        }
    }
    static decimal CalculateTax(ref decimal cost, ref decimal taxRate, ref decimal tax)
    {
        tax = cost * taxRate;
        cost += tax;
        cost = Math.Round(cost, 2);

        return cost;
    }
}