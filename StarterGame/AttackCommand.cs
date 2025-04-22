using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class AttackCommand : Command{

        private string _enemy;
        private CommandWords _words;

        public AttackCommand() : this(new CommandWords()) { }

        public AttackCommand(CommandWords commands) : base()
        {
            _words = commands;
            this.Name = "attack";
        }
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
