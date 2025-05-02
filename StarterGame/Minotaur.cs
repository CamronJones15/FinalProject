using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    //Minotaur class that extends from player class
    public class Minotaur : Player
    {
        public int AttackPower { get; set; }

        public Minotaur(Room room) : base(room)
        {
            Health = 100;
            AttackPower = 15;
        }

        //function that takes an amount of damage as an integer, and reduces that amount from the minotaur's health pool
        public void TakeDamage(int amount, Player player)
        {
            Health -= amount;
            if(Health <= 0)
            {
                NormalMessage("The Minotaur has fallen to your strength");
                player.CurrentRoom.MinotaurInRoom = null;
            }
            else
            {
                WarningMessage($"The Minotaur roars in pain! Health remaining: {Health}");
                Attack(player);
            }
        }

        //attack method that is used as a counter attack when the player attacks the minotaur
        private void Attack(Player player)
        {
            player.TakeDamage(this.AttackPower);
        }
    }
}
