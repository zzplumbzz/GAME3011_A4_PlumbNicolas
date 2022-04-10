using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RobotDialogue : MonoBehaviour
{
    public GameObject NPCdialogueBox;
    public TMP_Text NPCdialogueText;
    public TMP_Text NPCdialogue;
    public bool NPCdialogueActive;

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;

void Start()
{
    NPCdialogueActive = false;
    NPCdialogueBox.SetActive(false);
}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && NPCdialogueActive)
        {
            if (NPCdialogueBox.activeInHierarchy)
            {
                NPCdialogueBox.SetActive(false);

                
            }
            else
            {
                dialogueActive = false;
            dialogueBox.SetActive(false);
                NPCdialogueBox.SetActive(true);
                NPCdialogueText = NPCdialogue;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            
            Debug.Log("Player in range");
            NPCdialogueActive = true;

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
            NPCdialogueActive = false;
            NPCdialogueBox.SetActive(false);

            Debug.Log("Player in range");
            dialogueActive = false;
            dialogueBox.SetActive(false);
        }
    }
}
