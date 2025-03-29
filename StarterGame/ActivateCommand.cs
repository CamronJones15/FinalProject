using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class AcitvateCommand :Command{

        private string _object;

        public AcitvateCommand(string obj){

            _object = obj;

        }

        public void Execute(){

            Console.WriteLine($"You have activated the {_object}")
        }

    }
}
