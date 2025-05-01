using System;
using StarterGame;

namespace StarterGame
{
    public class EatCommand : Command
    {
        private CommandWords _words;

        public EatCommand() : this(new CommandWords()) { }

        public EatCommand(CommandWords commands) : base()
        {
            _words = commands;
            this.Name = "eat";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                string itemName = this.SecondWord;
                player.Eat(itemName);
                //player.NormalMessage(result);
            }
            else
            {
                player.WarningMessage("Eat what?");
            }

            return false;
        }
    }
}
