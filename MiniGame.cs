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

    public void EnterRoom(string RoomName){
        Console.WriteLine($"You are now Entering..{RoomName} \n");

        switch(RoomName){

            case "Starter Room:
            manager.PlayStarterRoom();
            break;

            case "Happy Birthday":
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