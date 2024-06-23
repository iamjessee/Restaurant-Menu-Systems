using Restaurant_Menu_System_V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu_System_V3
{
    public class CustomerReceipt
    {
        // calling field from another class to get items selected by user
        private OrderInputAndOptions ordereditems;

        // Constructor to initialize the orderedItems instance
        public CustomerReceipt(OrderInputAndOptions orderchoice)
        {
            this.ordereditems = orderchoice;
        }

        public string GetOrderDescrption()
        {
            string burrito = string.Join("\n", ordereditems.burritoChoices);
            string addons = string.Join("\n", ordereditems.addonChoices);

            return $"\n{burrito}\n{addons}";
        }
        public void GetReceiptDisplay(OrderName ordername)
        {
            

            Console.WriteLine($"THANKS {ordername.Name}, YOUR ORDER IS COMPLETE \n{GetOrderDescrption()}");
            Console.WriteLine($"\nSUBTOTAL: ${Math.Round(ordereditems.Cost, 2)}");
            //Console.WriteLine($"TAX: ${ordereditems.tax.ToString("0.00")}");
            //Console.WriteLine($"TOTAL: ${ordereditems.total.ToString("0.00")}");
            }
    }
}
