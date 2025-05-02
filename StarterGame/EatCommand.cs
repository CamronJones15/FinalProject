using System;
using StarterGame;

namespace StarterGame
{
    public class EatCommand : Command
    {
        //command that allows the player to eat an item if its consumable
        public EatCommand() : base()
        {
            
            this.Name = "eat";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.Eat(SecondWord);
            }
            else
            {
                player.WarningMessage("Eat what?");
            }

            return false;
        }
    }
}
