namespace StarterGame{
    public class Item{
        private string _name;
        private float _volume;

        private float _weight;

        public string Name{get{return _name;}set{ _name = value;} }

        public float Volume{get{return _volume;} set{ _volume = value;} }

        public float Weight{get{return _weight;} set{ _weight = value;} }

        public Item(string name, float volume, float weight){
            _name = name;
            _volume = volume;
            _weight = weight;
        }
        @Override
        public string ToString(){
            return Name;
        }
    }
}