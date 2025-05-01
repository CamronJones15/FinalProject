using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Room intersection1 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection2 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection3 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection4 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection5 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection6 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection7 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection8 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection9 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection10 = new Room("at a crossroads, with multiple paths ahead");
            Room intersection11 = new Room("at a crossroads, with multiple paths ahead");
            Room deadendroom1 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom4 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom5 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom6 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom7 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom8 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom9 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom10 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom11 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom12 = new Room("at a deadend, the only available path is the way you came");
            Room deadendroom13 = new Room("at a deadend, the only available path is the way you came");
            Room bossRoom = new Room("in an arena where the minotaur sits");
            //Room hbd = new Room("describe room");
            Room hbdroom = new Room("in a minigame room in the maze.");
            Room greenRoom = new Room("in a minigame room in the maze.");
            Room hoproom = new Room("in a minigame room in the maze.");
            Room tmtroom = new Room("in a minigame room in the maze.");
            Room endlessroom = new Room("in a minigame room in the maze.");
            Room mssgvowelsroom = new Room("in a minigame room in the maze.");
            Room ghostroom1 = new Room("further in the labrynth");
            Room ghostroom2 = new Room("further in the labrynth");
            Room ghostroom3 = new Room("further in the labrynth");
            Room ghostroom4 = new Room("further in the labrynth");
            Room ghostroom5 = new Room("further in the labrynth");
            Room ghostroom6 = new Room("further in the labrynth");
            Room ghostroom7 = new Room("further in the labrynth");
            Room ghostroom8 = new Room("further in the labrynth");

            //Ghost Rooms 
            Ghost john = new Ghost(ghostroom1,"John", "Be careful... the minotaur is near.");
            Ghost reign = new Ghost(ghostroom2,"Reign", "Solve the puzzle, or be trapped forever!");
            Ghost bob = new Ghost(ghostroom3,"Bob", "You made it farther than anyone else...");

            ghostroom1.GhostInRoom = john;
            ghostroom2.GhostInRoom = john;
            ghostroom3.GhostInRoom = john;
            ghostroom4.GhostInRoom = reign;
            ghostroom5.GhostInRoom = reign;
            ghostroom6.GhostInRoom = bob;
            ghostroom7.GhostInRoom = bob;
            ghostroom8.GhostInRoom = bob;

            //set exits
            mainroom.SetExit("south", intersection1);
            intersection1.SetExit("east", ghostroom1);
            intersection1.SetExit("west", intersection2);
            
            intersection2.SetExit("west", deadendroom1);
            deadendroom1.SetExit("east", intersection2);
            intersection2.SetExit("south", ghostroom2);
            
            // Right Branch from Ghostroom1
            ghostroom1.SetExit("east", hbdroom);
            hbdroom.SetExit("east", intersection3);
            intersection3.SetExit("south", ghostroom3);
            ghostroom3.SetExit("south", hoproom);
            hoproom.SetExit("south", intersection7);
            
            intersection7.SetExit("east", deadendroom5);
            deadendroom5.SetExit("west", intersection7);
            intersection7.SetExit("west", deadendroom6);
            deadendroom6.SetExit("east", intersection7);
            intersection7.SetExit("south", intersection8);
            
            intersection8.SetExit("west", ghostroom5);
            ghostroom5.SetExit("west", mssgvowelsroom);
            mssgvowelsroom.SetExit("south", intersection9);
            intersection9.SetExit("east", deadendroom8);
            intersection9.SetExit("south", ghostroom6);
            ghostroom6.SetExit("south", bossRoom);
            
            intersection8.SetExit("east", deadendroom7);
            deadendroom7.SetExit("west", intersection8);
            
            // Left Branch from Ghostroom2
            ghostroom2.SetExit("south", greenRoom);
            greenRoom.SetExit("south", intersection4);
            intersection4.SetExit("east", intersection5);
            intersection4.SetExit("west", intersection6);
            
            intersection6.SetExit("south", deadendroom4);
            deadendroom4.SetExit("north", intersection6);
            intersection6.SetExit("east", intersection4);
            
            intersection4.SetExit("south", deadendroom9);
            deadendroom9.SetExit("north", intersection4);
            
            intersection5.SetExit("south", ghostroom4);
            ghostroom4.SetExit("south", tmtroom);
            tmtroom.SetExit("south", intersection10);
            intersection10.SetExit("east", deadendroom10);
            deadendroom10.SetExit("west", intersection10);
            intersection10.SetExit("west", deadendroom11);
            deadendroom11.SetExit("east", intersection10);
            
            intersection10.SetExit("south", ghostroom7);
            ghostroom7.SetExit("south", endlessroom);
            endlessroom.SetExit("south", intersection11);
            
            intersection11.SetExit("west", deadendroom12);
            deadendroom12.SetExit("east", intersection11);
            intersection11.SetExit("east", deadendroom13);
            deadendroom13.SetExit("west", intersection11);
            
            intersection11.SetExit("south", ghostroom8);
            ghostroom8.SetExit("south", bossRoom);
            //setup delegates
            //MiniGame minigame1 = new MiniGame();
            //minigame1.Engaged = true;
            //hbd.Delegate = minigame1;


            //create a chest
            IItemContainer chest1 = new ItemContainer("chest", 0.25f);
            IItem item1 = new Item("Flashlight", 0.2f);
            chest1.Insert(item1);
            item1 = new Item("Cookie", 0.1f);
            chest1.Insert(item1);
            mainroom.Drop(chest1);

            IItemContainer chest2 = new ItemContainer("chest", 0.25f);
            IItem item2 = new Item("Diamonds", 0.2f);
            chest2.Insert(item2);
            item2 = new Item("Gold", 0.1f);
            chest2.Insert(item2);
            deadendroom13.Drop(chest2);

            Entrance = mainroom;
            Exit = bossRoom;
        }
    }
}
