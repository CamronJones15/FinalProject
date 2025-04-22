using System.Collections;
using System.Collections.Generic;

namespace StarterGame{

    public class MiniGameManager{
        Player player;
        public MiniGameManager(Player _player){
            player = _player;
        }

        public void PlayStarterRoom(){
            player.NormalMessage("John: Ah, you're finally here.");
            player.NormalMessage("Welcome to the Beginning — or is it the end? Hard to tell in a place like this.");
            player.NormalMessage("This room is safe... for now. Look around. Take what you can. Trust what you must.");
            player.NormalMessage("Every room ahead holds a truth, a test, and maybe a little terror.");
            player.NormalMessage("You're 21 now, aren't you? A good age to learn what fear really feels like.");
            player.NormalMessage("Light the candles… or don’t. The escape begins when you decide it does.");
            player.NormalMessage("Good luck, birthday soul. You’ll need it.");
        }

        public void PlayBirthdayRoom(){
            Console.Clear();
            player.NormalMessage("John");
            player.NormalMessage("Happy Birthday, dear friend...");
            player.NormalMessage("You’re finally 21. A beautiful age — old enough to celebrate, young enough to make mistakes.");
            player.NormalMessage("And perhaps... one of them was walking into this room.");
            player.NormalMessage("Do you like cake?");
            player.NormalMessage("There's one waiting just for you.");
            player.NormalMessage("Candles flicker, time ticks, and the door... well, it’s locked.");
            player.NormalMessage("Maybe... just maybe... if you blow out the candles, you’ll find your way out.");
            player.NormalMessage("Or maybe you'll... stay here with me... forever. ");
            player.InfoMessage("Instructions:");
            player.InfoMessage("Blow out the candles to reveal a secret code.");
            player.InfoMessage("You’ll need that code — in the correct order — to unlock the door.");
            player.InfoMessage("If you choose not to blow them out... well, your time might run out faster than you think.");

            player.WarningMessage("Do you want to blow the candles out? [yes/no]");
            string input = Console.WriteLine()?.tolower();

            if(input == "yes"){
                string reversedCode = "08217";
                Console.WriteLine("\n The Candles go out.... On the Cake an Code appears");
                Console.WriteLine("->" + reversedCode);

                Console.WriteLine("\nEnter the code in the correct order to unlock the door.");
                Console.WriteLine("Hint: Sometimes... the truth is revealed in reverse.");

                string correctCode = "17820";
                int timeLeft = 15;

                while(timeLeft > 0){
                    Console.WriteLine($"\n Time Left.. {timeLeft} Seconds");
                    Console.Write("Enter the Code...");
                    string attempt = Console.ReadLine();

                    if(attempt = correctCode){
                        Console.WriteLine("Congrats!! You have escaped the room!!");
                        return;
                    }
                    timeLeft -= 5;
                    if(timeLeft > 0){
                        Console.WriteLine("Wrong Code!! Try Again..");
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
            Console.WriteLine("Something waits beneath.");
            Console.WriteLine("Something meant to be found.");
            //Finishing GreenHouse and Doing the Hall of Potraits next//
            Console.WriteLine("You are surrounded by:");
            Console.WriteLine("A stone fountain in the center (strangely rhythmic dripping sound).");
            Console.WriteLine("A patch of lilies (identical to the potted lily from a previous room).");
            Console.WriteLine("Sunflowers and roses blooming in impossible perfection.");
            Console.WriteLine("A small pond in the far corner, where koi fish drift lazily in slow circles.");
            Console.WriteLine("The air is thick with silence.\n");

            Console.WriteLine("Do you want to dig up the patch of lilies? [yes/no]");
            string digChoice = Console.ReadLine().Trim().lower();

            if(digChoice == yes){
                Console.WriteLine("\nYou kneel beside the lilies — they don't resist your touch.");
                Console.WriteLine("As your hands dig into the dirt, the soil parts too easily.");
                Console.WriteLine("Beneath the surface, something hard... cold... metal.");
                Console.WriteLine("You uncover a chest.\n");

                Console.WriteLine("Inside lies an odd item: a fishing pole... but not for catching fish.");
                Console.WriteLine("At the end of the line: a magnet.\n");

                Console.WriteLine("John whispers:");
                Console.WriteLine("\"Not everything in this room belongs to the earth... some things sink below.");
                Console.WriteLine("And what sinks... must be drawn up.\"\n");

                Console.WriteLine("Use the magnetic fishing pole on the pond? (yes/no)");
                string fishChoice = Console.ReadLine().Trim().ToLower();

                if(fishChoice == yes){
                    Console.WriteLine("\nYou lower the magnet into the pond.");
                    Console.WriteLine("It glides past koi, past silt... and then — clink.");
                    Console.WriteLine("The pole jerks. You pull it up.");
                    Console.WriteLine("A rusted key clings to the magnet.\n");

                    Console.WriteLine("John murmurs:");
                    Console.WriteLine("\"It’s not the water that hides things... it’s the stillness.");
                    Console.WriteLine("Take the key. The door to the next room waits.\"\n");
                }
                else{
                    Console.WriteLine("You decide not to use the pole right now.\n");
                }
                else{
                    Console.WriteLine("You leave the lilies undisturbed. Perhaps another clue awaits elsewhere.\n");
                }
            }

        }

        public void PlayHallOfPortraits(){
            Console.WriteLine("Reign whispers:\n\"Step lightly...\"");
            Console.WriteLine("You’ve entered The Hall of Portraits — a place where time stands still...");
            Console.WriteLine("…and the eyes of the past never stop watching.\n");

            Console.WriteLine("As the door seals behind you, candlelight flickers to life, casting long shadows on the faces of ten painted souls.");
            Console.WriteLine("Their eyes... follow.\n");

            Console.WriteLine("At the far end of the hall, a locked door waits.");
            Console.WriteLine("Beside it, a golden plaque reads:");
            Console.WriteLine("\"Only the one who does not belong shall set you free.\"\n");

            Console.WriteLine("Reign whispers again: \"Nine have their time… One does not belong.\"\n");

            Console.WriteLine("The 10 Portraits:");
            Console.WriteLine("1. The Noblewoman (1682)");
            Console.WriteLine("2. The Soldier (1805)");
            Console.WriteLine("3. The Twins (1901)");
            Console.WriteLine("4. The Scholar (1750)");
            Console.WriteLine("5. The Widow (1857)");
            Console.WriteLine("6. The Merchant (1603)");
            Console.WriteLine("7. The Jester (1400s)");
            Console.WriteLine("8. The Farmer (1720)");
            Console.WriteLine("9. The Duchess (1660)");
            Console.WriteLine("10. The Stranger (Unknown Date)\n");

            int attempts = 3;
            string correctAnswer = "The Stranger";

            while (attempts > 0)
            {
                Console.WriteLine($"Puzzle Prompt: Which portrait does not belong? ({attempts} attempts left)");
                Console.WriteLine("Type the name exactly (e.g., \"The Jester\"):");
                string guess = Console.ReadLine().Trim();

                if (guess.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nYou speak the name aloud... and silence follows.");
                    Console.WriteLine("A click. The locked door creaks open.");
                    Console.WriteLine("\nReign whispers:");
                    Console.WriteLine("\"Very good... you see through the lies of time. The Stranger was never one of us.\"");
                    Console.WriteLine("\"Proceed — but know the eyes never truly stop watching.\"\n");
                    return;
                }
                else
                {
                    attempts--;
                    if (attempts > 0)
                    {
                        Console.WriteLine($"\nReign hisses from the shadows...");
                        Console.WriteLine($"\"Wrong answer... {attempts} attempt{(attempts == 1 ? "" : "s")} remain. Choose carefully.\"\n");
                    }
                    else
                    {
                        Console.WriteLine("\nSuddenly, every portrait’s mouth opens in a silent scream.");
                        Console.WriteLine("The candles extinguish all at once.");
                        Console.WriteLine("\nGAME OVER.");
                        Console.WriteLine("Restarting Hall of Portraits...\n");
                    }
                }
            }
        }

        public void PlayVanishingRoom(){
            Console.WriteLine("The room is dark and cold with only one source of light..");
            Console.WriteLine("As you approach the source of the light you see an old CRT screen with a keyboard in front.");
            Console.WriteLine("The screen reads: 'Vanishing Phrases are going to pop up with missing letters in a sentence. You must type in the entire phrase including the missing letters onto the keyboard. Press enter when ready'");
            Console.WriteLine("As you hit enter, the screen goes black. For a second a phrase quickly appears then vanishes a few moments later..");
            Console.WriteLine("You quickly catch the phrase: 'TH NLY THNG W HV T FR S FR TSLF'");
            Console.WriteLine("The screen then reads: 'please enter the full phrase'");
            int attempts = 3;
            string correctAnswer = "THE ONLY THING WE HAVE TO FEAR IS FEAR ITSELF";
            while(attempts > 0){
                string attemptedAnswer = Console.ReadLine();
                if(attemptedAnswer.Equals(correctAnswer)){
                    Console.WriteLine("The screen reads: 'You have entered the correct phrase. Well done! Onto the next phrase'");
                    break;
                }else{
                    attempts--;
                    Console.WriteLine($"The screen reads: 'You have entered the phrase incorrectly... {attempts} attempts remain...");
                }
            }
            Console.WriteLine("You quickly catch the next phrase: 'Y CNT CHNGR WH CHNGS Y BT Y CN CHS HW Y RSPND'");
            Console.WriteLine("The screen then reads: 'please enter the full phrase'");
            correctAnswer = "YOU CANT CHANGE WHAT CHANGES YOU, BUT YOU CAN CHOOSE HOW YOU RESPOND";
            attempts = 3;
            while(attempts > 0){
                string attemptedAnswer = Console.ReadLine();
                if(attemptedAnswer.Equals(correctAnswer)){
                    Console.WriteLine("The screen reads: 'You have entered the correct phrase. Well done! Onto the next phrase'");
                    break;
                }else{
                    attempts--;
                    Console.WriteLine($"The screen reads: 'You have entered the phrase incorrectly... {attempts} attempts remain...");
                }
            }
            Console.WriteLine("You quickly catch the next phrase: 'MSSNG VWLS PZZL'");
            Console.WriteLine("The screen then reads: 'please enter the full phrase'");
            correctAnswer = "MISSING VOWELS PUZZLE";
            attempts = 3;
            while(attempts > 0){
                string attemptedAnswer = Console.ReadLine();
                if(attemptedAnswer.Equals(correctAnswer)){
                    Console.WriteLine("The screen reads: 'You have entered the correct phrase. Well done! Onto the next phrase'");
                    break;
                }else{
                    attempts--;
                    Console.WriteLine($"The screen reads: 'You have entered the phrase incorrectly... {attempts} attempts remain...");
                }
            }
        }
    }
}
