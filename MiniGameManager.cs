using System.Collections;
using System.Collections.Generic;

namespace StarterGame{

    public class MinigameManager{

        public void PlayStarterRoom(){
        Console.WriteLine("John: Ah, you're finally here.");
        Console.WriteLine("Welcome to the Beginning — or is it the end? Hard to tell in a place like this.");
        Console.WriteLine("This room is safe... for now. Look around. Take what you can. Trust what you must.");
        Console.WriteLine("Every room ahead holds a truth, a test, and maybe a little terror.");
        Console.WriteLine("You're 21 now, aren't you? A good age to learn what fear really feels like.");
        Console.WriteLine("Light the candles… or don’t. The escape begins when you decide it does.");
        Console.WriteLine("Good luck, birthday soul. You’ll need it.");
        }

        public void PlayBirthdayRoom(){
            Console.Clear();
            Console.WriteLine("John");
            Console.WriteLine("Happy Birthday, dear friend...");
            Console.WriteLine("You’re finally 21. A beautiful age — old enough to celebrate, young enough to make mistakes.");
            Console.WriteLine("And perhaps... one of them was walking into this room.");
            Console.WriteLine("Do you like cake?");
            Console.WriteLine("There's one waiting just for you.");
            Console.WriteLine("Candles flicker, time ticks, and the door... well, it’s locked.");
            Console.WriteLine("Maybe... just maybe... if you blow out the candles, you’ll find your way out.");
            Console.WriteLine("Or maybe you'll... stay here with me... forever. ");
            Console.WriteLine("Instructions:");
            Console.WriteLine("Blow out the candles to reveal a secret code.");
            Console.WriteLine("You’ll need that code — in the correct order — to unlock the door.");
            Console.WriteLine("If you choose not to blow them out... well, your time might run out faster than you think.");
            
            Console.WriteLine("Do you want to blow the candles out? [yes/no]")
            string input = Console.WriteLine()?.tolower();

            if(input == yes){
                string reversedCode = "08217";
                Console.WriteLine("\n The Candles go out.... On the Cake an Code appears");
                Console.WriteLine("->" + reversedCode);

                Console.WriteLine("\nEnter the code in the correct order to unlock the door.");
                Console.WriteLine("Hint: Sometimes... the truth is revealed in reverse.");

                string correctCode = "17820"
                int timeLeft = 15;

                while(timeLeft > 0){
                    Console.WriteLine($"\n Time Left.. {timeLeft} Seconds")
                    Console.Write("Enter the Code...")
                    string attempt = Console.ReadLine();

                    if(attempt = correctCode){
                        Console.WriteLine("Congrats!! You have escaped the room!!")
                        return;
                    }
                    timeLeft -= 5;
                    if(timeLeft > 0){
                        Console.WriteLine("Wrong Code!! Try Again..")
                    }
                      Console.WriteLine("\nBOOM! The candles weren't just candles...");
                      Console.WriteLine("Game Over. Restarting...");
                }
                else{
                    Console.WriteLine("\nThe candles flicker... and time ticks down...");
                    Console.WriteLine("The room explodes in a burst of confetti and flame.");
                    Console.WriteLine("Game Over.");

            }
        }
    }

    public void PlayGreenhouseRoom(){
        Console.WriteLine("John");
        Console.WrtieLine("Ah... welcome to the Greenhouse.");
        Console.WriteLine("A place where life thrives...");
        Console.WriteLine("And yet, nothing here breathes.");
        Console.WriteLine("The door slams shut behind you. The outside world fades.");
        Console.WriteLine("The grass beneath you cushions your step.");
        Console.WriteLine("The fountain trickles... not with rhythm, but with warning.");
        Console.WritesLine("You notice them, don’t you?");
        Console.WriteLine("The lilies… like the one you saw before.");
        Console.WriteLine("That was no accident. This is no coincidence.");
        Console.WriteLine("Something waits beneath.")
        Console.WriteLine("Something meant to be found.")
        //Finishing GreenHouse and Doing the Hall of Potraits next//

    }
}
}