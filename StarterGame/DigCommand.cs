using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class DigCommand : Command{
        private string _location;
        private Inventory _inventory;

        public DigCommand(string location, Inventory){
            _location = location;
            _inventory = inventory;
        }
           public void Execute()
        {
            if (_inventory.HasItem("Shovel"))
            {
                Console.WriteLine($"You dig at {_location} and uncover something hidden!");
               
            }
            else
            {
                Console.WriteLine($"You try to dig at {_location}, but you need a shovel!");
            }
        }

    }
}