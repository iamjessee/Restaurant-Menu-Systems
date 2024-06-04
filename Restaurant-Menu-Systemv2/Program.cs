class Program
{
    static void Main(string[] args)
    {
        // customer greeting message for user gets the customers name to personalize the order 
        Console.WriteLine("Hello, Welcome to Bullard's Bussin' Burritos.");
        Console.WriteLine("Please enter a name for this order: ");
        int wrongInput = 0;
        string customerName = Console.ReadLine();
        // checks if user entered only numbers into the name field, side note, I googled how to ONLY to characters and I saw some crazy thing (Regex regex = new Regex("^[a-zA-Z]+$");) and did not want to just paste it in without asking questions 
        while (true)
        {
            if (!int.TryParse(customerName, out wrongInput))
            {
                Console.WriteLine($"Welcome {customerName} Please use the numbers provided when making a selection.");
                break;
            }
            else
            {
                Console.WriteLine("Please enter a name using alphabetic characters only.");
                customerName = Console.ReadLine();
            }
        }

        //list to store add-on choices
        List<string> allAddonChoices = new List<string>();
        // list to store burrito choices
        List<string> burritoChoices = new List<string>();

        // variable to hold cost of customer order and tax rates
        double cost = 0.00;
        double tax = 0.00;
        double taxRate = 0.0825;

        // calling of our methods to process order for customer
        ChooseTortilla(burritoChoices);
        ChooseProtein(burritoChoices, ref cost);
        AddExtraProtein(ref cost);
        ChooseRice(burritoChoices);
        ChooseBeans(burritoChoices);
        ChooseAddons(allAddonChoices);

        Console.WriteLine($"THANKS {customerName}, YOUR ORDER IS COMPLETE {GetOrderDescription(burritoChoices, allAddonChoices)}");
        Console.WriteLine($"\nSUBTOTAL: ${cost}\nTOTAL: ${GetTaxAmount(ref cost, taxRate, ref tax)}");
        Console.WriteLine($"TAX: ${tax.ToString("0.00")}");

    }

    // prompts user to enter their tortilla choice
    static void ChooseTortilla(List<string> burritoChoices)
    {
        Console.WriteLine("\nTORTILLA CHOICE: 1. FLOUR 2. CORN 3. SPICY CAYENNE");
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
    static void ChooseProtein(List<string> burritoChoices, ref double cost)
    {
        Console.WriteLine("\nPROTEIN CHOICE: 1. CHORIZO $13.99 2. STEAK $12.99 3. PORK $12.99 4. CHICKEN $9.99");
        int proteinChoice = GetIntegerInput("Enter your protein choice: ", 1, 4);

        switch (proteinChoice)
        {
            case 1:
                Console.WriteLine($"You have chosen Chorizo. Your new total is: ${cost += 13.99}");
                burritoChoices.Add("Chorizo");
                break;
            case 2:
                Console.WriteLine($"You have chosen Steak. Your new total is: ${cost += 12.99}");
                burritoChoices.Add("Steak");
                break;
            case 3:
                Console.WriteLine($"You have chosen Pork. Your new total is: ${cost += 12.99}");
                burritoChoices.Add("Pork");
                break;
            case 4:
                Console.WriteLine($"You have chosen Chicken. Your new total is: ${cost += 9.99}");
                burritoChoices.Add("Chicken");
                break;
            
        }
    }

    // prompts user if they would to double their Protein choice
    static void AddExtraProtein(ref double cost)
    {
        while (true)
        {
            Console.WriteLine("\nWould you like to double your protein for $1.99 (Y/N)?");
            string response = Console.ReadLine().ToUpper();
            if (response == "Y")
            {
                Console.WriteLine($"You have chosen double protein. Your new total is: ${cost += 1.99}");
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
        string burrito = string.Join("\n", burritoChoices);
        string addons = string.Join("\n", allAddonChoices);
        return $"You have chosen:\n{burrito}\n{addons}";
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
    // calculates tax rate and adds it to final cost
    static string GetTaxAmount(ref double cost, double taxRate, ref double tax)
    {
        tax = cost * taxRate;
        cost += tax;
        string formatedCost = cost.ToString("0.00");

        return formatedCost;
    }
}