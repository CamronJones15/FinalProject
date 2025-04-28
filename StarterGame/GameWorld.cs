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
        private Room Entrance;
        private Room Exit;
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
            Room intersection2 = new Room("an intersection in the labrynth");
            Room intersection3 = new Room("an intersection in the labrynth");
            Room intersection4 = new Room("an intersection in the labrynth");
            Room intersection5 = new Room("an intersection in the labrynth");
            Room intersection6 = new Room("an intersection in the labrynth");
            Room intersection7 = new Room("an intersection in the labrynth");
            Room intersection8 = new Room("an intersection in the labrynth");
            Room intersection9 = new Room("an intersection in the labrynth");
            Room intersection10 = new Room("an intersection in the labrynth");
            Room intersection11 = new Room("an intersection in the labrynth");
            Room deadendroom1 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom4 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom5 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom6 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom7 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom8 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom9 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom10 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom11 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom12 = new Room("dead end room with hidden items inside of the rooms");
            Room deadendroom13 = new Room("dead end room with hidden items inside of the rooms");
            Room bossRoom = new Room("an arena where the minotaur sits");
            //Room hbd = new Room("describe room");
            Room hbdroom = new Room("an minigame room in the maze.");
            Room greenRoom = new Room("an minigame room in the maze.");
            Room hoproom = new Room("an minigame room in the maze.");
            Room tmtroom = new Room("an minigame room in the maze.");
            Room endlessroom = new Room("an minigame room in the maze.");
            Room mssgvowelsroom = new Room("an minigame room in the maze.");
            Room ghostroom1 = new Room("an room where you interact with ghost John");
            Room Ghostroom2 = new Room("an room where you interact with ghost John");
            Room Ghostroom3 = new Room("an room where you interact with ghost John");
            Room Ghostroom4 = new Room("an room where you interact with ghost Reign");
            Room Ghostroom5 = new Room("an room where you interact with ghost Reign");
            Room Ghostroom6 = new Room("an room where you interact with ghost Bob");
            Room Ghostroom7 = new Room("an room where you interact with ghost Bob");
            Room Ghostroom8 = new Room("an room where you interact with ghost Bob");

            //set exits
            mainroom.SetExit("South", intersection1);
            intersection1.SetExit("East",ghostroom1);
            intersection1.SetExit("West", intersection2);
            intersection2.SetExit("West", deadendroom1);
            deadendroom1.SetExit("East", intersection2);
            intersection2.SetExit("South", Ghostroom2);
            ghostroom1.SetExit("East", hbdroom);
            hbdroom.SetExit("East", intersection3);
            intersection3.SetExit("South", Ghostroom3);
            Ghostroom3.SetExit("South", hoproom);
            hoproom.SetExit("South", intersection7);
            intersection7.SetExit("East", deadendroom5);
            deadendroom5.SetExit("West", intersection7);
            intersection7.SetExit("West", deadendroom6);
            deadendroom6.SetExit("West", intersection7);
            intersection7.SetExit("South", intersection8);
            intersection8.SetExit("West", Ghostroom5);
            intersection8.SetExit("East", deadendroom7);
            Ghostroom5.SetExit("West", mssgvowelsroom);
            mssgvowelsroom.SetExit("South", intersection9);
            intersection9.SetExit("East", deadendroom8);
            intersection9.SetExit("South", Ghostroom6);
            Ghostroom6.SetExit("South", bossRoom);
            Ghostroom2.SetExit("South", greenRoom);
            greenRoom.SetExit("South", intersection4);
            intersection4.SetExit("East", intersection5);
            intersection4.SetExit("West", intersection6);
            intersection6.SetExit("South", deadendroom4);
            deadendroom4.SetExit("North", intersection6);
            intersection6.SetExit("East", intersection4);
            intersection4.SetExit("South", deadendroom9);
            deadendroom9.SetExit("North", intersection4);
            intersection5.SetExit("South", Ghostroom4);
            Ghostroom4.SetExit("South", tmtroom);
            tmtroom.SetExit("South", intersection10);
            intersection10.SetExit("East", deadendroom10);
            deadendroom10.SetExit("West", intersection10);
            intersection10.SetExit("West", deadendroom11);
            deadendroom11.SetExit("East", intersection10);
            intersection10.SetExit("South", Ghostroom7);
            Ghostroom7.SetExit("South", endlessroom);
            endlessroom.SetExit("South", intersection11);
            intersection11.SetExit("West", deadendroom12);
            deadendroom12.SetExit("East",intersection11);
            intersection11.SetExit("East", deadendroom13);
            deadendroom13.SetExit("West", intersection11);
            intersection11.SetExit("South", Ghostroom8);
            Ghostroom8.SetExit("South", bossRoom);

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
