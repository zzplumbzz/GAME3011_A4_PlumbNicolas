using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame3Hard : MonoBehaviour
{

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject PlayerMovementScript;
    public GameObject gameCanvas3H;
    public GameObject gameOverCanvas;
    public float Timer3H;
    public TMP_Text timer3HText;
    bool timer3HOn;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        gameCanvas3H.SetActive(false);
        gameOverCanvas.SetActive(false);
        Timer3H = 120f;
        timer3HOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(timer3HOn == true)
        {
            Timer3H -= Time.deltaTime;
                
        }
        timer3HText.text = (Timer3H).ToString("0");

        if (Timer3H <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                
                gameCanvas3H.SetActive(true);
                dialogueBox.SetActive(false);
                timer3HOn = true;
                
                Timer3H = 120f;
            }
            
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
            
        
            
        }
    }

    private void StartTimer3H()
    {
        if(gameCanvas3H == true)
        {
            timer3HOn = true;

            
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
        gameCanvas3H.SetActive(false);
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
        timer3HOn = false;
    }
}
