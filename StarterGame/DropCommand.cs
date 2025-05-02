using System;
using System.Collections.Generic;

namespace StarterGame{

    public class DropCommand : Command {

        
        //command that allows the player to drop an item from their inventory onto the room floor
        public DropCommand () : base(){

            this.Name = "drop"; 
        }
        override
        public bool Execute(Player player){
            if(this.HasSecondWord()){
                player.Drop(this.SecondWord);
            }
            else{
                player.WarningMessage("\nDrop what?");
            }
            return false;
        }
    }

    

}