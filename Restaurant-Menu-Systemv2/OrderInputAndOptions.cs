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

        // displays user menu options using array of menu choices and shows a price if menu item has one
        public void DisplayOrderOptions(string orderType, string[] orderOptions, decimal[] orderPrices)
        {
            Console.WriteLine($"\n{orderType}");
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

        public bool AskYesNoQuestion(string question)
        {
            do
            {
                Console.WriteLine($"{question}(Y/N)");
                string userResponse = Console.ReadLine().ToUpper();

                if (userResponse == "Y")
                {
                    return true;
                }
                else if (userResponse == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter Y/N to continue.");
                }
            } while (true);
        }

        // prompts user to enter their tortilla choice
        public void ChooseTortilla()
        {
            string[] tortillaChoiceOptions = { "FLOUR TORTILLA", "CORN TORTILLA", "SPICY CAYENNE TORTILLA" };
            decimal[] tortillaChoicePrices = { 0.00m, 0.00m, 0.00m};
            DisplayOrderOptions("TORTILLA CHOICE:", tortillaChoiceOptions, tortillaChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3) - 1;

            // shows user what they selected
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
        }

        // prompts user to enter their protein choice
        public void ChooseProtein()
        {
            string[] tortillaChoiceOptions = { "STEAK", "PORK", "CHORIZO", "CHICKEN" };
            decimal[] tortillaChoicePrices = { 11.10m, 10.00m, 9.85m, 9.35m };
            DisplayOrderOptions("PROTEIN CHOICE:", tortillaChoiceOptions, tortillaChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your protein choice: ", 1, 4) - 1;

            // adds tortilla choice to list to display as receipt later
            burritoChoices.Add(tortillaChoiceOptions[tortillaChoice]);
            Cost += tortillaChoicePrices[tortillaChoice];

            // shows user what they selected and total cost of selection
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}, Your new total is ${Cost}");

            bool addOnProtein = false;

            do
            {
                if (AskYesNoQuestion($"Would you like to pick double your protein for ${Math.Round(Cost * 0.40m, 2)}?"))
                {
                    Cost += tortillaChoicePrices[tortillaChoice] * 0.40m;
                    Console.WriteLine($"You have chosen double protein. Your new total is: ${Math.Round(Cost, 2)}");
                    burritoChoices[1] += " x2 PROTEIN";
                    addOnProtein = true;
                }
                else
                {
                    addOnProtein = true;
                }
            }
            while (!addOnProtein);
        }

        // prompts user to enter their rice choice
        public void ChooseRice()
        {
            string[] tortillaChoiceOptions = { "SPANISH RICE", "CILANTRO LIME RICE", "BROWN RICE", "NO RICE" };
            decimal[] tortillaChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, };
            DisplayOrderOptions("RICE CHOICE:", tortillaChoiceOptions, tortillaChoicePrices);
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
            DisplayOrderOptions("BEAN CHOICE:", tortillaChoiceOptions, tortillaChoicePrices);
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
                string[] addonChoiceOptions = { "GRILLED CORN", "LETTUCE", "ONIONS", "SOUR CREAM", "POTATOES", "CHEESE", "QUESO", "GUACAMOLE" };
                decimal[] addonChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 1.60m, 2.65m };
                DisplayOrderOptions("RICE CHOICE:", addonChoiceOptions, addonChoicePrices);
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
                keepAddingAddOns = AskYesNoQuestion("Would you like to pick another add-on?");
            }
        }
    }
}