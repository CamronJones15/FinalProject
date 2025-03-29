using System;
using System.Collections.Generic;
using StarterGame;

namespace StarterGame
{
    public class AttackCommand : Command{

        private string _enemy;
        private Inventory _inventory;

        public AttackCommand(string enemy, Inventory inventory){
            _enemy = enemy;
            _inventory = inventory;
        }
        public void Execute(){
            List<Item> weapons = _inventory.GetWeapons();
            if(weapons.Count == 0)
            {
                Console.WriteLine($"You cannot attack {_enemy} with no weapons!!");
                return;
            }
            Console.WriteLine($"Choose a weapon to attack {_enemy}:");
            for (int i = 0; i < weapons.Count; i++){
                Console.WriteLine($"{i + 1}. {weapons[i].Name}");

            }

            Console.Write("Enter the number of your choice:");
            string input = Console.ReadLine();

        if (int.TryParse(input, out int choice) && choice > 0 && choice <= weapons.Count)
        {
            Item selectedWeapon = weapons[choice - 1];
            Console.WriteLine($"You swing your {selectedWeapon.Name} at the {_enemy} and deal damage!");
        }
        else
        {
            Console.WriteLine("Invalid choice! You hesitate and miss your attack.");
        }
    }
        }

    }
