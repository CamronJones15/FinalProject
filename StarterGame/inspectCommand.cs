using System;
using System.Collections.Generic;

namespace StarterGame
{

    public class InspectCommand : Command{

        public InspectCommand() : base(){
            
            this.Name = "Inspect";
        }

        override
        public bool Execute(Player player){
            if (this.HasSecondWord())
            {
                player.InspectItem(SecondWord);
            }
            else
            {
                player.WarningMessage("\nInspect what?");
            }
            return false;
        }


    }
}