using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Menu_System_V3
{
    public class MenuOption
    {
        // public fields to get and set name of items for user to select and price for those items if any
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}