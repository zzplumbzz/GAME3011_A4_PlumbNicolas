using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenGame1Script : MonoBehaviour
{
    public GameObject PlayerMovementScript;
    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public TMP_Text dialogue;
    public bool dialogueActive;
    public GameObject gameCanvas;
    public GameObject Button; 
    public GameObject gameOverCanvas;
    int boardSize = 32;
    float space = 450.0f;
    float row = 30.0f;
    public GameObject PO;
    public GameObject CO;
    public TMP_Text resourseTXT;
    public TMP_Text scoreTXT;
    public int resoursePoints = 0;
    List<Color> colors;
    public GameObject Game1Station;
    public int clickCount;
    public TMP_Text clickCountTXT;
    public GridButtonPressedScript GBS;
    public TMP_Text finalScoreTXT;
    public GameObject finalScoreBox;
    public TMP_Text extractModeTXT;
    public TMP_Text scanModeTXT;
    public ScanMode SMS;
    
    void Start()
    {

        PO = gameCanvas;
        dialogueBox.SetActive(false);
        gameCanvas.SetActive(false);
        clickCount = 3;
        finalScoreBox.SetActive(false);
        gameOverCanvas.SetActive(false);
        
    }
    void Update()
    {
       
        scoreTXT.text = resoursePoints.ToString();
        clickCountTXT.text = clickCount.ToString();
        finalScoreTXT.text = "Final Score:" + resoursePoints.ToString();

        if(clickCount <= 0)
        {
            
            finalScoreBox.SetActive(true);
            gameOverCanvas.SetActive(true);
            gameCanvas.SetActive(false);
           // Button.GetComponent<Button>().interactable = false;
            //CO.GetComponent<Button>().interactable = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                BuildBoard();
                clickCount = 3;
                gameCanvas.SetActive(true);
                dialogueBox.SetActive(false);
                Button.GetComponent<Button>().enabled = true;
                scanModeTXT.enabled = true;
                extractModeTXT.enabled = false;
                

                
            }
            
           PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 0;
           PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 0;
            
            
            
        }

        

        
      

    }

   public void QuitButtonPressed()
   {
       gameCanvas.SetActive(false);
       PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
       PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
       
   }

   public void QuitButtonPressed2()
   {
       gameOverCanvas.SetActive(false);
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

    void BuildBoard()
    {
        for(int r = 0; r < boardSize; r++)
        {
            
            
            for(int c = 0; c < boardSize; c++)
            {
                CO = Instantiate(Button, new Vector3(space += 30f,row ,0f), Quaternion.identity);
                CO.transform.parent = PO.transform;
                
                

               
                
            }
            space = 450f;
            row += 30f;

        }

      
        
    }

  


}
