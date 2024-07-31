// Create menu system for main dishes
// NO ADDONS
// Static menu items, user should be able to add a menu item to their cart, delete the item, and checkout

using ItalianRestaurant;
class Program
{
    static void Main()
    {
        GreetAndCollectUserName greetAndCollectUserName = new();
        OrderManager orderManager = new(greetAndCollectUserName);
        greetAndCollectUserName.GreetAndCollectName();
        orderManager.StartOrderProcess();
    }
}