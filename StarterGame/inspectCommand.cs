using System;
using System.Collections.Generic;

namespace StarterGame
{

    public class InspectCommand : Command{

        private CommandWords _words;

        public InspectCommand() : this(new CommandWords()) { }
        public InspectCommand(CommandWords commands) : base(){
            _words = commands;
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