namespace Restaurant_Menu_System_V3;

public class CustomerReceipt(OrderInputAndOptions orderChoice)
{
    // calling field from another class to get items selected by user
    private readonly OrderInputAndOptions _orderChoice = orderChoice;

    // generate order number
    public static int GenerateOrderID() => Random.Shared.Next(1, 100);

    // gets complete order selected by user and displays it in a readable itemized format for user
    public string GetOrderDescription()
    {
        string orderDescription = "";
        int itemCount = 1;

        foreach (var entreeChoices in _orderChoice.AllEntreeChoices)
        {
            orderDescription += GetEntreeDescription(entreeChoices, itemCount);
            itemCount++;
        }

        if (_orderChoice.CurrentEntreeChoices.Any())
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
            if (item.Price == 0.00m)
            {
                description += $"\n{item.ItemName.ToUpper()}";
            }
            else
            {
                description += $"\n{item.ItemName.ToUpper() + "...." + item.Price.ToString("c")}";
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

    // calculates total tax paid on total price of items selected by user
    const decimal taxRate = 0.0815m;
    public static decimal CalculateTax(decimal subTotal) => Math.Round(subTotal * taxRate, 2);

    // calculate final total price for customer based on selected items and tax rate
    public static decimal CalculateTotal(decimal subTotal, decimal tax) => subTotal + tax;

    // displays full receipt to user
    public void DisplayReceipt(OrderName orderName)
    {
        int orderId = GenerateOrderID();
        string orderDescription = GetOrderDescription();
        decimal subTotal = CalculateSubTotal();
        decimal tax = CalculateTax(subTotal);
        decimal total = CalculateTotal(subTotal, tax);

        Console.WriteLine($"\nThanks {orderName.Name}, your order is complete.");
        Console.WriteLine($"\nOrder ID: {orderId}");
        Console.WriteLine(orderDescription);
        Console.WriteLine($"\nSUBTOTAL: ${subTotal}");
        Console.WriteLine($"TAX: ${tax}");
        Console.WriteLine($"TOTAL: ${total}");
    }
}