using Restaurant_Menu_System_V3;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        // calls class and methods for greeting user and collecting name for order
        OrderName customerName = new OrderName();
        customerName.GreetAndCollectName();

        // create an instance of CustomerReceipt
        OrderInputAndOptions orderInputAndOptions = new OrderInputAndOptions();
        CustomerReceipt customerReceipt = new CustomerReceipt(orderInputAndOptions);

        // set the CustomerReceipt instance in OrderInputAndOptions
        orderInputAndOptions.SetCustomerReceipt(customerReceipt);

        // calls class and methods for creating customers order
        orderInputAndOptions.EntreeChoice();

        if (!orderInputAndOptions.BurritoChoices.Any(option => option.ItemName == "BOWL"))
        {
            orderInputAndOptions.ChooseTortilla();
        }

        orderInputAndOptions.ChooseProtein();
        orderInputAndOptions.ChooseRice();
        orderInputAndOptions.ChooseBeans();
        orderInputAndOptions.ChooseAddOns();

        // prompt user to edit their order if needed
        //EditOrderItem orderEditor = new EditOrderItem(orderInputAndOptions);
        //orderEditor.ShowOrderOptionsToEdit();

        // displays user receipt
        customerReceipt.DisplayReceipt(customerName);
    }
}