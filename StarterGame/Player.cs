using System.Collections;
using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;

namespace StarterGame
{
    /*
     * Fall 2024
     */

    //player class that contains all the function needed for the player to use
    public class Player
    {
        private int _health = 100;
        public int Health { get { return _health; } set { _health = value; } }
        private Room _currentRoom = null;

        private ItemContainer _inventory;
        public Room CurrentRoom { get { return _currentRoom; } set { _currentRoom = value; } }

        public Player(Room room)
        {
            _currentRoom = room;
            _inventory = new ItemContainer("player inventory:");
        }
        //function that allows player to move to different rooms
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
        public void AttackThis(string targetName)
        {
            if (CurrentRoom.MinotaurInRoom != null && targetName.ToLower() == "minotaur")
            {
                int damage = 5;

                if (_inventory.DoesContain("sword"))
                {
                    damage = 25;
                    InfoMessage("You swing your sword at the Minotaur and slash it.");
                }
                else
                {
                    WarningMessage("You punch the Minotaur, he barely seems fazed");
                }
                CurrentRoom.MinotaurInRoom.TakeDamage(damage, this);
            }
            else
            {
                WarningMessage("There is no " + targetName + " here to attack.");
            }
        }
        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            ErrorMessage($"You have been attacked! Health: {Health}");

            if(Health <= 0)
            {
                ErrorMessage("You have been slain..");
                Environment.Exit(0);
            }
        }
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

        public void Eat(string itemName)
        {
            IItem item = _inventory.GetItem(itemName);
            if(item == null)
            {
                WarningMessage($"You don't have an item called {itemName} to eat.");
                
            }
            if(item is Item edible && edible.IsEdible)
            {
                int healed = Math.Min(edible.HealAmount, 100 - Health);
                Health += healed;
                _inventory.Remove(itemName);
                InfoMessage($"You ate the {itemName}. Restored {healed} HP. Current health:{Health}");
            }
            else
            {
                WarningMessage($"You can't eat {itemName}");
            }
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
        public void GiveGhost(string itemName)
        {
            if (CurrentRoom.GhostInRoom != null)
            {
                CurrentRoom.GhostInRoom.ReceiveItem(this, itemName);
            }
            else
            {
                WarningMessage("There is no ghost here to give something to.");
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
