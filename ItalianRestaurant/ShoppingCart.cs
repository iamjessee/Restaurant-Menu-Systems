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
        private OrderManager _orderManager;

        public ShoppingCart(OrderManager orderManager)
        {
            _menuOptions = new List<MenuOptions>();
            _helper = new Helper();
            _orderManager = orderManager;
        }

        //checks if shopping cart is empty
        public bool IsEmpty()
        {
            return _menuOptions.Count == 0;
        }

        // prompts user to edit or clear shopping cart, also lets user choose to go back to menu
        public void EditShoppingCart()
        {
            bool continueEditing = true;
            while (continueEditing && _helper.GetYetNoResponce("\nWould you like to edit your cart?"))
            {
                if (_menuOptions.Count == 0)
                {
                    Console.WriteLine("Your shopping cart is empty.");
                    continueEditing = false;
                    return;
                }

                Console.WriteLine($"\nSubtotal: {CalculateSubTotal():c}");

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
                            continueEditing = false;
                        }
                        break;
                    case 3:
                        continueEditing = false;
                        _orderManager.StartOrderProcess();
                        break;
                }
            }
        }

        // add selected menu option item to shopping cart
        public void AddSelectedMenuOption(MenuOptions menuOptions)
        {
            _menuOptions.Add(menuOptions);
        }

        // removes item selected from cart
        public void RemoveSelectedMenuOption()
        {
            Console.WriteLine("Please select what you would like to edit: \n");
            _helper.DisplayOptionsWithNumbers(_menuOptions);
            int selection = _helper.GetIntegerInput("Enter the number of the item you want to remove: ", 1, _menuOptions.Count) - 1;
            Console.WriteLine($"Removed {_menuOptions[selection].ItemName} from the cart.");
            _menuOptions.RemoveAt(selection);
        }

        // clears whole shopping cart
        public void ClearShoppingCart()
        {
            _menuOptions.Clear();
        }

        // displays items in cart
        public void DisplayShoppingCart()
        {
            _helper.DisplayOptions(_menuOptions);
        }

        // calculates subtotal of items in cart
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