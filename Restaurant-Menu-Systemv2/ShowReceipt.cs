namespace Restaurant_Menu_System_V3;

public class CustomerReceipt(OrderInputAndOptions orderChoice)
{
    // calling field from another class to get items selected by user
    private readonly OrderInputAndOptions _orderChoice = orderChoice;

    // generate order number
    public int GenerateOrderID() => Random.Shared.Next(1, 100);

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
    public string GetEntreeDescription(List<MenuOption> entreeChoices, int itemCount)
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
    public decimal CalculateTax(decimal subTotal)
    {
        decimal taxRate = 0.0815m;
        return Math.Round(subTotal * taxRate, 2);
    }

    // calculate final total price for customer based on selected items and tax rate
    public decimal CalculateTotal(decimal subTotal, decimal tax)
    {
        return subTotal + tax;
    }

    // displays full receipt to user
    public void DisplayReceipt(OrderName ordername)
    {
        int orderId = GenerateOrderID();
        string orderDescription = GetOrderDescription();
        decimal subTotal = CalculateSubTotal();
        decimal tax = CalculateTax(subTotal);
        decimal total = CalculateTotal(subTotal, tax);

        Console.WriteLine($"\nThanks {ordername.Name}, your order is complete.");
        Console.WriteLine($"\nOrder ID: {orderId}");
        Console.WriteLine(orderDescription);
        Console.WriteLine($"\nSUBTOTAL: ${subTotal}");
        Console.WriteLine($"TAX: ${tax}");
        Console.WriteLine($"TOTAL: ${total}");
    }
}