using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class AttackCommand : Command{

        private string _enemy;
        private Inventory _inventory;

        
        public bool Execute(Player player){

            if(this.HasSecondWord()){
                player.AttackThis(SecondWord); // method still needs implementation
            }else{
                player.WarningMessage("Attack what?");
            }
            return false;
        }
        
    }

}
