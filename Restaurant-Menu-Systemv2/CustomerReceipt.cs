using Restaurant_Menu_System_V3.Model;

namespace Restaurant_Menu_System_V3;

public class CustomerReceipt(OrderInputAndOptions orderChoice)
{
    // calling field from another class to get items selected by user
    private readonly OrderInputAndOptions _orderChoice = orderChoice;

    // gets complete order selected by user and displays it in a readable itemized format for user
    public string GetOrderDescription()
    {
        string orderDescription = "";
        int itemCount = 1;

        foreach (var entreeChoices in _orderChoice.AllEntreeChoices)
        {
            orderDescription += GetEntreeDescription(entreeChoices, itemCount++);
        }

        if (_orderChoice.CurrentEntreeChoices.Count != 0)
        {
            orderDescription += GetEntreeDescription(_orderChoice.CurrentEntreeChoices, itemCount);
        }
        return orderDescription;
    }

    //creates a readable description for a list of entrée choices
    public static string GetEntreeDescription(List<MenuOption> entreeChoices, int itemCount)
    {
        string description = $"\n--- Entrée {itemCount} ---";
        foreach (MenuOption item in entreeChoices)
        {
            description += $"\n{item.ItemName.ToUpper()}";
            if (item.Price != 0.00m)
            {
                description += "...." + item.Price.ToString("c");
            }
        }
        return description;
    }

    // adds together total tax and price of selected items to show user their total price
    public decimal CalculateSubTotal()
    {
        decimal subTotal = 0.00m;

        // calculate total for all completed entrées
        foreach (var entreeChoices in _orderChoice.AllEntreeChoices)
        {
            subTotal += entreeChoices.Sum(item => item.Price);
        }

        // add total for the current entrée being built
        subTotal += _orderChoice.CurrentEntreeChoices.Sum(item => item.Price);

        return Math.Round(subTotal, 2);
    }

    // displays full receipt to user
    public void DisplayReceipt(CollectUserName orderName)
    {
        int orderId = GenerateOrderID();
        string orderDescription = GetOrderDescription();
        decimal subTotal = CalculateSubTotal();
        decimal tax = CalculateTax(subTotal);
        decimal total = CalculateTotal(subTotal, tax);

        WriteLine($"\nThanks {orderName.Name}, your order is complete.");
        WriteLine($"\nOrder ID: {orderId}");
        WriteLine(orderDescription);
        WriteLine($"\nSUBTOTAL: ${subTotal}");
        WriteLine($"TAX: ${tax}");
        WriteLine($"TOTAL: ${total}");
    }
}