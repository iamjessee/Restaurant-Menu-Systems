using Restaurant_Menu_System_V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu_System_V3
{
    public class EditOrderItem
    {
        private OrderInputAndOptions _orderChoice;
        private CustomerReceipt _customerReceipt;

        public EditOrderItem(OrderInputAndOptions orderchoice)
        {
            this._orderChoice = orderchoice;
        }
        // Method to remove an item and adjust the cost
        public void RemoveItem(string item)
        {
            // Define the menu options and prices locally
            string[] proteinChoiceOptions = { "STEAK", "PORK", "CHORIZO", "CHICKEN" };
            decimal[] proteinChoicePrices = { 11.10m, 10.00m, 9.85m, 9.35m };

            string[] addonChoiceOptions = { "GRILLED CORN", "LETTUCE", "ONIONS", "SOUR CREAM", "POTATOES", "CHEESE", "QUESO", "GUACAMOLE" };
            decimal[] addonChoicePrices = { 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 0.00m, 1.60m, 2.65m };

            decimal price = 0.00m;

            // Check if the item is a protein choice
            int index = Array.IndexOf(proteinChoiceOptions, item);
            if (index >= 0)
            {
                price = proteinChoicePrices[index];
                _orderChoice.BurritoChoices.Remove(item);
                _orderChoice.Cost -= price;
            }
            else
            {
                // Check if the item is an add-on choice
                index = Array.IndexOf(addonChoiceOptions, item);
                if (index >= 0)
                {
                    price = addonChoicePrices[index];
                    _orderChoice.AddonChoices.Remove(item);
                    _orderChoice.Cost -= price;
                }
            }

        }

        // prompts user to ask if they would like to edit their order
        // displays options for user to edit and takes them back to their spot in the menu
        public void ShowOrderOptionsToEdit()
        {
            if (!_orderChoice.GetYesNoResponse("Would you like to edit your order?"))
            {
                Console.WriteLine("No changes made to the order.");
                return;
            }

            Action[] orderOptions = { _orderChoice.ChooseTortilla, _orderChoice.ChooseProtein, _orderChoice.ChooseRice, _orderChoice.ChooseBeans, _orderChoice.ChooseAddOns };
            string[] orderOptionNames = { "Edit Tortilla Choice","Edit Protein Choice","Edit Rice Choice","Edit Bean Choice","Edit Add-On Choices" };

            while (true)
            {
                Console.WriteLine();
                for (int i = 0; i < orderOptionNames.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {orderOptionNames[i]} ");
                }

                int choice = _orderChoice.GetIntegerInput("Enter the number for what you would like to edit. ", 1, orderOptions.Length) - 1;

                // Remove the item and its cost before allowing the user to select a new one
                if (choice < 4)
                {
                    string itemToRemove = _orderChoice.BurritoChoices[choice];
                    RemoveItem(itemToRemove);
                }
                else
                {
                    _orderChoice.AddonChoices.Clear();
                }

                orderOptions[choice]();

                if (!_orderChoice.GetYesNoResponse("Would you like to make another edit?"))
                {
                    break;
                }
            }
        }
    }
}