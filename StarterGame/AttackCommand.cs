using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class AttackCommand : Command{

        private string _enemy;

        
        public AttackCommand() : base()
        {
            
            this.Name = "attack";
        }
        override
        public bool Execute(Player player){

            if (this.HasSecondWord())
            {
                player.AttackThis(SecondWord);
            }
            else
            {
                player.WarningMessage("Attack what?");
            }
            return false;
        }
        
    }

}
