using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    const string menuHint = "Type 'menu' to choose a new level.";
    string[] lvl1Passwords = { "book", "librarian", "biology", "selfhelp", "literature" };
    string[] lvl2Passwords = { "shakespeare", "jazz", "chicago", "monologue", "technique" };
    string[] lvl3Passwords = { "disney", "mousekateer", "starwars", "master", "hivemind" };

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
        Terminal.WriteLine("Press 2 for the theatre");
        Terminal.WriteLine("Press 3 for Disney World");
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
        bool isValidLevelNum = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNum)
        {
            level = int.Parse(input); // Change string into integer
            AskForPassword();
        }
        else if (input == "411")
        {
            Terminal.WriteLine("What's the Disney 411?");  // Easter egg
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                Password = lvl1Passwords[Random.Range(0, lvl1Passwords.Length)];
                break;
            case 2:
                Password = lvl2Passwords[Random.Range(0, lvl2Passwords.Length)];
                break;
            case 3:
                Password = lvl3Passwords[Random.Range(0, lvl3Passwords.Length)];
                break;
            default:
                Debug.LogError("I don't know you!");
                break;
        }
    }

    void CheckPassword(string input)
    {
            if (input == Password)
        {
            DisplayWinScreen();
            Terminal.WriteLine(menuHint);
        }
        else
            {
            AskForPassword();

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
                Terminal.WriteLine(@"
    _______
   /      //
  /  <3  //
 /______// 
(______(/
"               );
                break;
            case 2:
                Terminal.WriteLine(@"
　 　　　＿＿＿_
　　　／　　 　 　＼
　 ／　  ──　  　── ＼   -- MHMM MHMM
 ／ 　　 （ ●）  （ ●）＼      Good job!
|　 　　 　 （__人__）  |
./　　　　 ∩ノ ⊃　　 ／
(　 ＼　／ ＿ノ |　 |
.＼　“　　／＿＿|   |
　　＼ ／＿＿＿＿＿／
"               );
                break;
            case 3:
                Terminal.WriteLine(@"
  .- -.         .- ---.
 /     \ _____ /       \
 \      `     `        /
  `--/, '^^'. '^^',\--` 
    || / ^\    / ^\ |\  -- Haha! You're gonna pay
    |\ | ● | _ | ●| /|        for this!
    \_\`~` .-.`~`/ _ /
    /      '-'       \
    \  `-, ..., -`  /
      '-._ \^/ _.-'
");
                break;
            default:
                Debug.LogError("I AM ERROR.");
                break;
        }
        
    }
}
