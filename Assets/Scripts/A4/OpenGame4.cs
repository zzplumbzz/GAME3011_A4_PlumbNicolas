using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame4 : MonoBehaviour
{
    public GameObject WM2000;
    public TMP_Text TimerTXT;
    public float Timer;
    public bool timerOn = false;
    public GameObject timeCanvas;
    public GameObject game4Canvas;
    public GameObject gameOverCanvas;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject PlayerMovementScript;
    public GameObject Door;

    const string menuHint = "You May Type Menu At Any Time.";
    string[] ELevelPasswords = {"incineroar", "pikachu", "ridley", "mewtwo", "snake", "bayonetta"};
    string[] MLevelPasswords = {"genesis", "xbox360", "dreamcast", "playstation", "turbografix16", "gamecube"};
    string[] HLevelPasswords = {"eldenring", "nierreplicant", "masseffect", "guiltygear", "streetfighter", "tekken"};

    int level;
    enum Screen{MainMenu, Password, Win};
    string password;
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = false;
        WM2000.SetActive(false);
        dialogueBox.SetActive(false);
        game4Canvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        TimerTXT.text = (Timer).ToString("0");

        if(timerOn == true)
        {
            Timer -= Time.deltaTime;
                
        }

        if(timerOn == true && Timer <= 0)
        {
            WM2000.SetActive(false);
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                //game4Canvas.SetActive(true);
                WM2000.SetActive(true);
                ShowMainMenu();
                dialogueBox.SetActive(false);
                
            }
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
        }

        
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Assignment 4!");
        Terminal.WriteLine("Find Out the Password to unlock the door!");
        Terminal.WriteLine("Press 1 for the Easy Level / hint: smash bros characters");
        Terminal.WriteLine("press 2 for the Meduim Level / hint: video game consoles");
        Terminal.WriteLine("press 3 for the Hard Level / hint: video games");
        Terminal.WriteLine("enter your selection");
        Terminal.WriteLine("Type quit, exit or close to close the game");
    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
            timerOn = false;
            Timer = 0;
        }
        else if(input == "quit" || input == "exit" || input == "close")
        {
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
            WM2000.SetActive(false);
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
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();

            if(input == "1")
            {
                StartTimer();
                Timer = 100f;
                timerOn = true;
                
            }

            if(input == "2")
            {
                StartTimer();
                Timer = 75f;
                timerOn = true;
                
            }

            if(input == "3")
            {
                StartTimer();
                Timer = 50f;
                timerOn = true;
                
            }
        }
        else if(input == "1234567890")
        {
            Terminal.WriteLine("Select A Level");
        }
        else 
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    public void StartTimer()
    {
        Timer -= Time.deltaTime;
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
        switch(level)
        {
            case 1:
                password = ELevelPasswords[Random.Range(0, ELevelPasswords.Length)];
                break;
            case 2:
                password = MLevelPasswords[Random.Range(0, MLevelPasswords.Length)];
                break;
            case 3:
                password = HLevelPasswords[Random.Range(0, HLevelPasswords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;

        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
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
        UnlockDoor();
    }

    void UnlockDoor()
    {
        WM2000.SetActive(false);
        Destroy(Door);
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            dialogueActive = true;
            dialogueBox.SetActive(true);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Out Of Range");
            dialogueActive = false;
            dialogueBox.SetActive(false);
            
        }
        
    }
}
