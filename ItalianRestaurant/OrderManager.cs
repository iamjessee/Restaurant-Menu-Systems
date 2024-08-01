using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItalianRestaurant
{
    public class OrderManager
    {
        private Helper _helper;
        private GreetAndCollectUserName _greetAndCollectUserName;
        private ShoppingCart _shoppingCart;
        private MenuManager _menuManager;
        private CheckoutManager _checkoutManager;

        /// <summary>
        /// initializes a new instance of the  <see cref="OrderManager"/>  class.
        /// </summary>
        /// <param name="greetAndCollectUserName">the instance used for greeting and collecting the username</param>
        public OrderManager(GreetAndCollectUserName greetAndCollectUserName)
        {
            // initialize helper class
            _helper = new Helper();

            // set the greeting and name collection instance
            _greetAndCollectUserName = greetAndCollectUserName;

            // initialize shopping cart with a reference to this OrderManager
            _shoppingCart = new ShoppingCart(this);

            // initialize MenuManager with the shopping cart
            _menuManager = new MenuManager(_shoppingCart);

            // initialize checkout manager with shopping cart and username collector
            _checkoutManager = new CheckoutManager(_shoppingCart, _greetAndCollectUserName);
        }

        /// <summary>
        /// method to handle the whole order end editing process
        /// </summary>
        public void StartOrderProcess()
        {
            bool continueOrdering = true;
            while (continueOrdering)
            {
                _menuManager.ChooseAppetizer();
                _menuManager.ChooseEntree();
                Console.WriteLine("\nCURRENT SHOPPING CART: ");
                _shoppingCart.DisplayShoppingCart();
                Console.WriteLine($"\nSubtotal: {_shoppingCart.CalculateSubTotal():c}");
                _shoppingCart.EditShoppingCart();

                if (_shoppingCart.IsEmpty())
                {
                    Console.WriteLine("Your shopping cart is empty. Would you like to restart the order process? (Y/N)");
                    if (!_helper.GetYetNoResponce("Would you like to restart the order process?"))
                    {
                        continueOrdering = false;
                    }
                }
                else
                {
                    _checkoutManager.DisplayReceipt();
                    continueOrdering = false;
                }
            }
        }
    }
}
