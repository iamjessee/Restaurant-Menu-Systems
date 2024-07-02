using Restaurant_Menu_System_V3;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        // adds together total tax and cost of selected items to show user their total cost
        public decimal CalculateSubTotal()
        {
            decimal subTotal = 0.00m;

            for (int i = 0; i < _orderChoice.Cost.Count; i++)
            {
                subTotal += _orderChoice.Cost[i];
            }
            return subTotal;
        }

        // calculates total tax paid on total cost of items selected by user
        public decimal CalculateTax()
        {
            decimal taxRate = 0.085m;
            return Math.Round(CalculateSubTotal() * taxRate, 2);
        }

        public decimal CalculateTotal()
        {
            return Math.Round(CalculateSubTotal() + CalculateTax(), 2);
        }

        // displays full receipt to user
        public void DisplayReceipt(OrderName ordername)
        {
            int orderId = GenerateOrderID();
            string orderDescription = GetOrderDescription();
            decimal tax = CalculateTax();
            decimal subTotal = CalculateSubTotal();
            decimal total = CalculateTotal();

            Console.WriteLine($"\nThanks {ordername.Name}, your order is complete.");
            Console.WriteLine($"\nOrder ID: {orderId}");
            Console.WriteLine(orderDescription);
            Console.WriteLine($"\nSUBTOTAL: ${subTotal}");
            Console.WriteLine($"TAX: ${tax}");
            Console.WriteLine($"TOTAL: ${total}");
        }
    }
}