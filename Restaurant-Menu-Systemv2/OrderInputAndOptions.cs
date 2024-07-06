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
                    Console.WriteLine($"{itemCount}. {item.Name.ToUpper()}");
                }
                else
                {
                    Console.WriteLine($"{itemCount}. {item.Name.ToUpper()}....{item.Price.ToString("c")}");
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
                new MenuOption()
                {
                    Name = "FLOUR TORTILLA",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "CORN TORTILLA",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "SPICY CAYENNE TORTILLA",
                    Price = 0.00m
                }
            };
            DisplayOrderOptions("TORTILLA CHOICE:", tortillaMenuOption);
            int tortillaChoice = GetIntegerInput("Enter your tortilla choice: ", 1, 3) - 1;

            BurritoChoices.Insert(0, (tortillaMenuOption[tortillaChoice]));
            Console.WriteLine($"You selected: {tortillaMenuOption[tortillaChoice].Name}.");
        }

        // Prompts user to choose a protein
        public void ChooseProtein()
        {
            MenuOption[] proteinMenuOption =
            {
                new MenuOption()
                {
                    Name = "STEAK",
                    Price = 11.10m
                },
                new MenuOption()
                {
                    Name = "PORK",
                    Price = 10.00m
                },
                new MenuOption()
                {
                    Name = "CHORIZO",
                    Price = 9.85m
                },
                new MenuOption()
                {
                    Name = "CHICKEN",
                    Price = 9.35m
                }
            };
            DisplayOrderOptions("PROTEIN CHOICE:", proteinMenuOption);
            int tortillaChoice = GetIntegerInput("Enter your protein choice: ", 1, 4) - 1;

            BurritoChoices.Insert(1, (proteinMenuOption[tortillaChoice]));
            Console.WriteLine($"You selected: {proteinMenuOption[tortillaChoice].Name}, Your new total is ${proteinMenuOption[tortillaChoice].Price}");
            if (GetYesNoResponse($"Would you like to pick double your protein for ${Math.Round(proteinMenuOption[tortillaChoice].Price * 0.40m, 2)}?"))
            {
                Console.WriteLine($"You have chosen double protein. Your new total is: ${Math.Round(proteinMenuOption[tortillaChoice].Price, 2)}");
                BurritoChoices[1].Name += " x2 PROTEIN";
            }
        }

        // Prompts user to choose a rice option
        public void ChooseRice()
        {
            MenuOption[] riceMenuOption =
            {
                new MenuOption()
                {
                    Name = "SPANISH RICE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "CILANTRO LIME RICE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "BROWN RICE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "NO RICE",
                    Price = 0.00m
                }
            };
            DisplayOrderOptions("RICE CHOICE:", riceMenuOption);
            int tortillaChoice = GetIntegerInput("Enter your rice choice: ", 1, 4) - 1;

            BurritoChoices.Insert(2, (riceMenuOption[tortillaChoice]));
            Console.WriteLine($"You selected: {riceMenuOption[tortillaChoice].Name}.");
        }

        // Prompts user to choose a bean option
        public void ChooseBeans()
        {
            MenuOption[] beanMenuOption =
            {
                new MenuOption()
                {
                    Name = "SPANISH RICE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "CILANTRO LIME RICE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "BROWN RICE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "NO RICE",
                    Price = 0.00m
                }
            };
            DisplayOrderOptions("BEAN CHOICE:", beanMenuOption);
            int tortillaChoice = GetIntegerInput("Enter your bean choice: ", 1, 4) - 1;

            BurritoChoices.Insert(3, (beanMenuOption[tortillaChoice]));
            Console.WriteLine($"You selected: {beanMenuOption[tortillaChoice].Name}.");
        }

        // Prompts user to choose add-ons
        public void ChooseAddOns()
        {
            MenuOption[] addonMenuOption =
            {
                new MenuOption()
                {
                    Name = "GRILLED CORN",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "LETTUCE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "ONIONS",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "SOUR CREAM",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "POTATOES",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "CHEESE",
                    Price = 0.00m
                },
                new MenuOption()
                {
                    Name = "QUESO",
                    Price = 1.60m
                },
                new MenuOption()
                {
                    Name = "GUACAMOLE",
                    Price = 2.65m
                },
            };
            while (true)
            {
                DisplayOrderOptions("RICE CHOICE:", addonMenuOption);
                int addonChoice = GetIntegerInput("Enter your add-on choice: ", 1, 8) - 1;

                if (BurritoChoices.Contains(addonMenuOption[addonChoice]))
                {
                    Console.WriteLine($"You have already selected {addonMenuOption[addonChoice].Name}. Please choose a different add-on.");
                }
                else
                {
                    if (addonMenuOption[addonChoice].Price == 0.00m)
                    {
                        BurritoChoices.Add(addonMenuOption[addonChoice]);
                        Console.WriteLine($"You selected: {addonMenuOption[addonChoice].Name}.");
                    }
                    else
                    {
                        BurritoChoices.Add(addonMenuOption[addonChoice]);
                        Console.WriteLine($"You selected: {addonMenuOption[addonChoice].Name}.");
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