using System;
using System.Collections.Generic;

namespace StarterGame{

    public class DropCommand : Command {

        

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