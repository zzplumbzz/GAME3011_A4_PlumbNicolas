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
    public GameObject winCanvas;
    public GameObject gameOverCanvas;
    public float Timer3E;
    public TMP_Text timer3EText;
    bool timer3EOn;

    public int width;
    public int height;
    public GameObject tilePrefab;
    
    public List<GameObject> swap = new List<GameObject>();
    
 
    private BGTile[,] allTiles;
    
    public GameObject PO;
    public GameObject CO;

    
     public List<Button> temp;
    public GameObject CapsuleE;

    int boardSize = 11;
    float space = 600.0f;
    float row = 70.0f;
    public int PointsE;
    public TMP_Text pointsTXTE;

   
    public List<Image> images;

    // Start is called before the first frame update
    void Start()
    {
        winCanvas.SetActive(false);
        CapsuleE = GameObject.Find("CapsuleH");
        tilePrefab.GetComponent<Button>().interactable = true;
        PO = gameCanvas3E;
        dialogueBox.SetActive(false);
        gameCanvas3E.SetActive(false);
        gameOverCanvas.SetActive(false);
        Timer3E = 200f;
        timer3EOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        pointsTXTE.text = PointsE.ToString();
        if(timer3EOn == true)
        {
            Timer3E -= Time.deltaTime;
                
        }
        timer3EText.text = (Timer3E).ToString("0");

        if(PointsE == 100)
        {
            winCanvas.SetActive(true);
        }

        if (Timer3E <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                SetUp();
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

    private void SetUp()
    {
        for (int i = 0; i < boardSize; i++)
        {
            for(int j = 0; j < boardSize; j++)
            {
                
                
                CO = Instantiate(tilePrefab, new Vector3(space += 70f,row ,0f), Quaternion.identity) as GameObject;
                CO.transform.parent = PO.transform;
                tilePrefab.transform.parent = this.transform;

                
                
                
            }
            space = 600f;
            row += 70f;
        }
    }
    
    
    public void OnTilePressed(Button button)
    {
        
       
        CapsuleE = GameObject.Find("CapsuleE");
        
        CapsuleE.GetComponent<OpenGame3Hard>().temp.Add(button);
         CapsuleE.GetComponent<OpenGame3Hard>().images.Add(button.gameObject.transform.GetChild(0).GetComponent<Image>());
        
        if(CapsuleE.GetComponent<OpenGame3Hard>().temp.Count >= 2)
        {
            
            Vector3 tempV = CapsuleE.GetComponent<OpenGame3Hard>().temp[0].gameObject.transform.position;
            CapsuleE.GetComponent<OpenGame3Hard>().temp[0].gameObject.transform.position = CapsuleE.GetComponent<OpenGame3Hard>().temp[1].gameObject.transform.position;
            CapsuleE.GetComponent<OpenGame3Hard>().temp[1].gameObject.transform.position = tempV;
            PointsE += 20;
             CapsuleE.GetComponent<OpenGame3Hard>().temp.RemoveAt(1);
             CapsuleE.GetComponent<OpenGame3Hard>().temp.RemoveAt(0);
            
            // for (int i = 0; i < boardSize; i++)
            // {
            //     for(int j = 0; j < boardSize; j++)
            //     {
            //         if(allTiles[i,j] == temp[0])
            //         {
                        
            //         }
            //     }
            // }
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
