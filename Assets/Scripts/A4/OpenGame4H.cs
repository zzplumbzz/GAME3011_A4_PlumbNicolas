using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame4H : MonoBehaviour
{
    public GameObject game4HCanvas;
    public GameObject gameOverCanvas;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject PlayerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        game4HCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                game4HCanvas.SetActive(true);
                dialogueBox.SetActive(false);
                
            }
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
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