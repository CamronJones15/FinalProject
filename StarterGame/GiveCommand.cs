using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class GiveCommand : Command
    {

        //give command that the player uses to give ghosts an item
        public GiveCommand() : base()
        {
            this.Name = "give";
        }

        override
        public bool Execute(Player player)
        {
            if (HasSecondWord())
            {
                player.GiveGhost(this.SecondWord);
            }
            else
            {
                player.WarningMessage("Give what to the ghost?");
            }
            return false;
        }
    }
}
