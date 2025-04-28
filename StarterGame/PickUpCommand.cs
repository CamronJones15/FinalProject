using System;
using System.Collections.Generic;

namespace StarterGame{

    public class PickUpCommand : Command {

        

        public PickUpCommand () : base(){

            this.Name = "pickup"; 
        }
        override
        public bool Execute(Player player){
            if(this.HasSecondWord()){
                player.PickUp(this.SecondWord);
            }
            else{
                player.WarningMessage("\nPickup what?");
            }
            return false;
        }
    }

    

}