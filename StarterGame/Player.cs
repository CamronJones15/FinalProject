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

        private Dictionary<string, Item> _inventory = new Dictionary<string, Item>();
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

        
        public void AttackThis(string _enemy, string itemName){
            

            
            List<Item> weapons = _inventory.GetWeapons(); //G
            if(weapons.Count == 0)
            {
                Console.WriteLine($"You cannot attack {_enemy} with no weapons!!");
                return;
            }
            Console.WriteLine($"Choose a weapon to attack {_enemy}:");
            for (int i = 0; i < weapons.Count; i++){
                NormalMessage($"{i + 1}. {weapons[i].Name}");

            }

            Console.Write("Enter the number of your choice:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice > 0 && choice <= weapons.Count)
            {
                Item selectedWeapon = weapons[choice - 1];
                NormalMessage($"You swing your {selectedWeapon.Name} at the {_enemy} and deal damage!");
            }
            else
            {
                ErrorMessage("Invalid choice! You hesitate and miss your attack.");
            }
        }
        public void Dig(string _location)
        {
            if (_inventory.ContainsKey("Shovel"))
            {
                NormalMessage($"You dig at {_location} and uncover something hidden!");

            }
            else
            {
                ErrorMessage($"You try to dig at {_location}, but you need a shovel!");
            }
        }

        public void PickUpItem(string item){
            //have to figure how to parse the string into an item, maybe by using a dictionary where the key is the name of the item

        }

        public void InspectItem(string itemName)
        {
            // if (_inventory.ContainsKey(item))
            // {
            //     Item inspectedItem;
            //     if(_inventory.TryGetValue(item, out inspectedItem))
            //     {
            //         InfoMessage(inspectedItem.Inspect());
            //     }
            //     else
            //     {
            //         WarningMessage("Error: Unable to inspect item");
            //     }
            // }
            // else
            // {
            //     WarningMessage("Item not in inventory");
            // }

            InspectItem itemToInspect = CurrentRoom.Pickup(itemName);
            if(itemToInspect != null){
                InfoMessage(itemName + " is " +
                itemToInspect.Description);
                CurrentRoom.Drop(itemToInspect);

            }else{
                WarningMessage("There is no item named " +
                itemName + " in the room.");
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
