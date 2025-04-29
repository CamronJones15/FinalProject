using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Ghost : Player{
        public string Name{get; private set;}
        public string Dialogue{get; private set;}

        public Ghost(string name , string dialogue){
            Name = name ;
            Dialogue = dialogue;


        }

        public void Talk(Player player){
            player.InfoMessage($"{Name} says: \"{Dialogue}");

        }
    }
}