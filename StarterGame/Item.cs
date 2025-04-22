namespace StarterGame{
    public class Item : IItem{
        private string _name;
        private float _volume;

        private float _weight;

        public string Name{get{return _name;}set{ _name = value;} }

        public float Volume{get{return _volume;} set{ _volume = value;} }

        public virtual float Weight{get{return _weight+(_decorator == null?0:_decorator.Weight);} set{ _weight = value;} }
        //needs Decorate function that takes an item still need to research this
        public Item() : this("NoName"){}
        private IItem _decorator;
        public IItem Decorator { get { return _decorator; } set { _decorator = value; } }
        public virtual bool IsContainer { get { return false; } }
        public Item(string name) : this(name, 1) {}
        public Item(string name, float weight){
            _name = name;
            _weight = weight;
        }
        
        public virtual string Description
        {
             get{ return ToString(); } 
        }

        override
        public string ToString(){
            return (this.Name + "\nvolume: " + this.Volume + "\nweight: " + this.Weight);
        }
    }
}