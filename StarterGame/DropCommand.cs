using System;
using System.Collections.Generic;

namespace StarterGame{

    public class DropCommand : Command {

        

        public DropCommand () : base(){

            this.Name = "Drop"; 
        }
        override
        public bool Execute(Player player){
            IItem item = player.CurrentRoom._floor.Remove(SecondWord);
            player._inventory.Insert(item);
            if(this.HasSecondWord()){
                player.DropItem(this.SecondWord);
            }
            else{
                player.WarningMessage("\nDrop what?");
            }
            return false;
        }
    }

    

}