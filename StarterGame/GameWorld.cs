using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class GameWorld
    {
        private static GameWorld _instance;

        public static GameWorld Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameWorld();
                }
                return _instance;
            }
        }

        public Room Entrance;
        public Room Exit;
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

        private void CreateWorld()
        {
            // create rooms
            Room mainroom = new Room("the main entrance to the labrynth");
            Room intersection1 = new Room("an intersection in the labrynth");
            Room bossRoom = new Room("an arena where the minotaur sits");
            //Room hbd = new Room("describe room");

            //set exits
            mainroom.SetExit("South", intersection1);

            //setup delegates
            //MiniGame minigame1 = new MiniGame();
            //minigame1.Engaged = true;
            //hbd.Delegate = minigame1;


            //create a chest
            IItemContainer chest = new ItemContainer("chest", 0.25f);
            IItem item1 = new Item("Flashlight", 0.2f);
            chest.Insert(item1);
            item1 = new Item("Cookie", 0.1f);
            chest.Insert(item1);
            mainroom.Drop(chest);

            Entrance = mainroom;
            Exit = bossRoom;
        }
    }
}
