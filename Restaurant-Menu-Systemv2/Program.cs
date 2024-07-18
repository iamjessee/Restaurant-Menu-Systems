using Restaurant_Menu_System_V3;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        // calls class and methods for greeting user and collecting name for order
        OrderName customerName = new OrderName();
        customerName.GreetAndCollectName();

        // create an instance of OrderInputAndOptions and CustomerReceipt
        OrderInputAndOptions orderInputAndOptions = new OrderInputAndOptions();
        CustomerReceipt customerReceipt = new CustomerReceipt(orderInputAndOptions);

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
        EditOrderItem orderEditor = new EditOrderItem(orderInputAndOptions);
        orderEditor.ShowOrderOptionsToEdit();

        if (!orderInputAndOptions.CurrentEntreeChoices.Any(option => option.ItemName == "BOWL") && !orderInputAndOptions.CurrentEntreeChoices.Any(option => option.ItemName.Contains("TORTILLA")))
        {
            Console.WriteLine("Please select the tortilla you would like for your burrito.");
            orderInputAndOptions.ChooseTortilla();
        }
        orderInputAndOptions.FinalizeEntree();

        // add more entrées if the user wants to
        MenuOptionAdder menuOptionAdder = new MenuOptionAdder(orderInputAndOptions, orderEditor);
        menuOptionAdder.AddMoreEntrees();

        // displays user receipt
        customerReceipt.DisplayReceipt(customerName);
    }
}