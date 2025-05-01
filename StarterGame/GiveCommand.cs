using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class GiveCommand : Command
    {
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
