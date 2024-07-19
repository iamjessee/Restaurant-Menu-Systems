﻿using Restaurant_Menu_System_V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu_System_V3;

public class EditOrderItem
{
    // private field to store the order choices, allowing for edits to the current order
    private OrderInputAndOptions _orderChoice;

    public EditOrderItem(OrderInputAndOptions orderchoice)
    {
        _orderChoice = orderchoice;
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
        // to do - user is prompted to edit their tortilla choice even if they have selected a bowl and can add a tortilla to order.
        // need to resolve this issue at some point after building out rest of application.
        // need to add ability to completely remove entree and choices from list if user changes their mind.
        Action[] orderOptions =
        {
           _orderChoice.ChooseEntree,
           _orderChoice.ChooseTortilla,
           _orderChoice.ChooseProtein,
           _orderChoice.ChooseRice,
           _orderChoice.ChooseBeans,
           _orderChoice.ChooseAddOns
        };

        MenuOption[] options =
        {
            new MenuOption() { ItemName = "Edit Entrée Choice" },
            new MenuOption() { ItemName = "Edit Tortilla Choice" },
            new MenuOption() { ItemName = "Edit Protein Choice" },
            new MenuOption() { ItemName = "Edit Rice Choice" },
            new MenuOption() { ItemName = "Edit Bean Choice" },
            new MenuOption() { ItemName = "Edit Add-On Choices" },
        };

        _orderChoice.DisplayOrderOptions("CHOOSE WHICH MENU ITEM YOU WOULD LIKE TO EDIT:", options);

        while (true)
        {
            int choice = _orderChoice.GetIntegerInput("Enter the number for what you would like to edit. ", 1, orderOptions.Length) - 1;

            // Clear previous selection based on the choice
            switch (choice)
            {
                case 0:
                    _orderChoice.ClearEntreeChoice();
                    _orderChoice.ClearTortillaChoice();
                    break;

                case 1:
                    _orderChoice.ClearTortillaChoice();
                    break;

                case 2:
                    _orderChoice.ClearProteinChoice();
                    break;

                case 3:
                    _orderChoice.ClearRiceChoice();
                    break;

                case 4:
                    _orderChoice.ClearBeanChoice();
                    break;

                case 5:
                    _orderChoice.ClearAddonChoices();
                    break;
            }

                orderOptions[choice]();

            if (!_orderChoice.GetYesNoResponse("Would you like to make another edit?"))
            {
                break;
            }
        }
    }
}