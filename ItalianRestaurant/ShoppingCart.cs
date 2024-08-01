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

        /// <summary>
        ///  initializes a new instance of the <see cref='ShoppingCart'/> class
        /// </summary>
        /// <param name="orderManager"></param>
        public ShoppingCart(OrderManager orderManager)
        {
            _menuOptions = new List<MenuOptions>();
            _helper = new Helper();
            _orderManager = orderManager;
        }

        /// <summary>
        /// checks if shopping cart is empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _menuOptions.Count == 0;
        }

        /// <summary>
        /// prompts user to edit or clear shopping cart, also lets user choose to go back to menu
        /// </summary>
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
                int choice = _helper.GetIntegerInput("Enter your choice: ", cartOptions.Length);

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

        /// <summary>
        /// add selected menu option item to shopping cart
        /// </summary>
        /// <param name="menuOptions">option selected by user</param>
        public void AddSelectedMenuOption(MenuOptions menuOptions)
        {
            _menuOptions.Add(menuOptions);
        }

        /// <summary>
        /// removes item selected from cart
        /// </summary>
        public void RemoveSelectedMenuOption()
        {
            Console.WriteLine("Please select what you would like to edit: \n");
            _helper.DisplayOptionsWithNumbers(_menuOptions);
            int selection = _helper.GetIntegerInput("Enter the number of the item you want to remove: ", _menuOptions.Count) - 1;
            Console.WriteLine($"Removed {_menuOptions[selection].ItemName} from the cart.");
            _menuOptions.RemoveAt(selection);
        }

        /// <summary>
        /// clears whole shopping cart
        /// </summary>
        public void ClearShoppingCart()
        {
            _menuOptions.Clear();
        }

        /// <summary>
        /// displays items in cart
        /// </summary>
        public void DisplayShoppingCart()
        {
            _helper.DisplayOptions(_menuOptions);
        }

        /// <summary>
        /// calculates subtotal of items in cart
        /// </summary>
        /// <returns></returns>
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