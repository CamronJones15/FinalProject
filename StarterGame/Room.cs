using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    /*
     * Fall 2024
     */

    public interface IRoomDelegate
    {
        Room OnGetExit(string roomName);
        Room ContainingRoom { get; set; }

        void Enter(Player player);
    }

    public class BossRoomProxy : IRoomDelegate
    {
        private readonly Room _bossRoom;
        private Player _player;

        public Room ContainingRoom { get; set; }

        private string[] _requiredItems = { "keyoflife", "goldmedallion" };

        public BossRoomProxy(Room bossRoom, Player player)
        {
            _bossRoom = bossRoom;
            _player = player;
        }
        public void Enter(Player player)
        {
            foreach (var requiredItem in _requiredItems)
            {
                if (!player.HasItem(requiredItem))
                {
                    player.WarningMessage("The massive doors remain. You sense you're missing something important...");
                    player.CurrentRoom = ContainingRoom;
                    return;
                }
            }
            player.InfoMessage("You hold up the Key of Life and the Gold Medallion. The gate is opening");
            player.CurrentRoom = _bossRoom;

            _bossRoom.Delegate.Enter(player);
        }

        public Room OnGetExit(string direction)
        {
            //Player player = Player.Instance; Looking for instance in player class ERROR
            foreach (string item in _requiredItems)
            {
              // if (!player.HasItem(item))
                {
                    Console.WriteLine($"You cannot enter the boss room without the {item}.");
                    return null;
                }
            }
            return _bossRoom;
        }
    }
    
    public class TrapRoom : IRoomDelegate
    {
        private bool _engaged;
        public bool Engaged { set { _engaged = value; } get
            {
                return _engaged;
            } }
        private string _password;
        private IRoomDelegate _delegate;
        private Room _containingRoom;
        public Room ContainingRoom
        {
            set
            {
                _containingRoom = value;
            }
            get
            {
                return _containingRoom;
            }
        }
        public IRoomDelegate Delegate
        {
            set
            {
                if (value == null)
                {
                    if (_delegate != null)
                    {
                        _delegate.ContainingRoom = null;
                        _delegate = value;
                    }
                    else
                    {
                        if (value.ContainingRoom != null)
                        {
                            value.ContainingRoom.Delegate = null;
                            value.ContainingRoom.Delegate = this;
                            _delegate = value;
                        }
                    }
                }

            }
            get
            {
                return _delegate;
            }
        }
        public TrapRoom() : this("please") { }
        public TrapRoom(string password)
        {
            _password = password;
            Engaged = true;
            NotificationCenter.Instance.AddObserver("PlayerDidSaySomething", PlayerDidSaySomething);
        }
        private void PlayerDidSaySomething(Notification notification){
            string word = notification.Object as string;
            if(!string.IsNullOrEmpty(word)&&word.Equals(_password,StringComparison.OrdinalIgnoreCase)){
                Engaged = false;
            }
        }
        public Room OnGetExit(string roomName)
        {
            if(!Engaged && ContainingRoom != null){
                return ContainingRoom.GetExit(roomName);
            }
            return null;
        }

        public void Enter(Player player)
        {
            player.WarningMessage("You have entered a trap room!!");
            player.WarningMessage("Say the magic word to escape");
            if(_delegate != null)
            {
                _delegate.Enter(player);
            }
        }
    }
    public class Room : Trigger
    {
        private Dictionary<string, Room> _exits;
        private string _tag;
        private IItem _floor;
        private Minotaur _minotaur;
        public Minotaur MinotaurInRoom { get { return _minotaur; } set {_minotaur = value; } }
        public IRoomDelegate Delegate{get; set;}
        
        public string Tag { get { return _tag; } set { _tag = value; } }

        private Ghost _ghost;
        public Ghost GhostInRoom { get { return _ghost; } set { _ghost = value; } }

        public Room() : this("No Tag"){}

        // Designated Constructor
        public Room(string tag)
        {
            _exits = new Dictionary<string, Room>();
            this.Tag = tag;
            Delegate = null;
        }

        //function that sets an exit for the room
        public void SetExit(string exitName, Room room)
        {
            _exits[exitName] = room;
        }

        public Room GetExit(string exitName)
        {
            Room room = null;
            if(Delegate == null)
            {
                _exits.TryGetValue(exitName, out room);
            }
            else
            {
                room = Delegate.OnGetExit(exitName);
            }
            return room;
        }

        public string GetExits()
        {
            string exitNames = "Exits: ";
            Dictionary<string, Room>.KeyCollection keys = _exits.Keys;
            foreach (string exitName in keys)
            {
                exitNames += " " + exitName;
            }

            return exitNames;
        }
        //function that picks up an item off of the room floor based on the itemName that is passed
        public IItem Pickup(string itemName){
            IItem tempItem = null;
            if(_floor != null){
                if(_floor.Name.ToLower().Equals(itemName)){
                    tempItem = _floor;
                    _floor = null;
                    return tempItem;
                }
            }
            return tempItem;
        }
        //function to drop an item onto the room floor
        public void Drop(IItem item){
            _floor = item;
        }
        public string Description()
        {
            return "You are " + this.Tag + ".\n *** " + this.GetExits() + "\nFloor: " + (_floor==null?"empty":_floor.Name) + (_ghost == null ? "" : $"\nYou see a ghost here: {_ghost.Name}")+(_minotaur == null ? "" : $"\nThe minotaur is here.. prepare for battle!");
        }
    }
}
