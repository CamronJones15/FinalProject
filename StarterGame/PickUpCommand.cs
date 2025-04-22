using System;
using System.Collections.Generic;

namespace StarterGame{

    public class PickUpCommand : Command {

        

        public PickUpCommand () : base(){

            this.Name = "pickup"; 
        }

        public void Execute(Player player){
            if(this.HasSecondWord()){
                player.PickUpItem(this.SecondWord);
            }
            else{
                player.WarningMessage("\nPickup what?");
            }
            return false;
        }
    }

    

}