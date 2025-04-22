using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    class ItemContainer : Item, IItemContainer
    {
        private Dictionary<string, IItem> _items;

        override
        public bool IsContainer
        {
            get
            {
                return true;
            }
        }

        override
        public float Weight
        {
            get
            {
                float weight = base.Weight;
                foreach(IItem item in _items.Values)
                {
                    weight += item.Weight;
                }
                return weight;
            }
        }
        override
        public string Description
        {
            get
            {
                string description = base.Description;
                foreach(IItem item in _items.Values)
                {
                    description += "\n\t" + item.Description;
                }
                return description;
            }
        }
        public ItemContainer() : base() { }

        public ItemContainer(string name) : base(name) { }

        public ItemContainer(string name, float weight) : base(name, weight)
        {
            _items = new Dictionary<string, IItem>();
        }
        
        public bool Insert(IItem item)
        {
            return false;
        }

        public IItem Remove(string itemName)
        {
            IItem itemToRemove = null;
            if (_items.ContainsKey(itemName))
            {
                itemToRemove = _items[itemName];
                _items.Remove(itemName);
            }
            return itemToRemove;
        }
    }
}
