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

        public CheckoutManager(ShoppingCart shoppingCart, GreetAndCollectUserName greetAndCollectUserName)
        {
            _shoppingCart = shoppingCart;
            _helper = new Helper();
            _greetAndCollectUserName = greetAndCollectUserName;
        }

        // generate order number
        public int GenerateOrderID()
        {
            return _rnd.Next(1, 100);
        }

        // calculates total tax paid on total price of items selected by user
        public decimal CalculateTax(decimal subTotal)
        {
            decimal taxRate = 0.0815m;
            return Math.Round(subTotal * taxRate, 2);
        }

        // calculate final total price for customer based on selected items and tax rate
        public decimal CalculateTotal(decimal subTotal, decimal tax)
        {
            return subTotal + tax;
        }
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
