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
                foreach (IItem item in _items.Values)
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
                foreach (IItem item in _items.Values)
                {
                    description += "\n\t" + item.Description;
                }
                return description;
            }
        }
        public ItemContainer() : base() {
            _items = new Dictionary<string, IItem>();
        }

        public ItemContainer(string name) : base(name) {
            _items = new Dictionary<string, IItem>();
        }

        public ItemContainer(string name, float weight) : base(name, weight)
        {
            _items = new Dictionary<string, IItem>();
        }

        public bool Insert(IItem item)
        {
            bool value = false;
            if (item != null)
            {
                _items.Add(item.Name, item);
                
                if (_items.ContainsKey(item.Name))
                {
                    value = true;
                }
            }
            
            return value;
        }
        public bool DoesContain(string itemName)
        {
            return _items.ContainsKey(itemName);
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

        public IItem GetItem(string itemName)
        {
            foreach (var item in _items)
            {
                if (itemName.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                {
                    return item.Value;
                }
            }
            return null;
        }
    }
}
