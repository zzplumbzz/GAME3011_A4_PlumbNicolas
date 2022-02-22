using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame2Script : MonoBehaviour
{

    public GameObject game2Canvas;
    public GameObject gameOverCanvas;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public float Timer;
    public TMP_Text timerText;
    public GameObject PlayerMovementScript;
    public GameObject doorM;
    public WinGame2Script winS;

    public GameObject centre;

    
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        game2Canvas.SetActive(false);
        gameOverCanvas.SetActive(false);

        

        Timer = 20f;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Timer <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                game2Canvas.SetActive(true);
                dialogueBox.SetActive(false);
               
                centre.SetActive(true);

                
               // Timer -= Time.deltaTime;
               // timerText.text = (Timer).ToString("0");
              
            }
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
        }

        if(game2Canvas == true)
        {
            Timer -= Time.deltaTime;
                timerText.text = (Timer).ToString("0");
        }
       
        
        if(winS.win == true)
        {
            Destroy(doorM);
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
       PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
        }
        
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

    public void QuitButtonPressed()
    {
        game2Canvas.SetActive(false);
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
       PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
    }
}
