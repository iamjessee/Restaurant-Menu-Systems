// Create menu system for main dishes
// NO ADDONS
// Static menu items, user should be able to add a menu item to their cart, delete the item, and checkout

using ItalianRestaurant;
class Program
{
    static void Main()
    {
        // create an instance to greet user
        GreetAndCollectUserName greetAndCollectUserName = new();

        //create an instance of OrderManager with the instance of GreetAndCollectUserName
        OrderManager orderManager = new(greetAndCollectUserName);

        // greet and collect the username for the order
        greetAndCollectUserName.GreetAndCollectName();

        // start the order process
        orderManager.StartOrderProcess();
    }
}