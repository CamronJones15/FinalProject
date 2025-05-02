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

        //game world instance (singleton design pattern)
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
            Room intersection1 = new Room("Intersection 1 : at a crossroads, with multiple paths ahead");
            Room intersection2 = new Room("Intersection 2:  at a crossroads, with multiple paths ahead");
            Room intersection3 = new Room("Intersection 3:  at a crossroads, with multiple paths ahead");
            Room intersection4 = new Room("Intersection 4: at a crossroads, with multiple paths ahead");
            Room intersection5 = new Room("Intersection 5: at a crossroads, with multiple paths ahead");
            Room intersection6 = new Room("Intersection 6: at a crossroads, with multiple paths ahead");
            Room intersection7 = new Room("Intersection 7: at a crossroads, with multiple paths ahead");
            Room intersection8 = new Room("Intersection 8: at a crossroads, with multiple paths ahead");
            Room intersection9 = new Room("Intersection 9: at a crossroads, with multiple paths ahead");
            Room intersection10 = new Room("Intersection 10: at a crossroads, with multiple paths ahead");
            Room intersection11 = new Room("Intersection 11:at a crossroads, with multiple paths ahead");
            Room deadendroom1 = new Room("Deadend Room 1: at a deadend, the only available path is the way you came");
            Room deadendroom4 = new Room("Deadend Room 4: at a deadend, the only available path is the way you came");
            Room deadendroom5 = new Room("Deadend Room 5: at a deadend, the only available path is the way you came");
            Room deadendroom6 = new Room("Deadend Room 6: at a deadend, the only available path is the way you came");
            Room deadendroom7 = new Room("Deadend Room 7: at a deadend, the only available path is the way you came");
            Room deadendroom8 = new Room("Deadend Room 8: at a deadend, the only available path is the way you came");
            Room deadendroom9 = new Room("Deadend Room 9: at a deadend, the only available path is the way you came");
            Room deadendroom10 = new Room("Deadend Room 10: at a deadend, the only available path is the way you came");
            Room deadendroom11 = new Room("Deadend Room 11: at a deadend, the only available path is the way you came");
            Room deadendroom12 = new Room("Deadend Room 12:  at a deadend, the only available path is the way you came");
            Room deadendroom13 = new Room("Deadend Room 13: at a deadend, the only available path is the way you came");
            Room gateRoom = new Room("The Gate before the Boss Room.");
            Room bossRoom = new Room("Boss Room: in an arena where the minotaur sits");
            //Room hbd = new Room("describe room");
            Room hbdroom = new Room("Happy Birthday Room: There is an Suprise Item in Here!!!");
            Room greenRoom = new Room("Green House Room: There is an Suprise Item in Here!!!");
            Room kitchenRoom = new Room("Kitchen Room: Are you Hungry?? Collect Some Food!!.");
            Room iceroom = new Room("Ice Room: You got to Healed. Grab an Ice Pack!");
            Room emergencyroom = new Room("Emergency Room: We Don't want you to have any scars. Grab an Bandage!");
            Room chemicalroom = new Room("Chemcial Room: There is an special potion. Collect it!");
            Room ghostroom1 = new Room("Ghost Room 1: further in the labrynth");
            Room ghostroom2 = new Room("Ghost Room 2: further in the labrynth");
            Room ghostroom3 = new Room("Ghost Room 3:  further in the labrynth");
            Room ghostroom4 = new Room("Ghost Room 4: further in the labrynth");
            Room ghostroom5 = new Room("Ghost Room 5: further in the labrynth");
            Room ghostroom6 = new Room("Ghost Room 6: further in the labrynth");
            Room ghostroom7 = new Room("Ghost Room 7: further in the labrynth");
            Room ghostroom8 = new Room("Ghost Room 8: further in the labrynth");
            Room greenTrap = new Room("Snaring Vines Room");
            Room shadowTrap = new Room("Shadow Binding Chabmer");
            Room trapTreasure = new Room("Dusty Treasure Vault");
            //Ghost Rooms 
            Ghost john = new Ghost(ghostroom1,"John", "Be careful... the minotaur is near."); //we seriously need better hints lmao
            Ghost reign = new Ghost(ghostroom2,"Reign", "Solve the puzzle, or be trapped forever!");
            Ghost bob = new Ghost(ghostroom3,"Bob", "You made it farther than anyone else...");
            john.PreferredItem = "Diamonds";
            reign.PreferredItem = "Cookie";
            bob.PreferredItem = "CrunchWrap";
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
            intersection1.SetExit("north", mainroom);
            intersection1.SetExit("west", intersection2);
            intersection2.SetExit("west", deadendroom1);
            intersection2.SetExit("east", intersection1);
            deadendroom1.SetExit("east", intersection2);
            intersection2.SetExit("south", ghostroom2);
            ghostroom1.SetExit("east", hbdroom);
            ghostroom1.SetExit("west", intersection2);
            hbdroom.SetExit("east", intersection3);
            hbdroom.SetExit("west", ghostroom1);
            intersection3.SetExit("south", ghostroom3);
            intersection3.SetExit("west", hbdroom);
            ghostroom3.SetExit("south", kitchenRoom);
            ghostroom3.SetExit("north", intersection3);
            kitchenRoom.SetExit("south", intersection7);
            kitchenRoom.SetExit("north", ghostroom3);
            
            intersection7.SetExit("east", deadendroom5);
            deadendroom5.SetExit("west", intersection7);
            intersection7.SetExit("west", deadendroom6);
            deadendroom6.SetExit("west", intersection7);
            intersection7.SetExit("south", intersection8);
            
            intersection8.SetExit("west", ghostroom5);
            intersection8.SetExit("east", deadendroom7);
            deadendroom7.SetExit("west", intersection8);
            ghostroom5.SetExit("west", iceroom);
            ghostroom5.SetExit("east", intersection8);
            iceroom.SetExit("south", intersection9);
            iceroom.SetExit("north", ghostroom5);
            intersection9.SetExit("east", deadendroom8);
            deadendroom8.SetExit("west", intersection9);
            intersection9.SetExit("south", ghostroom6);
            ghostroom6.SetExit("south", shadowTrap);
            shadowTrap.SetExit("north", ghostroom6);
            shadowTrap.SetExit("south", gateRoom);
            gateRoom.SetExit("south", bossRoom);
            gateRoom.SetExit("north", shadowTrap);
            ghostroom6.SetExit("north", intersection9);
            
            ghostroom2.SetExit("south", greenTrap);
            greenTrap.SetExit("north", ghostroom2);
            greenTrap.SetExit("south", greenRoom);
            ghostroom2.SetExit("north", intersection2);
            greenRoom.SetExit("south", intersection4);
            greenRoom.SetExit("north", greenTrap);
            intersection4.SetExit("east", intersection5);
            intersection4.SetExit("west", intersection6);
            intersection6.SetExit("south", deadendroom4);
            deadendroom4.SetExit("north", intersection6);
            intersection6.SetExit("east", intersection4);
            intersection4.SetExit("south", trapTreasure);
            trapTreasure.SetExit("north", intersection4);
            intersection5.SetExit("south", ghostroom4);
            
            ghostroom4.SetExit("south", emergencyroom);
            ghostroom4.SetExit("north", intersection5);
            emergencyroom.SetExit("south", intersection10);
            emergencyroom.SetExit("north", ghostroom4);
            intersection10.SetExit("east", deadendroom10);
            intersection10.SetExit("north", emergencyroom);
            deadendroom10.SetExit("west", intersection10);
            intersection10.SetExit("west", deadendroom11);
            deadendroom11.SetExit("east", intersection10);
            intersection10.SetExit("south", ghostroom7);
            
            ghostroom7.SetExit("south", chemicalroom);
            ghostroom7.SetExit("north", intersection10);
            chemicalroom.SetExit("south", intersection11);
            chemicalroom.SetExit("north", ghostroom7);   
            intersection11.SetExit("west", deadendroom12);
            deadendroom12.SetExit("east", intersection11);
            intersection11.SetExit("east", deadendroom13);
            deadendroom13.SetExit("west", intersection11);
            intersection11.SetExit("south", ghostroom8);
            
            ghostroom8.SetExit("south", gateRoom);
            intersection5.SetExit("west", intersection4);
            gateRoom.SetExit("south", bossRoom);
            gateRoom.SetExit("north", ghostroom8);
            ghostroom8.SetExit("north", intersection11);
            //setup delegates
            //MiniGame minigame1 = new MiniGame();
            //minigame1.Engaged = true;
            //hbd.Delegate = minigame1;


            //Adding items to the game
            IItem cookie = new Item("cookie", 0.1f);
            mainroom.Drop(cookie);

            IItem diamonds = new Item("diamonds", 0.2f);
            IItem crunchwrap = new Item("crunchwrap", 0.1f);
            deadendroom4.Drop(diamonds);

            
            IItem cake = new Item("cake", 0.2f , 20);
            hbdroom.Drop(cake);


            IItem spinach = new Item("spinach", 0.2f, 20);
            greenRoom.Drop(spinach);

            IItem pizza = new Item("pizza", 0.2f, 10);
            kitchenRoom.Drop(pizza);


            IItem ice = new Item("ice", 0.2f, 2);
            iceroom.Drop(ice);

            
            IItem medicine = new Item("medicine", 0.1f, 5);
            emergencyroom.Drop(medicine);

            
            IItem potion = new Item("potion", 0.2f, 10);
            chemicalroom.Drop(potion);

            IItem key = new Item("keyoflife", 0.1f);
            deadendroom6.Drop(key);


            IItem medallion = new Item("goldmedallion", 0.2f);
            chemicalroom.Drop(medallion);


            Item sword = new Item("sword", 1.5f, true, 100);
            deadendroom4.Drop(sword);
            //adding minotaur
            Minotaur mino = new Minotaur(bossRoom);
            bossRoom.MinotaurInRoom = mino;

           // BossRoomProxy proxy = new BossRoomProxy(bossRoom);
            //bossRoom.Delegate = proxy;
            //gateRoom.Delegate = proxy;

            TrapRoom trapDelegate = new TrapRoom("sprout");
            trapDelegate.ContainingRoom = greenTrap;
            greenTrap.Delegate = trapDelegate;

            TrapRoom shadowDelegate = new TrapRoom("release");
            shadowDelegate.ContainingRoom = shadowTrap;
            shadowTrap.Delegate = shadowDelegate;

            TrapRoom vaultTrap = new TrapRoom("escape");
            vaultTrap.ContainingRoom = trapTreasure;
            trapTreasure.Delegate = vaultTrap;


            Entrance = mainroom;
            Exit = bossRoom;
        }
    }
}
