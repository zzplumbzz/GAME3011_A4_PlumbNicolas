using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame1Script : MonoBehaviour
{
    PlayerMovementScript PMS;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject gameCanvas;
    
    void Start()
    {


        dialogueBox.SetActive(false);
       // dialogueActive = false;
        gameCanvas.SetActive(false);

        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            

            if (dialogueBox.activeInHierarchy)
            {
                gameCanvas.SetActive(true);
                dialogueBox.SetActive(false);
                
            }

            if(gameCanvas == true)
            {
                PMS.canMove = false;
            }
            else
            {
                PMS.canMove = true;
            }
            
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
}
