using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class EnterCommand : Command
    {
        public EnterCommand() : base(){
            this.Name = "enter";
        }
        public override bool Execute(Player player)
        {
            Room current = player.CurrentRoom;

            if (current.Delegate is BossRoomProxy proxy)
            {
                proxy.Enter(player);
            }
            else
            {
                player.WarningMessage("There is nothing special to enter here");
            }
            return false;
        }
    }
}
