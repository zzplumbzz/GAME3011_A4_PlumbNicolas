using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame3Easy : MonoBehaviour
{

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject PlayerMovementScript;
    public GameObject gameCanvas3E;
    public GameObject gameOverCanvas;
    public float Timer3E;
    public TMP_Text timer3EText;
    bool timer3EOn;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        gameCanvas3E.SetActive(false);
        gameOverCanvas.SetActive(false);
        Timer3E = 200f;
        timer3EOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(timer3EOn == true)
        {
            Timer3E -= Time.deltaTime;
                
        }
        timer3EText.text = (Timer3E).ToString("0");

        if (Timer3E <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                
                gameCanvas3E.SetActive(true);
                dialogueBox.SetActive(false);
                timer3EOn = true;
                StartTimerE3();
                Timer3E = 200f;
            }
            
           PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
           PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
            
        
            
        }
    }

    private void StartTimerE3()
    {
        if(gameCanvas3E == true)
        {
            timer3EOn = true;

            
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
        gameCanvas3E.SetActive(false);
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
        timer3EOn = false;
    }
}
