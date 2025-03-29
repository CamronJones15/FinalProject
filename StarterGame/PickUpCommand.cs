using System;
using System.Collections.Generic;

namespace StarterGame{

    public class PickUpCommand : Command {

        private string item;

        public PickUpCommand (string item){

            _item = item; 
        }

        public void Execute(){

            Console.WriteLine($"You picked up the{_item}.")
            
        }
    }

    

}