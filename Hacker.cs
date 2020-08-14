using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
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

    public string Password { get => Password1; set => Password1 = value; }
    public string Password1 { get => password; set => password = value; }


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
            Password = lvl1Passwords[0]; // TODO make random password later
            StartGame();
        }
        else if(input == "2")
        {
            level = 2;
            Password = lvl2Passwords[1]; // TODO make random later
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
            if (input == Password)
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
