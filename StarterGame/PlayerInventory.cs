namespace StarterGame{
    public class PlayerInventory{
        /** Want to implement this class with a player inventory that utilizes some data structure
        there will be a max volume, and if the player attempts to pick up an item and the volume of the item is more than the leftover space then the user cannot pick up the item
        will hold objects from the item class, each item in the item class has a volume
        */
        private Dictionary<string, Item> _inventory = new Dictionary<string, Item>();

        public PlayerInventory()
        {
            float _maxWeight = 60; //measured in pounds
            float _maxVolume = 80; //measured in Liters
        }

        public bool AddItem(Item item)
        {
            _inventory.Add(item.Name, item);
        }
    }
}