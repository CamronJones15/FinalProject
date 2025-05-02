using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class SayCommand : Command
    {
        public SayCommand() : base()
        {
            this.Name = "say";
        }

        public override bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                string saidWord = this.SecondWord.ToLower();
                NotificationCenter.Instance.PostNotification(new Notification("PlayerSaidWord", saidWord));
            }
            else
            {
                player.WarningMessage("Say what?");
            }

            return false;
        }
    }
}