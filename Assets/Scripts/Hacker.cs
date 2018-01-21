using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    const string menuHint = "\n"+"Type 'menu' at any time to go back";

    string[] level1Pws = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\Passwords1.txt");
    string[] level2Pws = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\Passwords2.txt");
    string[] level3Pws = System.IO.File.ReadAllLines(@"C:\Users\Public\TestFolder\Passwords3.txt");

    int level;
    //Gamestate Win (simple) allow us to restrict the words used in WinScreen to "menu"
    enum GameState { MainMenu, Password, Win1, Win2, Win3, Win}; //3 pantallas de ganar para diferentes acciones
    GameState currentScreen = GameState.MainMenu;

    string password;
    bool changePassword;

    void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {

    }

    void ShowMainMenu()
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

        currentScreen = GameState.MainMenu;
        changePassword = true;
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "exit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("You've been detected. You should run");
            Application.Quit();
        }
        else if (currentScreen == GameState.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == GameState.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == GameState.Win1) //condicion extra para cuando se gana el nivel 1
        {
            HackCalif(input);
        }
        else if (currentScreen == GameState.Win2)
        {
            HackBank(input);
        }
        else if(currentScreen == GameState.Win3)
        {
            HackAlien(input);
        }
    }

    private void HackAlien(string input)
    {
        Terminal.ClearScreen();
        switch (input)
        {
            case "1":
                Terminal.ClearScreen();
                Terminal.WriteLine(
                    "MONTH DAY YEAR   HOUR MIN"+"\n"+
                    " OCT  21  2015  : 11 : 15"+"\n"+
                    "    DESTINATION TIME     "+"\n"+
                    "" +
                    "MONTH DAY YEAR   HOUR MIN"+"\n" +
                    " OCT  26  1985  : 01 : 22"+"\n" +
                    "      PRESENT TIME       "+"\n" +
                    "" +
                    "MONTH DAY YEAR   HOUR MIN" + "\n" +
                    " OCT  26  1985  : 01 : 20" + "\n" +
                    "    LAST TIME DEPARTED   " + "\n" +
                    "");
                
                Terminal.WriteLine(menuHint);
                currentScreen = GameState.Win;
                break;
            case "2":
                Terminal.ClearScreen();
                Terminal.WriteLine(@"
               _,--=--._
             ,'    _    `.
            -    _(_)_o   -
       ____'    /_  _/]    `____
  ====::(+):::::::::::::::::(+)::====
         (+). """""""""""", (+)
             .           ,
               `  -= -' 
Download from www.torproject.org");
                
                currentScreen = GameState.Win;
                Terminal.WriteLine(menuHint);
                break;
            case "3":
                Terminal.ClearScreen();
                Terminal.WriteLine(@"
     _.-^^---....,,--       
 _--                  --_  
<                        >)
|                         | 
 \._                   _./  
    ```--. . , ; .--'''       
          | |   |             
       .-=||  | |=-.   
       `-=#$%&%$#=-'   
          | ;  :|     
 _____.,-#%&$@%#&#~,._____");
                currentScreen = GameState.Win;
                Terminal.WriteLine(menuHint);
                break;
            default:
                Terminal.WriteLine("Select  valid option");
                Terminal.WriteLine(menuHint);
                break;
        }
    }

    private void HackCalif(string input)
    {
        Terminal.WriteLine("Promedio: "+input);
        currentScreen = GameState.Win;
        Terminal.WriteLine(menuHint);
    }

    private void HackBank(string input)
    {
        switch (input) {
            case "1":
                Terminal.WriteLine("El deposito por la cantidad de "+
                    "'Presupuesto Nacional' se ha efectuado");
                Terminal.WriteLine(menuHint);
                currentScreen = GameState.Win;
                break;
            case "2":
                Terminal.WriteLine("El retiro por la cantidad de " + 
                    "'Arcas del Estado' se le entregará en breve");
                Terminal.WriteLine(menuHint);
                currentScreen = GameState.Win;
                break;
            default:
                Terminal.WriteLine("Select  valid option");
                Terminal.WriteLine(menuHint);
                break;
        }
    }

   
    private void CheckPassword(string input) //Metodo modificado para agregar metodos especificos de nivel 
    {
        if (level == 1)
        {
            if (input == password)
            {
                DisplayWinScreen1();
            }
            else
            {
                AskForPassword();
            }
        } else if (level == 2)
        {
            if (input == password)
            {
                DisplayWinScreen2();
            }
            else
            {
                AskForPassword();
            }
        } else if (level == 3)
        {
            if (input == password)
            {
                DisplayWinScreen3();
            }
            else
            {
                AskForPassword();
            }
        }
    }

    private void DisplayWinScreen1()
    {
        currentScreen = GameState.Win1;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void DisplayWinScreen2()
    {
        currentScreen = GameState.Win2;
        Terminal.ClearScreen();
        ShowLevelReward();

    }

    private void DisplayWinScreen3()
    {
        currentScreen = GameState.Win3;
        Terminal.ClearScreen();
        ShowLevelReward();

    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Successful Connection"+"\n");
                Terminal.WriteLine("Bienvenido al Sistema de Calificaciones del ITESM");
                Terminal.WriteLine("Ingrese la calificación que desea para");
                Terminal.WriteLine("todas sus materias: ");
                
                
                
                break;
            case 2:
                Terminal.WriteLine("Successful Connection"+"\n");
                Terminal.WriteLine("Bienvenido al Banco de Mexico, Sr. Carstens " +
                    "Si desea hacer un deposito a su cuenta en " +
                    "Islas Caiman presione 1, si desea retirar " +
                    "presione 2");
                break;
            case 3:
                Terminal.WriteLine("Successful Connection" + "\n");
                Terminal.WriteLine("Area 51 Main Servers." + "\n"
                    + "Only Authorized Personnel can access to this " +
                    "archives."+"\n" +"Select the section you want to visit:");
                Terminal.WriteLine("Press 1 for Time Travelling");
                Terminal.WriteLine("Press 2 for UFO Blueprints");
                Terminal.WriteLine("Press 3 for Nuclear Bombs Program");
                
                break;
            default:
                Debug.LogError("Invalid level. Error 404.");
                break;
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidInput = (input == "1" || input == "2" || input == "3"
            ||
            input == "01" || input == "02" || input == "03" ||
            input == "001" || input == "002" || input == "003");
            
        if (isValidInput)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Hello, Mr. Bond, please select a server");
        }
        else if (input == "1984")
        {
            
            Terminal.WriteLine("War is peace. Freedom is slavery.");
            Terminal.WriteLine("Ignorance is strength.");
            Terminal.WriteLine(@"
        ,-""-.
       / ,--. \
      | ( () ) |
       \ `--' /
        `-..-'  
          
            ");
            
        }
        else
        {
            Terminal.WriteLine("That is not a valid server.");
            Terminal.WriteLine("Be careful on what you do");
        }
    }


    private void AskForPassword()
    {
        currentScreen = GameState.Password;
        Terminal.ClearScreen();
        if (changePassword)
        {
            SetRandomPassword();
        }
        Terminal.WriteLine("Enter the password. Hint: ");
        Terminal.WriteLine(password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        changePassword = false;

        switch (level)
        {
            case 1:
                password = level1Pws[UnityEngine.Random.Range(0, level1Pws.Length)];
                break;
            case 2:
                password = level2Pws[UnityEngine.Random.Range(0, level2Pws.Length)];
                break;
            case 3:
                password = level3Pws[UnityEngine.Random.Range(0, level3Pws.Length)];
                break;
            default:
                Debug.LogError("That´s not a valid level. Be careful");
                Debug.LogError("on what you do");
                changePassword = true;
                break;
        }
    }

    

    

    

    



   
}
