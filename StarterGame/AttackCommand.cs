using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class AttackCommand : Command{

        private string _enemy;
        private Inventory _inventory;

        
        public bool Execute(Player player){

            if (this.HasSecondWord() && this.HasThirdWord()) {
                player.AttackThis(SecondWord, ThirdWord);
            }
            else if(this.HasSecondWord())
            {
                player.WarningMessage("Attack " + SecondWord + " with what?");
            }
            else{
                player.WarningMessage("Attack what?");
            }
            return false;
        }
        
    }

}
