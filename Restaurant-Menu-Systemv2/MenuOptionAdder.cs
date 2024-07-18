namespace Restaurant_Menu_System_V3
{
    public class MenuOptionAdder
    {
        // private field to store the order choices, allowing for adding more items to current order
        private OrderInputAndOptions _orderChoice;

        // private field allow for edits to the current order
        private EditOrderItem _editOrderItem;

        // constructor to initialize the order choice and edit order item
        public MenuOptionAdder(OrderInputAndOptions orderchoice, EditOrderItem editOrderItem)
        {
            _orderChoice = orderchoice;
            _editOrderItem = editOrderItem;
        }

        // prompts user to add more entrées to their order
        public void AddMoreEntrees()
        {
            while (_orderChoice.GetYesNoResponse("Would you like to add another item to your order?"))
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
}