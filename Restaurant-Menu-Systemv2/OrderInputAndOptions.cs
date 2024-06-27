using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Linq;

namespace Restaurant_Menu_System_V3
{
    // find a way to display selections to use via the already existing arrays
    public class OrderInputAndOptions
    {
        private decimal cost { get; set; }
        private List<string> burritoChoices = new List<string>();
        private List<string> addonChoices = new List<string>();

        // Property to get and set the cost
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        // Property to get and set the burritoChoices
        public List<string> BurritoChoices
        {
            get { return burritoChoices; }
            private set { burritoChoices = value; }
        }

        // Property to get and set the addonChoices
        public List<string> AddonChoices
        {
            get { return addonChoices; }
            private set { addonChoices = value; }
        }

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
            Console.WriteLine("\nTORTILLA CHOICE:");
            string[] tortillaChoiceOptions = { "FLOUR TORTILLA", "CORN TORTILLA", "SPICY CAYENNE TORTILLA" };
            decimal[] tortillaChoicePrices = { 0.00m, 0.00m, 0.00m};
            DisplayOrderOptions(tortillaChoiceOptions, tortillaChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3) - 1;

            // shows user what they selected
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
        }

        // prompts user to enter their protein choice
        public void ChooseProtein()
        {
            Console.WriteLine("\nPROTEIN CHOICE:");
            string[] tortillaChoiceOptions = { "STEAK", "PORK", "CHORIZO", "CHICKEN" };
            decimal[] tortillaChoicePrices = { 11.10m, 10.00m, 9.85m, 9.35m };
            DisplayOrderOptions(tortillaChoiceOptions, tortillaChoicePrices);

            //Console.WriteLine(string.Join(Environment.NewLine, lines));

            int tortillaChoice = GetIntegerInput("Enter your protein choice: ", 1, 4) - 1;

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
            Console.WriteLine("\nRICE CHOICE:");
            string[] tortillaChoiceOptions = { "SPANISH RICE", "CILANTRO LIME RICE", "BROWN RICE", "NO RICE" };
            decimal[] tortillaChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, };
            DisplayOrderOptions(tortillaChoiceOptions, tortillaChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your rice choice: ", 1, 4) - 1;

            // shows user what they selected and total cost of selection
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
        }

        // prompts user to enter their bean choice
        public void ChooseBeans()
        {
            string[] tortillaChoiceOptions = { "BLACK BEANS", "PINTO BEANS", "REFRIED BEANS", "NO BEANS" };
            decimal[] tortillaChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, };
            Console.WriteLine("\nBEAN CHOICE:");
            DisplayOrderOptions(tortillaChoiceOptions, tortillaChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your bean choice: ", 1, 4) - 1;

            // shows user what they selected and total cost of selection
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
        }

        // prompts user to enter their add-on choices
        public void ChooseAddOns()
        {
            bool keepAddingAddOns = true;

            while (keepAddingAddOns)
            {
                Console.WriteLine("\nRICE CHOICE:");
                string[] addonChoiceOptions = { "GRILLED CORN", "LETTUCE", "ONIONS", "SOUR CREAM", "POTATOES", "CHEESE", "QUESO", "GUACAMOLE" };
                decimal[] addonChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 1.60m, 2.65m };
                DisplayOrderOptions(addonChoiceOptions, addonChoicePrices);
                int addonChoice = GetIntegerInput("Enter your add-on choice: ", 1, 8) - 1;

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
        public void DisplayOrderOptions(string[] orderOptions, decimal[] orderPrices)
        {
            for (int i = 0; i < orderOptions.Length; i++)
            {
                if (orderPrices[i] == 0.00m)
                {
                    Console.WriteLine($"{i + 1}. {orderOptions[i].ToUpper()}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {orderOptions[i].ToUpper()}....${orderPrices[i]}");
                }
            }
        }
    }
}