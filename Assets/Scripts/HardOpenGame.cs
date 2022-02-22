using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HardOpenGame : MonoBehaviour
{
    public GameObject game2CanvasH;
    public GameObject gameOverCanvas;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public float TimerH;
    public TMP_Text timerHText;
    public GameObject doorH;
     public GameObject PlayerMovementScript;
    public WinHardScript winH;
      
    public GameObject centreH;
    //public GameObject playerStartPos;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        game2CanvasH.SetActive(false);
        gameOverCanvas.SetActive(false);

        TimerH = 15f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (TimerH <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                game2CanvasH.SetActive(true);
                dialogueBox.SetActive(false);
                centreH.SetActive(true);

                
            }
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
        }

        if(game2CanvasH == true)
        {
            TimerH -= Time.deltaTime;
                timerHText.text = (TimerH).ToString("0");
        }
        

        if(winH.winH == true)
        {
            Destroy(doorH);
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
            
            centreH.SetActive(true);
            
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
        game2CanvasH.SetActive(false);
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
       PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
    }
}
