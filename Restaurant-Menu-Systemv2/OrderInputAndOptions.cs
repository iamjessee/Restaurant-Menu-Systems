namespace Restaurant_Menu_System_V3
{
    // manages order input and options selection
    public class OrderInputAndOptions
    {
        // property to store final entrée choices in a list to display at checkout
        public List<List<MenuOption>> AllEntreeChoices { get; } = [];

        // property to get and set the burrito choices as they are selected
        public List<MenuOption> CurrentEntreeChoices { get; private set; } = [];

        // private field to store the customer's receipt details for calculating and displaying the rolling total
        private CustomerReceipt? _customerReceipt;

        // creates a new instance of entrée choices
        public void StartNewBurrito() => CurrentEntreeChoices = [];

        // adds all entrée choices to new list and clears current list
        public void FinalizeEntree()
        {
            if (CurrentEntreeChoices.Count != 0)
            {
                AllEntreeChoices.Add(new List<MenuOption>(CurrentEntreeChoices));
                CurrentEntreeChoices.Clear();
            }
        }

        //set the CustomerReceipt instance enabling rolling total calculation
        public void SetCustomerReceipt(CustomerReceipt receipt) => _customerReceipt = receipt;

        // collects user input and verifies it is valid and within the provided range
        public static int GetIntegerInput(string message, int minValue, int maxValue)
        {
            while (true)
            {
                Console.Write(message);
                if (!int.TryParse(Console.ReadLine(), out int input))
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

        // displays menu options with their prices
        public static void DisplayOrderOptions(string orderType, MenuOption[] options)
        {
            Console.WriteLine($"\n{orderType}");
            int itemCount = 1;
            foreach (MenuOption item in options)
            {
                if (item.Price == 0.00m)
                {
                    Console.WriteLine($"{itemCount}. {item.ItemName.ToUpper()}");
                }
                else
                {
                    Console.WriteLine($"{itemCount}. {item.ItemName.ToUpper()}....{item.Price.ToString("c")}");
                }
                itemCount++;
            }
        }

        // asks a yes/no question and returns the user's response as a boolean
        public static bool GetYesNoResponse(string question)
        {
            while (true)
            {
                Console.WriteLine($"{question}(Y/N)");
                string userResponse = Console.ReadLine() ?? string.Empty;

                if (userResponse.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (userResponse.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                Console.WriteLine("Please enter Y/N to continue.");
            }
        }

        // prompts user to pick their main entrée choice
        public void ChooseEntree()
        {
            MenuOption[] option =
            [
                new MenuOption() { ItemName = "BOWL",    Price = 0.00m },
                new MenuOption() { ItemName = "BURRITO", Price = 0.00m },
            ];

            DisplayOrderOptions("ENTRÉE CHOICE: ", option);
            int choice = GetIntegerInput("Enter your entrée choice: ", 1, 2) - 1;
            CurrentEntreeChoices.Insert(0, option[choice]);
        }

        // prompts user to choose a tortilla
        public void ChooseTortilla()
        {
            MenuOption[] tortillaMenuOption =
            [
                new MenuOption() { ItemName = "FLOUR TORTILLA",         Price = 0.00m },
                new MenuOption() { ItemName = "CORN TORTILLA",          Price = 0.00m },
                new MenuOption() { ItemName = "SPICY CAYENNE TORTILLA", Price = 0.00m }
            ];

            DisplayOrderOptions("TORTILLA CHOICE:", tortillaMenuOption);
            int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3) - 1;

            CurrentEntreeChoices.Add(tortillaMenuOption[tortillaChoice]);
            Console.WriteLine($"You selected: {tortillaMenuOption[tortillaChoice].ItemName}.");
        }

        // prompts user to choose a protein
        public void ChooseProtein()
        {
            MenuOption[] proteinMenuOption =
            [
                new MenuOption() { ItemName = "STEAK",   Price = 11.10m },
                new MenuOption() { ItemName = "PORK",    Price = 10.00m },
                new MenuOption() { ItemName = "CHORIZO", Price =  9.85m },
                new MenuOption() { ItemName = "CHICKEN", Price =  9.35m }
            ];

            DisplayOrderOptions("PROTEIN CHOICE:", proteinMenuOption);
            int proteinChoice = GetIntegerInput("Enter your protein choice: ", 1, 4) - 1;

            CurrentEntreeChoices.Add(proteinMenuOption[proteinChoice]);
            decimal rollingTotal = _customerReceipt?.CalculateSubTotal() ?? throw new Exception("Can't choose protein until customerReceipt is done");
            Console.WriteLine($"You selected: {proteinMenuOption[proteinChoice].ItemName}, Your new total is ${rollingTotal}");

            decimal doubleProteinPrice = Math.Round(proteinMenuOption[proteinChoice].Price * 0.40m, 2);

            if (GetYesNoResponse($"Would you like to double your protein for ${doubleProteinPrice}?"))
            {
                MenuOption[] doubleProteinMenuOption =
                [
                   new MenuOption() { ItemName = "X2 PROTEIN", Price = proteinMenuOption[proteinChoice].Price * 0.40m }
                ];

                CurrentEntreeChoices.Add(doubleProteinMenuOption[0]);
                rollingTotal = _customerReceipt.CalculateSubTotal();
                Console.WriteLine($"You have chosen double protein. Your new total is: ${rollingTotal}");
            }
        }

        // prompts user to choose a rice option
        public void ChooseRice()
        {
            MenuOption[] riceMenuOption =
            [
                new MenuOption() { ItemName = "SPANISH RICE",       Price = 0.00m },
                new MenuOption() { ItemName = "CILANTRO LIME RICE", Price = 0.00m },
                new MenuOption() { ItemName = "BROWN RICE",         Price = 0.00m },
                new MenuOption() { ItemName = "NO RICE",            Price = 0.00m }
            ];

            DisplayOrderOptions("RICE CHOICE:", riceMenuOption);
            int riceChoice = GetIntegerInput("Enter your rice choice: ", 1, 4) - 1;

            CurrentEntreeChoices.Add(riceMenuOption[riceChoice]);
            Console.WriteLine($"You selected: {riceMenuOption[riceChoice].ItemName}.");
        }

        // prompts user to choose a bean option
        public void ChooseBeans()
        {
            MenuOption[] beanMenuOption =
            [
                new MenuOption() { ItemName = "BLACK BEANS",   Price = 0.00m },
                new MenuOption() { ItemName = "PINTO BEANS",   Price = 0.00m },
                new MenuOption() { ItemName = "REFRIED BEANS", Price = 0.00m },
                new MenuOption() { ItemName = "NO BEANS",      Price = 0.00m }
            ];

            DisplayOrderOptions("BEAN CHOICE:", beanMenuOption);
            int beanChoice = GetIntegerInput("Enter your bean choice: ", 1, 4) - 1;

            CurrentEntreeChoices.Add(beanMenuOption[beanChoice]);
            Console.WriteLine($"You selected: {beanMenuOption[beanChoice].ItemName}.");
        }

        // prompts user to choose add-ons
        public void ChooseAddOns()
        {
            MenuOption[] addonMenuOption =
            [
                new MenuOption() { ItemName = "GRILLED CORN", Price = 0.00m },
                new MenuOption() { ItemName = "LETTUCE",      Price = 0.00m },
                new MenuOption() { ItemName = "ONIONS",       Price = 0.00m },
                new MenuOption() { ItemName = "SOUR CREAM",   Price = 0.00m },
                new MenuOption() { ItemName = "POTATOES",     Price = 0.00m },
                new MenuOption() { ItemName = "CHEESE",       Price = 0.00m },
                new MenuOption() { ItemName = "QUESO",        Price = 1.60m },
                new MenuOption() { ItemName = "GUACAMOLE",    Price = 2.65m },
            ];

            do
            {
                DisplayOrderOptions("RICE CHOICE:", addonMenuOption);
                int addonChoice = GetIntegerInput("Enter your add-on choice: ", 1, 8) - 1;

                if (CurrentEntreeChoices.Contains(addonMenuOption[addonChoice]))
                {
                    Console.WriteLine($"You have already selected {addonMenuOption[addonChoice].ItemName}. Please choose a different add-on.");
                }
                else
                {
                    if (addonMenuOption[addonChoice].Price == 0.00m)
                    {
                        CurrentEntreeChoices.Add(addonMenuOption[addonChoice]);
                        Console.WriteLine($"You selected: {addonMenuOption[addonChoice].ItemName}.");
                    }
                    else
                    {
                        CurrentEntreeChoices.Add(addonMenuOption[addonChoice]);
                        decimal rollingTotal = _customerReceipt?.CalculateSubTotal() ?? throw new Exception("Can't choose protein until customerReceipt is done");
                        Console.WriteLine($"You selected: {addonMenuOption[addonChoice].ItemName}. For ${addonMenuOption[addonChoice].Price}. Your new total is ${rollingTotal}");
                    }
                }
            }
            while (GetYesNoResponse("Would you like to pick another add-on?"));
        }

        // clears the previous entrée choice
        public void ClearEntreeChoice() => CurrentEntreeChoices.RemoveAll(choice => choice.ItemName == "BOWL" || choice.ItemName == "BURRITO");

        // clears the previous tortilla choice
        public void ClearTortillaChoice() => CurrentEntreeChoices.RemoveAll(choice => choice.ItemName.Contains("TORTILLA"));


        // clears the previous protein choice
        private static readonly string[] proteinOptions =
        [
            "STEAK",
            "PORK",
            "CHORIZO",
            "CHICKEN",
            "X2 PROTEIN"
        ];
        public void ClearProteinChoice() => CurrentEntreeChoices.RemoveAll(choice => proteinOptions.Contains(choice.ItemName));


        // clears the previous rice choice
        private static readonly string[] richOptions =
        [
            "SPANISH RICE",
            "CILANTRO LIME RICE",
            "BROWN RICE",
            "NO RICE"
        ];
        public void ClearRiceChoice() => CurrentEntreeChoices.RemoveAll(choice => richOptions.Contains(choice.ItemName));

        // clears the previous bean choice
        private static readonly string[] beanOptions =
        [
            "BLACK BEANS",
            "PINTO BEANS",
            "REFRIED BEANS",
            "NO BEANS"
        ];
        public void ClearBeanChoice() => CurrentEntreeChoices.RemoveAll(choice => beanOptions.Contains(choice.ItemName));

        // clears the previous add-on choices
        private static readonly string[] addonOptions =
        [
            "GRILLED CORN",
            "LETTUCE",
            "ONIONS",
            "SOUR CREAM",
            "POTATOES",
            "CHEESE",
            "QUESO",
            "GUACAMOLE"
        ];
        public void ClearAddonChoices() => CurrentEntreeChoices.RemoveAll(choice => addonOptions.Contains(choice.ItemName));
    }
}