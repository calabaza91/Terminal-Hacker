using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    string[] lvl1Passwords = { "book", "badge", "biology", "dubious", "mononucleosis" };
    string[] lvl2Passwords = { "hygge", "jazz", "chicago", "mousekateer", "fortnight" };

    // TODO add for helping human succeed
    string[] hint1;
    string[] hint2;

    // Game State
    int level;
    enum Screen {MainMenu, Password, Win}; //enum is a list type that is used to control the game state
    Screen currentScreen;
    string password;
    string guess;

    public string Password { get => password; set => password = value; }


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    //Use Update to check is Random.Range is working
    /*
    void Update()
    {
        int index = Random.Range(0, lvl1Passwords.Length);
        print(index);
    }
    */
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello, Human.");
        Terminal.WriteLine("What would you like to hack with me?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
    }

    // this only decides who to handle input, not actually do it
    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNum = (input == "1" || input == "2");
        if (isValidLevelNum)
        {
            level = int.Parse(input); // Change string into integer
            StartGame();
        }
        else if (input == "411")
        {
            Terminal.WriteLine("What's the Disney 411?");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                Password = lvl1Passwords[Random.Range(0, lvl1Passwords.Length); // TODO make random password later
                break;
            case 2:
                Password = lvl2Passwords[Random.Range(0, lvl2Passwords.Length); // TODO make random password later
                break;
            default:
                Debug.LogError("I don't know you!");
                break;
        }
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter your password: ");

       
    }

    void CheckPassword(string input)
    {
            if (input == Password)
        {
            DisplayWinScreen();
            Terminal.WriteLine("Type 'menu' to choose a new level.");
        }
        else
            {
                Terminal.WriteLine("Incorrect. Guess again, human.");

            }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                break;
        }
        
    }
}
