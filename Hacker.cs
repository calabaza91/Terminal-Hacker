using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game State
    int level;
    enum Screen {MainMenu, Password, Win}; //enum is a list type that is used to control the game state
    Screen currentScreen = Screen.MainMenu;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
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
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
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
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter your passweord: ");
    }

}
