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
            _orderChoice = orderchoice;
        }

        // generate order number
        public int GenerateOrderID()
        {
            return _rnd.Next(1, 100);
        }

        // gets complete order selected by user and displays it in a readable itemized format for user
        public string GetOrderDescription()
        {
            string orderDescription = "";
            int itemCount = 1;

            foreach (var entreeChoices in _orderChoice.AllEntreeChoices)
            {
                orderDescription += GetEntreeDescription(entreeChoices, itemCount);
                itemCount++;
            }

            if (_orderChoice.CurrentEntreeChoices.Any())
            {
                orderDescription += GetEntreeDescription(_orderChoice.CurrentEntreeChoices, itemCount);
            }
            return orderDescription;
        }
        public string GetEntreeDescription(List<MenuOption> entreeChoices, int itemCount)
        {
            string description = $"\n--- Entrée {itemCount} ---";
            foreach (MenuOption item in entreeChoices)
            {
                if (item.Price == 0.00m)
                {
                    description += $"\n{item.ItemName.ToUpper()}";
                }
                else
                {
                    description += $"\n{item.ItemName.ToUpper() + "...." + item.Price.ToString("c")}";
                }
            }
            return description;
        }
        // adds together total tax and price of selected items to show user their total price
        public decimal CalculateSubTotal()
        {
            decimal subTotal = 0.00m;

            // calculate total for all completed burritos
            foreach (var burritoChoices in _orderChoice.AllEntreeChoices)
            {
                subTotal += burritoChoices.Sum(item => item.Price);
            }

            // add total for the current burrito being built
            subTotal += _orderChoice.CurrentEntreeChoices.Sum(item => item.Price);

            return Math.Round(subTotal, 2);
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