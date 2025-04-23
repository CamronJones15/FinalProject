using System;
using System.Collections.Generic;
namespace StarterGame{
    public class PlayerInventory{
        /** Want to implement this class with a player inventory that utilizes some data structure
        there will be a max weight, and if the player attempts to pick up an item and the weight of the item is more than the leftover space then the user cannot pick up the item
        will hold objects from the item class, each item in the item class has a weight
        */
        private Dictionary<string, Item> _inventory = new Dictionary<string, Item>();

        public PlayerInventory()
        {
            float _maxWeight = 60; //measured in pounds
        }

        public bool AddItem(Item item)
        {
            bool returnVal;
            _inventory.Add(item.Name, item);
            if(_inventory.ContainsKey(item.Name))
            {
                returnVal = true;
            }
            else
            {
                returnVal = false;
            }
            return returnVal;
        }
    }
}