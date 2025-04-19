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
    private MinigameManager manager;

    public Minigame(MinigameManager minigameManager)
    {
        manager = minigameManager;
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
            manager.BirthdayRoom();
            break;

            case MiniGameType.Greenhouse:
            PlayGreenhouseRoom();
            break;

            case MiniGameType.Portraits:
            PlayPortraitsRoom();
            break;

            case MiniGameType.Theater:
            PlayTheaterRoom();
            break;

            case MiniGameType.Vanishing:
            PlayerVanishingRoom();
            break;

            case MiniGameType.Endless: 
            PlayerEndlessRoom();
            break;

            case MiniGameType.BossFight:
            PlayBossFightRoom();
            break;

            default:
            Console.WriteLine("Unknown GameRoom?")
            break;

        }

    
}
}
}