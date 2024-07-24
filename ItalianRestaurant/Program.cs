// Create menu system for main dishes
// NO ADDONS
// Static menu items, user should be able to add a menu item to their cart, delete the item, and checkout

using ItalianRestaurant;

class Program
{
    static void Main()
    {
        GreetAndCollectUserName greetAndCollectUserName = new();
        ShoppingCart shoppingCart = new();
        MenuManager menuManager = new(shoppingCart);
        CheckoutManager checkoutManager = new(shoppingCart, greetAndCollectUserName);

        greetAndCollectUserName.GreetAndCollectName();

        menuManager.ChooseAppetizer();

        shoppingCart.DisplayShoppingCart();
        shoppingCart.EditShoppingCart();
        checkoutManager.DisplayReceipt();
    }
}