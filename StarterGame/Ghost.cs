using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Ghost : Player{
        private string _name;
        private string _preferredItem;
        private string _dialogue;
        private bool _hasRevealedInfo = false;
        public string Name { get { return _name; } set { _name = value; } }
        public string Dialogue{ get { return _dialogue; } set { _dialogue = value; } }
        public string PreferredItem
        {
            get { return _preferredItem; }
            set { _preferredItem = value; }
        }
        
        public Ghost(Room room, string name, string dialogue) : base(room)
        {
            CurrentRoom = room;
            Name = name;
            Dialogue = dialogue;
        }
        public void Talk(Player player){
            if (_hasRevealedInfo)
            {
                player.NormalMessage($"{Name} says: I have already told you everything");
            }
            else
            {
                player.InfoMessage($"{Name} says: I have lost my {_preferredItem}, please find it and I will give you information");
            }
        }
        public void ReceiveItem(Player player, string itemName)
        {
            if (_hasRevealedInfo)
            {
                player.WarningMessage($"{Name} says: You've already helped me, and I've told you all I know");
            }
            if(itemName.ToLower() == _preferredItem)
            {
                IItem item = player.Take(itemName);
                if(item != null)
                {
                    _hasRevealedInfo = true;
                    player.InfoMessage($"{Name} takes the item and whispers: {Dialogue}");
                }
                else
                {
                    player.WarningMessage("You do not have that item.");
                }
            }
            else
            {
                player.WarningMessage($"{Name} says: This is not what I seek...");
            }
        }
    }
}