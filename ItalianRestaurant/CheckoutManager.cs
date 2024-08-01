using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ItalianRestaurant
{
    public class CheckoutManager
    {
        private Random _rnd = new Random();
        private GreetAndCollectUserName _greetAndCollectUserName;
        private MenuManager _menuManager;
        private ShoppingCart _shoppingCart;
        private Helper _helper;

        /// <summary>
        /// initializes a new instance of the <see cref="CheckoutManager"/> class.
        /// </summary>
        /// <param name="shoppingCart">the shopping cart containing selected menu items.</param>
        /// <param name="greetAndCollectUserName">the instance used for greeting and collecting the username.</param>
        public CheckoutManager(ShoppingCart shoppingCart, GreetAndCollectUserName greetAndCollectUserName)
        {
            _shoppingCart = shoppingCart;
            _helper = new Helper();
            _greetAndCollectUserName = greetAndCollectUserName;
        }

        /// <summary>
        /// generate order number
        /// </summary>
        /// <returns>a randomly generated order ID</returns>
        public int GenerateOrderID()
        {
            return _rnd.Next(1, 100);
        }

        /// <summary>
        /// calculates total tax paid on total price of items selected by user
        /// </summary>
        /// <param name="subTotal">the subtotal of the selected items</param>
        /// <returns>the calculated tax amount</returns>
        public decimal CalculateTax(decimal subTotal)
        {
            decimal taxRate = 0.0815m;
            return Math.Round(subTotal * taxRate, 2);
        }

        /// <summary>
        /// calculates the final total price for the customer based on the subtotal and tax.
        /// </summary>
        /// <param name="subTotal">the subtotal of the selected items.</param>
        /// <param name="tax">the calculated tax amount.</param>
        /// <returns>the final total price.</returns>
        public decimal CalculateTotal(decimal subTotal, decimal tax)
        {
            return subTotal + tax;
        }

        /// <summary>
        /// displays itemized receipt for user 
        /// </summary>
        public void DisplayReceipt()
        {
            int orderId = GenerateOrderID();
            decimal subTotal = _shoppingCart.CalculateSubTotal();
            decimal tax = CalculateTax(subTotal);
            decimal total = CalculateTotal(subTotal, tax);

            Console.WriteLine($"\nThanks {_greetAndCollectUserName.UserName}, your order is complete.");
            Console.WriteLine($"\nOrder ID: {orderId}\n");
            _shoppingCart.DisplayShoppingCart();
            Console.WriteLine($"\nSUBTOTAL: ${subTotal}");
            Console.WriteLine($"TAX: ${tax}");
            Console.WriteLine($"TOTAL: ${total}");
        }
    }
}
