namespace Restaurant_Menu_System_V3.Model;

public class MenuOption
{
    // public fields to get and set name of items for user to select and price for those items if any
    public string ItemName { get; set; } = string.Empty;

    public decimal Price { get; set; }
}