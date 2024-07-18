namespace Restaurant_Menu_System_V3;

public class MenuOptionAdder(OrderInputAndOptions orderChoice, EditOrderItem editOrderItem)
{
    // private field to store the order choices, allowing for adding more items to current order
    private readonly OrderInputAndOptions _orderChoice = orderChoice;

    // private field allow for edits to the current order
    private readonly EditOrderItem _editOrderItem = editOrderItem;

    // prompts user to add more entrées to their order
    public void AddMoreEntrees()
    {
        while (OrderInputAndOptions.GetYesNoResponse("Would you like to add another item to your order?"))
        {
            _orderChoice.StartNewBurrito();

            _orderChoice.ChooseEntree();
            if (!_orderChoice.CurrentEntreeChoices.Any(option => option.ItemName == "BOWL"))
            {
                _orderChoice.ChooseTortilla();
            }
            _orderChoice.ChooseProtein();
            _orderChoice.ChooseRice();
            _orderChoice.ChooseBeans();
            _orderChoice.ChooseAddOns();

            _editOrderItem.ShowOrderOptionsToEdit();

            _orderChoice.FinalizeEntree();
        }
    }
}