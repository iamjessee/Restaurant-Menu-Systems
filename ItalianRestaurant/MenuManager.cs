namespace ItalianRestaurant
{
    public class MenuManager
    {
        private Helper _helper;
        private ShoppingCart _shoppingCart;

        /// <summary>
        /// initializes a new instance of the <see cref="MenuManager"/> class.
        /// </summary>
        /// <param name="shoppingCart">the shopping cart to store selected menu options.</param>
        public MenuManager(ShoppingCart shoppingCart)
        {
            _helper = new Helper();
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// prompts the user to choose an appetizer
        /// </summary>
        public void ChooseAppetizer()
        {
            MenuOptions[] appetizerOptions =
            {
                new MenuOptions { ItemName = "Arancini", Price = 1.99m },
                new MenuOptions { ItemName = "Charcuterie board", Price = 9.99m },
                new MenuOptions { ItemName = "Meatballs in Black Truffle Sauce", Price = 9.99m },
                new MenuOptions { ItemName = "Mozzarella in Carrozza", Price = 13.99m },
                new MenuOptions { ItemName = "No Appetizer", Price = 0.00m }
            };

            _helper.DisplayOptions("APPETIZER:", appetizerOptions);

            int appetizerChoice = _helper.GetIntegerInput("Please choose your appetizer: ", 5) - 1;
            Console.WriteLine($"You selected {appetizerOptions[appetizerChoice].ItemName} for {appetizerOptions[appetizerChoice].Price:c}.");
            _shoppingCart.AddSelectedMenuOption(appetizerOptions[appetizerChoice]);
        }

        /// <summary>
        /// prompts user to choose entree choice
        /// </summary>
        public void ChooseEntree()
        {
            MenuOptions[] entreeOptions =
            {
                new MenuOptions { ItemName = "Bolognese Meat Sauce", Price = 11.99m },
                new MenuOptions { ItemName = "Spaghetti alla Puttanesca", Price = 11.99m },
                new MenuOptions { ItemName = "Lasagna", Price = 12.99m },
                new MenuOptions { ItemName = "Trofie Al Pesto", Price = 13.99m },
                new MenuOptions { ItemName = "No Entree", Price = 0.00m }
            };

            _helper.DisplayOptions("APPETIZER:", entreeOptions);

            int appetizerChoice = _helper.GetIntegerInput("Please choose your appetizer: ", 5) - 1;
            Console.WriteLine($"You selected {entreeOptions[appetizerChoice].ItemName} for {entreeOptions[appetizerChoice].Price:c}.");
            _shoppingCart.AddSelectedMenuOption(entreeOptions[appetizerChoice]);
        }
    }
}