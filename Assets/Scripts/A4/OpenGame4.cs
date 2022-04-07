using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame4 : MonoBehaviour
{
    public GameObject WM2000;
    public GameObject game4Canvas;
    public GameObject gameOverCanvas;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject PlayerMovementScript;
    public GameObject Door;

    const string menuHint = "You May Type Menu At Any Time.";
    string[] level1Passwords = {"apple", "banana", "orange", "pear", "grape", "kiwi"};
    string[] level2Passwords = {"chad", "stacy", "kyle", "karen", "larry", "ricky"};
    string[] level3Passwords = {"unicorn", "sasquatch", "lockness", "chupicabra", "gremlin", "chucky"};

    int level;
    enum Screen{MainMenu, Password, Win};
    string password;
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        
        WM2000.SetActive(false);
        dialogueBox.SetActive(false);
        game4Canvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        Terminal.WriteLine("Press 1 for level 1");
        Terminal.WriteLine("press 2 for level 2");
        Terminal.WriteLine("press 3 for level 3");
        Terminal.WriteLine("enter your selection");
    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(input == "quit" || input == "exit" || input == "close")
        {
            Terminal.WriteLine("If on the web close the tab");
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
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
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
