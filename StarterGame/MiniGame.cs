using System.Collections;
using System.Collections.Generic;

namespace StarterGame{

    public enum MiniGameType{
        Starter,
        Birthday,
        Greenhouse,
        Portraits,
        Theater,
        Vanishing,
        Endless,
        BossFight
    }

    public class Minigame{
        
        public Minigame(MiniGameManager minigameManager)
        {
            MiniGameManager manager = minigameManager;
        }

        public void PlayMiniGame(MiniGameType type)
        {
            if (completedMiniGames.Contains(type))
            {
                Console.WriteLine($"You've already completed the minigame in the {type}.");
                return;
            }

            switch(type){

                case MiniGameType.Starter:
                    manager.PlayStarterRoom();
                    break;

                case MiniGameType.Birthday:
                    manager.PlayBirthdayRoom();
                    break;

                case MiniGameType.Greenhouse:
                    manager.PlayGreenhouseRoom();
                    break;

                case MiniGameType.Portraits:
                    manager.PlayHallOfPortraits();
                    break;

                case MiniGameType.Theater:
                    manager.PlayTheaterRoom();
                    break;

                case MiniGameType.Vanishing:
                    manager.PlayerVanishingRoom();
                    break;

                case MiniGameType.Endless: 
                    manager.PlayerEndlessRoom();
                    break;

                case MiniGameType.BossFight:
                    manager.PlayBossFightRoom();
                    break;

                default:
                    Console.WriteLine("Unknown GameRoom?")
                    break;

            }
        }
    }
}