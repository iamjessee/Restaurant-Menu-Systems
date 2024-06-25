using System.ComponentModel.Design;
using System.Linq;

namespace Restaurant_Menu_System_V3
{
    public class OrderInputAndOptions
    {
        public decimal Cost { get; set; }
        public List<string> burritoChoices = new List<string>();
        public List<string> addonChoices = new List<string>();

        // collects user input and verifies it is valid and fits within the choice parameters provided
        public int GetIntegerInput(string message, int minValue, int maxValue)
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
        // prompts user to enter their tortilla choice
        public void ChooseTortilla()
        {
            string[] lines =
            { "\nTORTILLA CHOICE:",
            "1. FLOUR",
            "2. CORN",
            "3. SPICY CAYENNE" };

            Console.WriteLine(string.Join(Environment.NewLine, lines));

            int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3) - 1;

            string[] tortillaChoiceOptions = { "FLOUR TORTILLA", "CORN TORTILLA", "SPICY CAYENNE TORTILLA" };

            // shows user what they selected
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
        }

        // prompts user to enter their protein choice
        public void ChooseProtein()
        {
            string[] lines =
            { "\nPROTEIN CHOICE:",
            "1. STEAK....$11.10",
            "2. PORK....$10.00",
            "3. CHORIZO....$9.85",
            "4. CHICKEN....$9.35" };

            Console.WriteLine(string.Join(Environment.NewLine, lines));

            int tortillaChoice = GetIntegerInput("Enter your protein choice: ", 1, 4) - 1;

            string[] tortillaChoiceOptions = { "STEAK", "PORK", "CHORIZO", "CHICKEN" };
            decimal[] tortillaChoicePrices = { 11.10m, 10.00m, 9.85m, 9.35m };

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
            Cost += tortillaChoicePrices[tortillaChoice];

            // shows user what they selected and total cost of selection
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}, Your new total is ${Cost}");

            // checks if user would like to double their protein and adds cost to their total
            Console.WriteLine($"Would you like to pick double your protein for ${Math.Round(Cost * 0.40m, 2)} ? (Y/N)");
            string userResponse = Console.ReadLine().ToUpper();

            bool addOnProtein = false;

            do
            {
                if (userResponse == "Y")
                {
                    Cost += tortillaChoicePrices[tortillaChoice] * 0.40m;
                    Console.WriteLine($"You have chosen double protein. Your new total is: ${Math.Round(Cost, 2)}");
                    burritoChoices[1] += " x2 PROTEIN";
                    addOnProtein = true;
                }
                else if (userResponse == "N")
                {
                    addOnProtein = true;
                }
                else
                {
                    Console.WriteLine("Please enter Y/N to continue.");
                    userResponse = Console.ReadLine().ToUpper();
                }
            }
            while (!addOnProtein);
        }

        // prompts user to enter their rice choice
        public void ChooseRice()
        {
            string[] lines =
            { "\nRICE CHOICE:",
            "1. SPANISH RICE",
            "2. CILANTRO LIME RICE",
            "3. BROWN RICE",
            "4. NO RICE" };

            Console.WriteLine(string.Join(Environment.NewLine, lines));

            int tortillaChoice = GetIntegerInput("Enter your rice choice: ", 1, 4) - 1;

            string[] tortillaChoiceOptions = { "SPANISH RICE", "CILANTRO LIME RICE", "BROWN RICE", "NO RICE" };

            // shows user what they selected and total cost of selection
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
        }

        // prompts user to enter their bean choice
        public void ChooseBeans()
        {
            string[] lines =
            { "\nRICE CHOICE:",
            "1. BLACK BEANS",
            "2. PINTO BEANS",
            "3. REFRIED BEANS",
            "4. NO BEANS" };

            Console.WriteLine(string.Join(Environment.NewLine, lines));

            int tortillaChoice = GetIntegerInput("Enter your bean choice: ", 1, 4) - 1;

            string[] tortillaChoiceOptions = { "BLACK BEANS", "PINTO BEANS", "REFRIED BEANS", "NO BEANS" };

            // shows user what they selected and total cost of selection
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
        }

        // prompts user to enter their add-on choices
        public void ChooseAddOns()
        {
            bool keepAddingAddOns = true;

            string[] lines =
            { "\nADD-ON CHOICE:",
            "1. GRILLED CORN",
            "2. LETTUCE",
            "3. ONIONS",
            "4. SOUR CREAM",
            "5. POTATOES",
            "6. CHEESE",
            "7. QUESO....$1.60",
            "8. GUACAMOLE....$2.65"};

            while (keepAddingAddOns)
            {
                Console.WriteLine(string.Join(Environment.NewLine, lines));

                int addonChoice = GetIntegerInput("Enter your add-on choice: ", 1, 8) - 1;

                string[] addonChoiceOptions = { "GRILLED CORN", "LETTUCE", "ONIONS", "SOUR CREAM", "POTATOES", "CHEESE", "QUESO", "GUACAMOLE" };
                decimal[] addonChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 1.60m, 2.65m };
                if (addonChoices.Contains(addonChoiceOptions[addonChoice]))
                {
                    Console.WriteLine($"You have already selected {addonChoiceOptions[addonChoice]}. Please choose a different add-on.");
                }
                else
                {
                    // adds add-on choice to list to display as receipt later
                    addonChoices.Add($"{addonChoiceOptions[addonChoice]}");
                    Cost += addonChoicePrices[addonChoice];

                    // Show the user what they selected
                    Console.WriteLine($"You selected: {addonChoiceOptions[addonChoice]}.");
                }

                keepAddingAddOns = CheckAddonList();
            }
        }

        // prompts user for if they would like to add more add-ons to their order
        public bool CheckAddonList()
        { 
            Console.WriteLine("Would you like to pick another add-on? (Y/N)");
            string userResponse = Console.ReadLine().ToUpper();

            while (userResponse != "Y" && userResponse != "N")
            {
                Console.WriteLine("Please enter Y or N to continue.");
                userResponse = Console.ReadLine().ToUpper();
            }

            return userResponse == "Y";
        }
    }
}
