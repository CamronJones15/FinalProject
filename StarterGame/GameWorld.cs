using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class GameWorld
    {
        private Dictionary<Trigger, IWorldEvent> _events;

        private GameWorld()
        {
            _events = new Dictionary<Trigger, IWorldEvent>();
            NotificationCenter.Instance.AddObserver("PlayerEnteredRoom", PlayerEnteredRoom);
            CreateWorld();
        }

        public void PlayerEnteredRoom(Notification notification)
        {
            Player player = (Player)notification.Object;
            if(player != null)
            {
                if(player != null)
                {
                    if(player.CurrentRoom == Entrance)
                    {
                        player.ErrorMessage("Player is back at the entrance");
                    }if(player.CurrentRoom == Exit)
                    {
                        player.ErrorMessage("Player is now at the exit");
                    }
                    if (_events.ContainsKey(player.CurrentRoom))
                    {
                        IWorldEvent we = _events[player.CurrentRoom];
                        we.Execute();
                        player.WarningMessage("Something happened somewhere...");
                    }
                }
            }
        }

        public void CreateWorld()
        {
            // create rooms
            Room mainroom = new Room("the main entrance to the labrynth");
            Room intersection1 = new Room("an intersection in the labrynth");

            //set exits
            mainroom.SetExit("South", intersection1);
            
        }
    }
}
