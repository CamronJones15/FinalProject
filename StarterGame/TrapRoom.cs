using System.Collections;
using System.Collections.Generic;

namespace StarterGame{


    public delegate void TrapEffect(TrapRoom trapRoom)
    public class TrapRoom : Room {

        public bool IsTrapTriggered {get; private set;}
        private TrapEffect _onTrapTriggered; 

        public TrapRoom() : this("a trap room", DefaultTrapEffect){}

        public TrapRoom(string tag, TrapEffect trapEffect) : base(tag){
            IsTrapTriggered = false 
            _onTrapTriggerd = TrapEffect
        }

        public void TriggerTrap(){

            if(!IsTrapTriggered){
                IsTrapTriggered = true;
                _onTrapTriggered?.Invoke(this);
            }
        }

        public string EnterRoom(){
            TriggerTrap();
            return Description();
        }

        public static void DefaultTrapEffect(TrapRoom room){
            Console.WriteLine("You are Trapped!! Play the Mini Game to Move on.")
            room.ClearExits();
        }

        private void ClearExits(){
            //reflection to access and clear the private _exits field in the Room class, effectively removing all exits from the TrapRoom to simulate the player being trapped.
            var exitsField = typeof(Room).getField("_exits," System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if(exitsField !=null){
                exitsField.SetValue(this, new Dictionary<string, TrapRoom>());
            }
        }



    }
}