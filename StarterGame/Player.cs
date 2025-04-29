using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    /*
     * Fall 2024
     */
    public class Player
    {
        private Room _currentRoom = null;

        private ItemContainer _inventory = new ItemContainer();
        public Room CurrentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        public Player(Room room)
        {
            _currentRoom = room;
        }

        public void WaltTo(string direction)
        {
            Room nextRoom = this.CurrentRoom.GetExit(direction);
            if (nextRoom != null)
            {
                CurrentRoom = nextRoom;
                NormalMessage("\n" + this.CurrentRoom.Description());
            }
            else
            {
                ErrorMessage("\nThere is no door on " + direction);
            }
        }

        // Commented this out, needs to be redone
        //public void AttackThis(string _enemy, string itemName){
        

        //this sucks and doesn't actually do anything
        public void Dig(string _location)
        {
            if (_inventory.DoesContain("shovel"))
            {
                NormalMessage($"You dig at {_location} and uncover something hidden!");

            }
            else
            {
                ErrorMessage($"You try to dig at {_location}, but you need a shovel!");
            }
        }
        public void Give(IItem item)
        {
            _inventory.Insert(item);
        }
        public IItem Take(string itemName)
        {
            return _inventory.Remove(itemName);
        }

        public void Inventory()
        {
            InfoMessage(_inventory.Description);
        }
        public void PickUp(string itemName){
            IItem item = CurrentRoom.Pickup(itemName);
            if(item!= null)
            {
                Give(item);
                InfoMessage("You picked up " + item.Name);
            }
            else
            {
                WarningMessage("There is nothing named " + itemName + " here.");
            }

        }
        public void Drop(string itemName)
        {
            IItem item = Take(itemName);
            if(item != null)
            {
                CurrentRoom.Drop(item);
                InfoMessage("You dropped " + item.Name);
            }
            else
            {
                WarningMessage("You have nothing named " + itemName + " in your inventory.");
            }
        }
        public void InspectItem(string itemName)
        { 
            IItem itemToInspect = CurrentRoom.Pickup(itemName);
            if(itemToInspect != null){
                InfoMessage(itemName + " is " +
                itemToInspect.Description);
                CurrentRoom.Drop(itemToInspect);

            }else{
                WarningMessage("There is no item named " +
                itemName + " in the room.");
            }
        }

        public void TalkToGhost(){
            if (CurrentRoom.GhostInRoom != null)
            {
                CurrentRoom.GhostInRoom.Talk(this);
            }
            else
            {
                WarningMessage("There is no ghost here to talk to.");
            }
            }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ColoredMessage(string message, ConsoleColor newColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = newColor;
            OutputMessage(message);
            Console.ForegroundColor = oldColor;
        }

        public void NormalMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.White);
        }

        public void InfoMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Blue);
        }

        public void WarningMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.DarkYellow);
        }

        public void ErrorMessage(string message)
        {
            ColoredMessage(message, ConsoleColor.Red);
        }
    }

}
