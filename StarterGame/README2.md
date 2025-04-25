


MINI GAME IDEA/EXAMPLE 




Step 1: Define an Event for Player Input
Add this to Player:


public class Player {
    public event Action<string> OnInputReceived;

    public void SubmitInput(string input){
        OnInputReceived?.Invoke(input);
    }

    public void NormalMessage(string msg) => Console.WriteLine(msg);
    public void InfoMessage(string msg) => Console.WriteLine("[INFO] " + msg);
    public void WarningMessage(string msg) => Console.WriteLine("[WARNING] " + msg);
}
Now instead of ReadLine, you can call player.SubmitInput("YOUR_INPUT") from anywhere (e.g., UI or test harness).



Step 2: Structure the Minigame to Listen for Input
Here's a refactored PlayVanishingRoom using the observer pattern:


public bool PlayVanishingRoom(){
    string[] prompts = {
        "TH NLY THNG W HV T FR S FR TSLF",
        "Y CNT CHNGR WH CHNGS Y BT Y CN CHS HW Y RSPND",
        "MSSNG VWLS PZZL"
    };

    string[] answers = {
        "THE ONLY THING WE HAVE TO FEAR IS FEAR ITSELF",
        "YOU CANT CHANGE WHAT CHANGES YOU, BUT YOU CAN CHOOSE HOW YOU RESPOND",
        "MISSING VOWELS PUZZLE"
    };

    int currentPhrase = 0;
    int attempts = 3;
    bool gameComplete = false;

    void HandleInput(string input){
        if(input.ToUpper() == answers[currentPhrase]){
            player.InfoMessage("Correct!");
            currentPhrase++;
            attempts = 3;

            if(currentPhrase < prompts.Length){
                player.InfoMessage($"Next phrase: {prompts[currentPhrase]}");
                player.InfoMessage("Type the full phrase.");
            } else {
                player.InfoMessage("You have completed the Vanishing Room!");
                gameComplete = true;
                player.OnInputReceived -= HandleInput; // Unsubscribe
            }
        } else {
            attempts--;
            player.WarningMessage($"Incorrect... {attempts} attempts remaining.");
            if(attempts == 0){
                player.WarningMessage("Game Over. Restarting Vanishing Room...");
                player.OnInputReceived -= HandleInput;
            }
        }
    }

    // Begin minigame
    player.OnInputReceived += HandleInput;
    player.InfoMessage($"Vanishing Room begins...");
    player.InfoMessage($"First phrase: {prompts[currentPhrase]}");
    player.InfoMessage("Type the full phrase.");

    // Return false — the minigame will finish *later* after input
    return false;
}


Step 3: Hook into Your MiniGameManager Flow
Since the minigame now finishes asynchronously, your RunMiniGame can listen for completion:


public void RunMiniGame(string name){
    if(miniGames.ContainsKey(name)){
        bool completed = false;
        MiniGame game = miniGames[name];

        completed = game.Invoke();
        if (!completed){
            player.InfoMessage("This challenge must be completed before moving on...");
            // Let the input observer handle the rest
        }
    } else {
        Console.WriteLine($"MiniGame '{name}' not found.");
    }
}
🔁 Simulate Input (for testing)

player.SubmitInput("THE ONLY THING WE HAVE TO FEAR IS FEAR ITSELF");
player.SubmitInput("YOU CANT CHANGE WHAT CHANGES YOU, BUT YOU CAN CHOOSE HOW YOU RESPOND");
player.SubmitInput("MISSING VOWELS PUZZLE");

🧠 Summary
Input is now reactive: the game "listens" for it via an event.

You can simulate input externally (great for UI or testing).

You can reuse this system across all minigames.

