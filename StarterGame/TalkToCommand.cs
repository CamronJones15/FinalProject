using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class TalkToCommand : Command
    {
        public TalkToCommand() : base() 
        {
            this.Name = "talk";
        }

        override
        public bool Execute(Player player)
        { 
            
            player.TalkToGhost();
            return false;
        }
    }
}
