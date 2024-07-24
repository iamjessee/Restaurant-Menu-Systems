namespace ItalianRestaurant
{
    public class MenuManager
    {
        private Helper _helper;
        private ShoppingCart _shoppingCart;

        public MenuManager(ShoppingCart shoppingCart)
        {
            _helper = new Helper();
            _shoppingCart = shoppingCart;
        }

        // prompts user to choose appetizer choice
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

            int appetizerChoice = _helper.GetIntegerInput("Please choose your appetizer: ", 1, 5) - 1;
            Console.WriteLine($"You selected {appetizerOptions[appetizerChoice].ItemName} for {appetizerOptions[appetizerChoice].Price:c}.");
            _shoppingCart.AddSelectedMenuOption(appetizerOptions[appetizerChoice]);
        }
    }
}