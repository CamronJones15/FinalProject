using System.Runtime.CompilerServices;

namespace StarterGame{
    public class Item : IItem{
        private string _name;
        private float _volume;

        private float _weight;

        private bool _isEdible = false;
        private int _healAmount = 0;
        private bool _isDegradable = false;
        public bool IsDegradable { get { return _isDegradable; } set {_isDegradable = value; } }
        private int _durability = 0;
        public int Durability { get { return _durability; } set { _durability = value; } }
        private bool _isBroken = false;
        public bool IsBroken { get { return _isBroken; } set { _isBroken = value; } }
        public string Name{ get { return _name + (_decorator == null?"": $"[{_decorator.Name}]"); } set { _name = value; } }

        //public float Volume{get{return _volume;} set{ _volume = value;} }

        public virtual float Weight{get{return _weight+(_decorator == null?0:_decorator.Weight);} set{ _weight = value;} }
        

        public void Decorate(IItem decorator)
        {
            this.Decorator = decorator;
        }
        public virtual bool IsEdible { get{return _isEdible;}}
        public virtual int HealAmount { get { return _healAmount; } }
        public Item() : this("NoName"){}
        private IItem _decorator;
        public IItem Decorator { get { return _decorator; } set { _decorator = value; } }
        public virtual bool IsContainer { get { return false; } }
        public Item(string name) : this(name, 0) {}
        public Item(string name, float weight){
            _name = name;
            _weight = weight;
        }
        public Item(string name, float weight, bool isDegradable, int durability)
        {
            _name = name;
            _weight = weight;
            IsDegradable = isDegradable;
            Durability = durability;
        }
        public Item(string name, float weight, int healAmount)
        {
            _name = name;
            _weight = weight;
            _healAmount = healAmount;
            _isEdible = true;
        }


        
        public virtual string Description
        {
             get{ return ToString(); } 
        }
        public int ReduceDurability(int amount)
        {
            Durability -= amount;
            if(Durability <= 0)
            {
                IsBroken = true;
            }
            else
            {
                IsBroken = false;
            }
                return Durability;
        }
        override
        public string ToString(){
            return (this.Name + "\nweight: " + this.Weight);
        }
    }
}