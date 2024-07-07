using System.ComponentModel.Design;
using System.Linq;
using System.Xml.Linq;

namespace Restaurant_Menu_System_V3
{
    // Manages order input and options selection
    public class OrderInputAndOptions
    {
        // Property to get and set the burrito choices
        public List<MenuOption> BurritoChoices { get; private set; }

        // Constructor initializes the BurritoChoices list
        public OrderInputAndOptions()
        {
            BurritoChoices = new List<MenuOption>();
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
        public void DisplayOrderOptions(string orderType, MenuOption[] options)
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
            MenuOption[] tortillaMenuOption =
            {
                new MenuOption() { ItemName = "FLOUR TORTILLA", Price = 0.00m },
                new MenuOption() { ItemName = "CORN TORTILLA", Price = 0.00m },
                new MenuOption() { ItemName = "SPICY CAYENNE TORTILLA", Price = 0.00m }
            };

            DisplayOrderOptions("TORTILLA CHOICE:", tortillaMenuOption);
            int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3) - 1;

            BurritoChoices.Insert(0, (tortillaMenuOption[tortillaChoice]));
            Console.WriteLine($"You selected: {tortillaMenuOption[tortillaChoice].ItemName}.");
        }

        // Prompts user to choose a protein
        public void ChooseProtein()
        {
            MenuOption[] proteinMenuOption =
            {
                new MenuOption() { ItemName = "STEAK", Price = 11.10m },
                new MenuOption() { ItemName = "PORK", Price = 10.00m },
                new MenuOption() { ItemName = "CHORIZO", Price = 9.85m },
                new MenuOption() { ItemName = "CHICKEN", Price = 9.35m }
            };

            DisplayOrderOptions("PROTEIN CHOICE:", proteinMenuOption);
            int proteinChoice = GetIntegerInput("Enter your protein choice: ", 1, 4) - 1;

            BurritoChoices.Insert(1, (proteinMenuOption[proteinChoice]));
            Console.WriteLine($"You selected: {proteinMenuOption[proteinChoice].ItemName}, Your new total is ${proteinMenuOption[proteinChoice].Price}");

            if (GetYesNoResponse($"Would you like to pick double your protein for ${Math.Round(proteinMenuOption[proteinChoice].Price * 0.40m, 2)}?"))
            {
                Console.WriteLine($"You have chosen double protein. Your new total is: ${Math.Round(proteinMenuOption[proteinChoice].Price, 2)}");

                MenuOption[] doubleProteinMenuOption =
                {
                   new MenuOption() { ItemName = "X2 PROTEIN", Price = proteinMenuOption[proteinChoice].Price * 0.40m }
                };

                BurritoChoices.Insert(2, doubleProteinMenuOption[0]);
            }
        }

        // Prompts user to choose a rice option
        public void ChooseRice()
        {
            MenuOption[] riceMenuOption =
            {
                new MenuOption() { ItemName = "SPANISH RICE", Price = 0.00m },
                new MenuOption() { ItemName = "CILANTRO LIME RICE", Price = 0.00m },
                new MenuOption() { ItemName = "BROWN RICE", Price = 0.00m },
                new MenuOption() { ItemName = "NO RICE", Price = 0.00m }
            };

            DisplayOrderOptions("RICE CHOICE:", riceMenuOption);
            int riceChoice = GetIntegerInput("Enter your rice choice: ", 1, 4) - 1;

            BurritoChoices.Insert(3, (riceMenuOption[riceChoice]));
            Console.WriteLine($"You selected: {riceMenuOption[riceChoice].ItemName}.");
        }

        // Prompts user to choose a bean option
        public void ChooseBeans()
        {
            MenuOption[] beanMenuOption =
            {
                new MenuOption() { ItemName = "SPANISH RICE", Price = 0.00m },
                new MenuOption() { ItemName = "CILANTRO LIME RICE", Price = 0.00m },
                new MenuOption() { ItemName = "BROWN RICE", Price = 0.00m },
                new MenuOption() { ItemName = "NO RICE", Price = 0.00m }
            };

            DisplayOrderOptions("BEAN CHOICE:", beanMenuOption);
            int beanChoice = GetIntegerInput("Enter your bean choice: ", 1, 4) - 1;

            BurritoChoices.Insert(4, (beanMenuOption[beanChoice]));
            Console.WriteLine($"You selected: {beanMenuOption[beanChoice].ItemName}.");
        }

        // Prompts user to choose add-ons
        public void ChooseAddOns()
        {
            MenuOption[] addonMenuOption =
            {
                new MenuOption() { ItemName = "GRILLED CORN", Price = 0.00m },
                new MenuOption() { ItemName = "LETTUCE", Price = 0.00m },
                new MenuOption() { ItemName = "ONIONS", Price = 0.00m },
                new MenuOption() { ItemName = "SOUR CREAM", Price = 0.00m },
                new MenuOption() { ItemName = "POTATOES", Price = 0.00m },
                new MenuOption() { ItemName = "CHEESE", Price = 0.00m },
                new MenuOption() { ItemName = "QUESO", Price = 1.60m },
                new MenuOption() { ItemName = "GUACAMOLE",Price = 2.65m },
            };

            while (true)
            {
                DisplayOrderOptions("RICE CHOICE:", addonMenuOption);
                int addonChoice = GetIntegerInput("Enter your add-on choice: ", 1, 8) - 1;

                if (BurritoChoices.Contains(addonMenuOption[addonChoice]))
                {
                    Console.WriteLine($"You have already selected {addonMenuOption[addonChoice].ItemName}. Please choose a different add-on.");
                }
                else
                {
                    if (addonMenuOption[addonChoice].Price == 0.00m)
                    {
                        BurritoChoices.Add(addonMenuOption[addonChoice]);
                        Console.WriteLine($"You selected: {addonMenuOption[addonChoice].ItemName}.");
                    }
                    else
                    {
                        BurritoChoices.Add(addonMenuOption[addonChoice]);
                        Console.WriteLine($"You selected: {addonMenuOption[addonChoice].ItemName}.");
                    }
                }

                if (!GetYesNoResponse("Would you like to pick another add-on?"))
                {
                    break;
                }
            }
        }
    }
}