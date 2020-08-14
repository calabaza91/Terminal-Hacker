using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game State
    int level;
    string[] passwords = {"book", "badge", "biology", "dubious", "mononucleosis"};
    // TODO add for helping human succeed
    string[] hint1;
    string[] hint2;
    enum Screen {MainMenu, Password, Win}; //enum is a list type that is used to control the game state
    Screen currentScreen;
    string password;
    string guess;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

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
        if(input == "1")
        {
            level = 1;
            password = passwords[0];
            StartGame();
        }
        else if(input == "2")
        {
            level = 2;
            password = passwords[1];
            StartGame();
        }
            
        else if(input == "411")
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
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter your password: ");

       
    }

    void CheckPassword(string input)
    {
            if (input == password)
            {
                Terminal.WriteLine("Good job!");
                Terminal.WriteLine("Type 'menu' to choose a new level.");
            }
            else
            {
                Terminal.WriteLine("Incorrect. Guess again, human.");

            }
    }
    
}
