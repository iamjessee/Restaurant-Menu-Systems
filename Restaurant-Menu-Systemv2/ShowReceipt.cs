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
        private OrderInputAndOptions ordereditems;

        // Constructor to initialize the ordereditems instance
        public CustomerReceipt(OrderInputAndOptions orderchoice)
        {
            this.ordereditems = orderchoice;
        }

        // gets complete order selected by user and displays it in a readable itemized format for user
        public string GetOrderDescrption()
        {
            string burrito = string.Join("\n", ordereditems.BurritoChoices);
            string addons = string.Join("\n", ordereditems.AddonChoices);

            return $"\n{burrito}\n{addons}";
        }

        // calculates total tax paid on total cost of items selected by user
        public decimal GetAmount()
        {
            decimal taxRate = 0.085m;

            return Math.Round(ordereditems.Cost * taxRate, 2);
        }
 
        // adds together total tax and cost of selected items to show user their total cost
        public decimal GetTotal()
        {
            return Math.Round(ordereditems.Cost += GetAmount(), 2);
        }

        // displays full receipt to user
        public void GetReceiptDisplay(OrderName ordername)
        {
            Console.WriteLine($"\nThanks {ordername.Name}, your order is complete. \n{GetOrderDescrption()}");
            Console.WriteLine($"\nSUBTOTAL: ${Math.Round(ordereditems.Cost, 2)}");
            Console.WriteLine($"TAX: ${GetAmount()}");
            Console.WriteLine($"TOTAL: ${GetTotal()}");
        }
    }
}