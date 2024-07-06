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
            string burrito = "";
            foreach (MenuOption item in _orderChoice.BurritoChoices)
            {
                burrito += $"\n{item.Name}";
            }
            return burrito;
        }

        // adds together total tax and cost of selected items to show user their total cost
        public decimal CalculateSubTotal()
        {
            decimal subTotal = 0.00m;

            foreach (MenuOption item in _orderChoice.BurritoChoices)
            {
                subTotal += item.Price;
            }

            return Math.Round(subTotal, 2);
        }

        // calculates total tax paid on total cost of items selected by user
        public decimal CalculateTax(decimal subTotal)
        {
            decimal taxRate = 0.085m;
            return Math.Round(subTotal * taxRate, 2);
        }

        public decimal CalculateTotal(decimal subTotal, decimal tax)
        {
            return subTotal + tax;
        }

        // displays full receipt to user
        public void DisplayReceipt(OrderName ordername)
        {
            int orderId = GenerateOrderID();
            string orderDescription = GetOrderDescription();
            decimal subTotal = CalculateSubTotal();
            decimal tax = CalculateTax(subTotal);
            decimal total = CalculateTotal(subTotal, tax);

            Console.WriteLine($"\nThanks {ordername.Name}, your order is complete.");
            Console.WriteLine($"\nOrder ID: {orderId}");
            Console.WriteLine(orderDescription);
            Console.WriteLine($"\nSUBTOTAL: ${subTotal}");
            Console.WriteLine($"TAX: ${tax}");
            Console.WriteLine($"TOTAL: ${total}");
        }
    }
}