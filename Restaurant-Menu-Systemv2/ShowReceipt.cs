using Restaurant_Menu_System_V3;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu_System_V3
{
    public class CustomerReceipt
    {
        // calling field from another class to get items selected by user
        private OrderInputAndOptions _orderChoice;
        private Random _rnd = new Random();

        // Constructor to initialize the orderChoice instance
        public CustomerReceipt(OrderInputAndOptions orderchoice)
        {
            this._orderChoice = orderchoice;
        }

        // generate order number
        public int GenerateOrderID()
        {
            return _rnd.Next(1, 100);
        }
        // gets complete order selected by user and displays it in a readable itemized format for user
        public string GetOrderDescription()
        {
            string burrito = string.Join("\n", _orderChoice.BurritoChoices);
            string addons = string.Join("\n", _orderChoice.AddonChoices);
            return $"\n{burrito}\n{addons}";
        }

        // calculates total tax paid on total cost of items selected by user
        public decimal CalculateTax()
        {
            decimal taxRate = 0.085m;
            return Math.Round(_orderChoice.Cost * taxRate, 2);
        }
 
        // adds together total tax and cost of selected items to show user their total cost
        public decimal CalculateTotal()
        {
            return Math.Round(_orderChoice.Cost + CalculateTax(), 2);
        }

        // displays full receipt to user
        public void DisplayReceipt(OrderName ordername)
        {
            int orderId = GenerateOrderID();
            string orderDescription = GetOrderDescription();
            decimal tax = CalculateTax();
            decimal total = CalculateTotal();

            Console.WriteLine($"\nThanks {ordername.Name}, your order is complete.");
            Console.WriteLine($"\nOrder ID: {orderId}");
            Console.WriteLine(orderDescription);
            Console.WriteLine($"\nSUBTOTAL: ${Math.Round(_orderChoice.Cost, 2)}");
            Console.WriteLine($"TAX: ${tax}");
            Console.WriteLine($"TOTAL: ${total}");
        }
    }
}