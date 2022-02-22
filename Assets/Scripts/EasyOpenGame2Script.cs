using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EasyOpenGame2Script : MonoBehaviour
{
    public GameObject game2CanvasE;
    public GameObject gameOverCanvas;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public float TimerE;
    public TMP_Text timerEText;
    public GameObject PlayerMovementScript;
    public GameObject doorE;
    public WinEasyScript winE;
    public GameObject centreE;

 
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        game2CanvasE.SetActive(false);
        gameOverCanvas.SetActive(false);

        TimerE = 25f;
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (TimerE <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                game2CanvasE.SetActive(true);
                dialogueBox.SetActive(false);
                centreE.SetActive(true);
                
                
            }
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
        }


        if(game2CanvasE == true)
        {
            TimerE -= Time.deltaTime;
            timerEText.text = (TimerE).ToString("0");
                
        }
        

        if(winE.winE == true)
        {
            Destroy(doorE);
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
        game2CanvasE.SetActive(false);
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
    }
}
