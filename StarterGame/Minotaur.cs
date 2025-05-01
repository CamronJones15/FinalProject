using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterGame
{
    public class Minotaur : Player
    {
        public int AttackPower { get; set; }

        public Minotaur(Room room) : base(room)
        {
            Health = 100;
            AttackPower = 15;
        }

        
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

        private void Attack(Player player)
        {
            player.TakeDamage(this.AttackPower);
        }
    }
}
