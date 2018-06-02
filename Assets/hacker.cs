using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour {

    // Game configuration data

    string[] level1Passwords = {"police", "handcuffs", "siren", "jail", "detective", "doughnuts"};
    string[] level2Passwords = { "kim", "nukes", "northkorea", "missile", "dmz", "lonely" };

    // Game State
    string greeting = "Hello JP";
    int level;
    string password = "";

    enum Screen { MainMenu, Password, Win};
    Screen currentScreen = Screen.Password;

    // Use this for initialization
    void Start () {
        ShowMainMenu(greeting);
    }

    void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine(" ");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Press 1 for Police Department");
        Terminal.WriteLine("Press 2 for DKPR");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Enter your selection: ");
        currentScreen = Screen.MainMenu;
    }

    
	void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu("Welcome back!");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            OnPasswordInput(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "menu")
        {
            ShowMainMenu("Welcome back!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();

        switch(level)
        {
            case 1:
                password = level1Passwords[2];
                Terminal.WriteLine("Welcome to the ");
                Terminal.WriteLine("Burbank Police Department.");
                Terminal.WriteLine("Please enter your password:");
                break;

            case 2:
                password = level2Passwords[2];
                Terminal.WriteLine("Welcome to the DKPR.");
                Terminal.WriteLine("Please enter your password:");
                break;

            default:
                Debug.LogError("Invalid level number");
                break;
        }


 /*       if (level == 1)
        {
            Terminal.WriteLine("Welcome to the ");
            Terminal.WriteLine("Burbank Police Department.");
            Terminal.WriteLine("Please enter your password:");
        }
        else if (level == 2)
        {
            Terminal.WriteLine("Welcome to the DKPR.");
            Terminal.WriteLine("Please enter your password:");
        }
*/
    }

    void OnPasswordInput(string entry)
    {
        if (level == 1 && entry == password)
        {
            Terminal.WriteLine("Welcome to the Police computer!");
        }
        else if (level == 2 && entry == password)
        {
            Terminal.WriteLine("Welcome to the DKPR computer!");
        }
        else
        {
            Terminal.WriteLine("Bad Password, Please try again.");
        }
    }
}
