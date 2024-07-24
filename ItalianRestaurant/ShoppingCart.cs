using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItalianRestaurant
{
    public class ShoppingCart
    {
        private List<MenuOptions> _menuOptions;
        private Helper _helper;

        public ShoppingCart()
        {
            _menuOptions = new List<MenuOptions>();
            _helper = new Helper();
        }

        public void EditShoppingCart()
        {
            while (_helper.GetYetNoResponce("Would you like to edit your cart?"))
            {
                if (_menuOptions.Count == 0)
                {
                    Console.WriteLine("Your shopping cart is empty.");
                    return;
                }

                Console.WriteLine("Current Shopping Cart:");
                DisplayShoppingCart();

                MenuOptions[] cartOptions =
                {

                new MenuOptions { ItemName = "Remove an item"},
                new MenuOptions { ItemName = "Clear entire cart" },
                new MenuOptions { ItemName = "Return to menu" }

                };

                _helper.DisplayOptions("Edit Options:", cartOptions);
                int choice = _helper.GetIntegerInput("Enter your choice: ", 1, cartOptions.Length);

                switch (choice)
                {
                    case 1:
                        RemoveSelectedMenuOption();
                        break;
                    case 2:
                        if (_helper.GetYetNoResponce("Are you sure you want to clear your entire cart?"))
                        {
                            ClearShoppingCart();
                            Console.WriteLine("Your shopping cart has been cleared.");
                        }
                        break;
                    case 3:
                        return;
                }
            }
        }

        public void AddSelectedMenuOption(MenuOptions menuOptions)
        {
            _menuOptions.Add(menuOptions);
        }

        public void RemoveSelectedMenuOption()
        {
                _helper.DisplayOptions("Please select what you would like to edit", _menuOptions);
                int selection = _helper.GetIntegerInput("Enter the number of the item you want to remove: ", 1, _menuOptions.Count) - 1;
                Console.WriteLine($"Removed {_menuOptions[selection].ItemName} from the cart.");
                _menuOptions.RemoveAt(selection);
        }

        public void ClearShoppingCart()
        {
            _menuOptions.Clear();
        }

        public void DisplayShoppingCart()
        {
            _helper.DisplayOptions("Shopping Cart:", _menuOptions);
            Console.WriteLine($"\nSubtotal: {CalculateSubTotal():c}");
        }

        public decimal CalculateSubTotal()
        {
            decimal Subtotal = 0;
            foreach (var menuOption in _menuOptions)
            {
                Subtotal += menuOption.Price;
            }
            return Subtotal;
        }
    }
}