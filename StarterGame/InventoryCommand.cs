using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class InventoryCommand : Command
    {
        //Inventory command that displays the items within the players inventory
        public InventoryCommand() : base()
        {
            this.Name = "inventory";
        }

        override
        public bool Execute(Player player)
        {
            player.Inventory();
            return false;
        }
    }
}
