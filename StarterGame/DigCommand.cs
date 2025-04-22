using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class DigCommand : Command{

        public DigCommand() : base()
        {
            this.Name = "dig";
        }
        override
        public bool Execute(Player player){
            if (this.HasSecondWord())
            {
                player.Dig(this.SecondWord);
            }
            else
            {
                player.WarningMessage("\nDig what?");
            }
            return false;
        }

    }
}