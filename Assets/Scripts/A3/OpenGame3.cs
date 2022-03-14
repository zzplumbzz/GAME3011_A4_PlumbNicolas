using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame3 : MonoBehaviour
{

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject PlayerMovementScript;
    public GameObject gameCanvas3;
    public GameObject gameOverCanvas;
    public float Timer3;
    public TMP_Text timer3Text;
    bool timer3On;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        gameCanvas3.SetActive(false);
        gameOverCanvas.SetActive(false);
        Timer3 = 160f;
        timer3On = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer3Text.text = (Timer3).ToString("0");

        if (Timer3 <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                
                gameCanvas3.SetActive(true);
                dialogueBox.SetActive(false);
                timer3On = true;
                StartTimer3();
                Timer3 = 160f;
            }
            
           PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
           PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
            
        if(timer3On == true)
        {
            Timer3 -= Time.deltaTime;
                
        }
            
            
        }
    }

    private void StartTimer3()
    {
        if(gameCanvas3 == true)
        {
            timer3On = true;

            
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
        gameCanvas3.SetActive(false);
        PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
        PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
        timer3On = false;
    }
}
