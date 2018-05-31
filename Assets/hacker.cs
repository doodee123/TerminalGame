﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour {
    string greeting = "Hello JP";
    int level;

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
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
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
        if (level == 1)
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

    }

    void OnPasswordInput(string password)
    {
        if (level == 1 && password == "Donkey")
        {
            Terminal.WriteLine("Welcome to the computer!");
        }
        else if (level == 2 && password == "Kim")
        {
            Terminal.WriteLine("Welcome to the computer!");
        }
        else
        {
            Terminal.WriteLine("Bad Password, Please try again.");
        }
    }
}
