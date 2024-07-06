using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Linq;

namespace Restaurant_Menu_System_V3
{
    // Manages order input and options selection
    public class OrderInputAndOptions
    {
        private decimal _cost { get; set; }
        private List<string> _burritoChoices = new List<string>();
        private List<string> addonChoices = new List<string>();

        // Property to get and set the cost
        public decimal Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        // Property to get and set the burrito choices
        public List<string> BurritoChoices
        {
            get { return _burritoChoices; }
            private set { _burritoChoices = value; }
        }

        // Property to get and set the add-on choices
        public List<string> AddonChoices
        {
            get { return addonChoices; }
            private set { addonChoices = value; }
        }

        // Collects user input and verifies it is valid and within the provided range
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

        // Displays menu options with their prices
        public void DisplayOrderOptions(string orderType, string[] options, decimal[] prices)
        {
            Console.WriteLine($"\n{orderType}");
            for (int i = 0; i < options.Length; i++)
            {
                if (prices[i] == 0.00m)
                {
                    Console.WriteLine($"{i + 1}. {options[i].ToUpper()}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {options[i].ToUpper()}....${prices[i]}");
                }
            }
        }

        // Asks a yes/no question and returns the user's response as a boolean
        public bool GetYesNoResponse(string question)
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

        // Prompts user to choose a tortilla
        public void ChooseTortilla()
        {
            string[] tortillaChoiceOptions = { "FLOUR TORTILLA", "CORN TORTILLA", "SPICY CAYENNE TORTILLA" };
            decimal[] tortillaChoicePrices = { 0.00m, 0.00m, 0.00m };
            DisplayOrderOptions("TORTILLA CHOICE:", tortillaChoiceOptions, tortillaChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3) - 1;

            BurritoChoices.Insert(0, (tortillaChoiceOptions[tortillaChoice]));
            Console.WriteLine($"You selected: {tortillaChoiceOptions[tortillaChoice]}.");
        }

        // Prompts user to choose a protein
        public void ChooseProtein()
        {
            string[] proteinChoiceOptions = { "STEAK", "PORK", "CHORIZO", "CHICKEN" };
            decimal[] proteinChoicePrices = { 11.10m, 10.00m, 9.85m, 9.35m };
            DisplayOrderOptions("PROTEIN CHOICE:", proteinChoiceOptions, proteinChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your protein choice: ", 1, 4) - 1;

            Cost += proteinChoicePrices[tortillaChoice];
            BurritoChoices.Insert(1, (proteinChoiceOptions[tortillaChoice]));
            Console.WriteLine($"You selected: {proteinChoiceOptions[tortillaChoice]}, Your new total is ${Cost}");

                if (GetYesNoResponse($"Would you like to pick double your protein for ${Math.Round(Cost * 0.40m, 2)}?"))
                {
                    Cost += proteinChoicePrices[tortillaChoice] * 0.40m;
                    Console.WriteLine($"You have chosen double protein. Your new total is: ${Math.Round(Cost, 2)}");
                    BurritoChoices[1] += " x2 PROTEIN";
                }
        }

        // Prompts user to choose a rice option
        public void ChooseRice()
        {
            string[] riceChoiceOptions = { "SPANISH RICE", "CILANTRO LIME RICE", "BROWN RICE", "NO RICE" };
            decimal[] riceChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, };
            DisplayOrderOptions("RICE CHOICE:", riceChoiceOptions, riceChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your rice choice: ", 1, 4) - 1;

            BurritoChoices.Insert(2, (riceChoiceOptions[tortillaChoice]));
            Console.WriteLine($"You selected: {riceChoiceOptions[tortillaChoice]}.");
        }

        // Prompts user to choose a bean option
        public void ChooseBeans()
        {
            string[] beanChoiceOptions = { "BLACK BEANS", "PINTO BEANS", "REFRIED BEANS", "NO BEANS" };
            decimal[] beanChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, };
            DisplayOrderOptions("BEAN CHOICE:", beanChoiceOptions, beanChoicePrices);
            int tortillaChoice = GetIntegerInput("Enter your bean choice: ", 1, 4) - 1;
            
            BurritoChoices.Insert(3, (beanChoiceOptions[tortillaChoice]));
            Console.WriteLine($"You selected: {beanChoiceOptions[tortillaChoice]}.");
        }

        // Prompts user to choose add-ons
        public void ChooseAddOns()
        {
            string[] addonChoiceOptions = { "GRILLED CORN", "LETTUCE", "ONIONS", "SOUR CREAM", "POTATOES", "CHEESE", "QUESO", "GUACAMOLE" };
            decimal[] addonChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 1.60m, 2.65m };

            while (true)
            {
                DisplayOrderOptions("RICE CHOICE:", addonChoiceOptions, addonChoicePrices);
                int addonChoice = GetIntegerInput("Enter your add-on choice: ", 1, 8) - 1;

                if (AddonChoices.Contains(addonChoiceOptions[addonChoice]))
                {
                    Console.WriteLine($"You have already selected {addonChoiceOptions[addonChoice]}. Please choose a different add-on.");
                }
                else
                {
                    AddonChoices.Add($"{addonChoiceOptions[addonChoice]}");
                    Cost += addonChoicePrices[addonChoice];
                    Console.WriteLine($"You selected: {addonChoiceOptions[addonChoice]}.");
                }

                if (!GetYesNoResponse("Would you like to pick another add-on?"))
                {
                    break;
                }
            }
        }
    }
}