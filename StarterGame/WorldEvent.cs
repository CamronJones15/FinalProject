using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class WorldEvent : IWorldEvent{

        private Trigger _trigger;
        private Room _toRoom;
        private Room _fromRoom;
        private string _toDirection;
        private string _fromDirection;

        public Trigger Trigger{get {return _trigger;} set{_trigger = value;} }

        public WorldEvent(Room trigger, Room toRoom, Room fromRoom, string toDirection, string fromDirection){
            
            _trigger = trigger;
            _toRoom = toRoom;
            _fromRoom = fromRoom;
            _toDirection = toDirection;
            _fromDirection = fromDirection;

        }

        public void Execute()
        {
            _fromRoom.SetExit(_toDirection , _toRoom);
            _toRoom.SetExit(_fromDirection, _fromRoom);
        }
    }
}