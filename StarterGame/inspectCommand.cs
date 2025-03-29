using System;
using System.Collections.Generic;

namespace StarterGame
{

public class InspectCommand : Command{

    private string _object;

    public InspectCommand(string obj){

        _object = obj
    }

    public void Execute(){
        Console.WriteLine($"You inspect the {_object} something seems odd....")
    }


}
}