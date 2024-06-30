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

        // prompts user to ask if they would like to edit their order
        public bool PromptUserToEditOrder()
        {
            do
            {
                Console.WriteLine("Would you like to edit your order? (Y/N)");
                string userResponse = Console.ReadLine().ToUpper();

                if (userResponse == "Y")
                {
                    return true;
                }
                else if (userResponse == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter Y/N to continue.");
                    userResponse = Console.ReadLine().ToUpper();
                }
            } while(true);
      }
        // displays options for user to edit and takes them back to their spot in the menu
        public void ShowOrderOptionsToEdit()
        {
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

                orderOptions[choice]();

                //need to find a way to clear list of previous choices and cost based on edit choice by user
                //if (ordereditems.BurritoChoices.Contains(choice))

                Console.WriteLine("Would you like to make another edit?");
                string userResponse = Console.ReadLine().ToUpper();

                if (userResponse != "Y") 
                {
                    break;
                }
            }
        }
    }
}