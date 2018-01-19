using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    const string menuHint = "You can type 'Menu' at any time to go back";
    string input;
    string currentState;
    string level;
    string currentScreen;

    void Start()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\WriteLines2");

        // Display the file contents by using a foreach loop.
        Terminal.WriteLine("Contents of WriteLines2.txt = ");
        foreach (string line in lines)
        {
            // Use a tab to indent each line of the file.
            Terminal.WriteLine("\t" + line);
        }

        //ShowMainMenu();
    }

    public void ShowMainMenu()
    {
            Terminal.ClearScreen();
            Terminal.WriteLine("Choose a server from the list; the ");
            Terminal.WriteLine("greater the number, the higher");
            Terminal.WriteLine("the difficulty");
            Terminal.WriteLine("");
            Terminal.WriteLine("Press 001 for ITESM Tam Main Server"); //Cambiaremos todas las califs a 10
            Terminal.WriteLine("Press 002 for Banco de Mexico Server"); //Depositaremos dinero a tu cuenta
            Terminal.WriteLine("Press 003 for Military Zone 51"); //Confirmaremos existencia de aliens
            Terminal.WriteLine("");
            Terminal.WriteLine("Enter the number of the server:");

    }

    public void RunMainMenu(string input)
    {
        bool isValidInput = (input == "1" || input == "2" || input == "3" || 
            input == "01" || input == "02" || input == "03" ||
            input == "001" || input == "002" || input == "003" );

        if (isValidInput)
        {
            level = input;
            AskForPassword();
        } else
        {
            if (input == "007")
            {
                Terminal.WriteLine("Hello, Mr. Bond, please select a server");
            } else
            {
                Terminal.WriteLine("Please choose a valid level");
            }
        }
    }

    private void AskForPassword()
    {
        currentScreen = "Password";
        Terminal.ClearScreen();
        
        Terminal.WriteLine("Enter your password. Hint: "); 
    }
}
