﻿namespace Restaurant_Menu_System_V3;

public static class Program
{
    private static void Main()
    {
        // calls class and methods for greeting user and collecting name for order
        UserName.GreetAndCollectName();

        // create an instance of OrderInputAndOptions and CustomerReceipt
        OrderInputAndOptions orderInputAndOptions = new();
        CustomerReceipt customerReceipt = new(orderInputAndOptions);

        // set the CustomerReceipt instance in OrderInputAndOptions
        orderInputAndOptions.SetCustomerReceipt(customerReceipt);

        // calls class and methods for creating customers order
        orderInputAndOptions.ChooseEntree();

        // if bowl is not selected, prompt user to choose a tortilla
        if (!orderInputAndOptions.CurrentEntreeChoices.Any(option => option.ItemName == "BOWL"))
        {
            orderInputAndOptions.ChooseTortilla();
        }

        orderInputAndOptions.ChooseProtein();
        orderInputAndOptions.ChooseRice();
        orderInputAndOptions.ChooseBeans();
        orderInputAndOptions.ChooseAddOns();

        // prompt user to edit their order if needed and skips tortilla option if bowl is selected
        EditOrderItem orderEditor = new(orderInputAndOptions);
        orderEditor.ShowOrderOptionsToEdit();

        if (!orderInputAndOptions.CurrentEntreeChoices.Any(option => option.ItemName == "BOWL") && !orderInputAndOptions.CurrentEntreeChoices.Any(option => option.ItemName.Contains("TORTILLA")))
        {
            Console.WriteLine("Please select the tortilla you would like for your burrito.");
            orderInputAndOptions.ChooseTortilla();
        }
        orderInputAndOptions.FinalizeEntree();

        // add more entrées if the user wants to
        MenuOptionAdder menuOptionAdder = new(orderInputAndOptions, orderEditor);
        menuOptionAdder.AddMoreEntrees();

        // displays user receipt
        customerReceipt.DisplayReceipt();
    }
}