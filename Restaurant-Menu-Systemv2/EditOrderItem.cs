using Restaurant_Menu_System_V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu_Systemv3
{
    public class EditOrderItem
    {
        private OrderInputAndOptions orderChoice;
        private CustomerReceipt customerReceipt;

        public EditOrderItem(OrderInputAndOptions orderchoice)
        {
            this.orderChoice = orderchoice;
        }
        public void ClearChoices()
        {
            orderChoice.BurritoChoices.Clear();
            orderChoice.AddonChoices.Clear();
            orderChoice.Cost = 0;
        }
        // prompts user to ask if they would like to edit their order
        // displays options for user to edit and takes them back to their spot in the menu
        public void ShowOrderOptionsToEdit()
        {
            if (!orderChoice.AskYesNoQuestion("Would you like to edit your order?"))
            {
                Console.WriteLine("No changes made to the order.");
                return;
            }

            Action[] orderOptions = { orderChoice.ChooseTortilla, orderChoice.ChooseProtein, orderChoice.ChooseRice, orderChoice.ChooseBeans, orderChoice.ChooseAddOns };
            string[] orderOptionNames = { "Edit Tortilla Choice","Edit Protein Choice","Edit Rice Choice","Edit Bean Choice","Edit Add-On Choices" };

            while (true)
            {
                Console.WriteLine();
                for (int i = 0; i < orderOptionNames.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {orderOptionNames[i]} ");
                }

                int choice = orderChoice.GetIntegerInput("Enter the number for what you would like to edit. ", 1, orderOptions.Length) - 1;

                // need to find a way to clear items from list that user is editing to add in the newly selected items
                //if (choice == 0)
                //{
                //    orderChoice.BurritoChoices.Clear();
                //}
                //else if (choice == 4)
                //{
                //    orderChoice.AddonChoices.Clear();
                //}
                //else
                //{
                //    orderChoice.BurritoChoices.RemoveAt(choice);
                //}
                orderOptions[choice]();

                if (!orderChoice.AskYesNoQuestion("Would you like to make another edit?"))
                {
                    break;
                }
            }
        }
    }
}