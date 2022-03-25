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
    public GameObject winCanvas;
    public GameObject gameOverCanvas;
    public float Timer3;
    public TMP_Text timer3Text;
    bool timer3On;
    public int width;
    public int height;
    public GameObject tilePrefab;
    public int Points;
    public TMP_Text pointsTXT;
    
    public List<GameObject> swap = new List<GameObject>();
    
 
    private BGTile[,] allTiles;
    
    public GameObject PO;
    public GameObject CO;

    
     public List<Button> temp;
    public GameObject Capsule;

    int boardSize = 11;
    float space = 600.0f;
    float row = 70.0f;

   
    public List<Image> images;

    // Start is called before the first frame update
    void Start()
    {
        winCanvas.SetActive(false);
        Capsule = GameObject.Find("Capsule");
        tilePrefab.GetComponent<Button>().interactable = true;
        PO = gameCanvas3;
        dialogueBox.SetActive(false);
        gameCanvas3.SetActive(false);
        gameOverCanvas.SetActive(false);
        Timer3 = 160f;
        timer3On = false;
    }

    // Update is called once per frame
    void Update()
    {
        pointsTXT.text = Points.ToString();
        if(timer3On == true)
        {
            Timer3 -= Time.deltaTime;
                
        }

        if(Points == 150)
        {
            winCanvas.SetActive(true);
        }
        
        timer3Text.text = (Timer3).ToString("0");

        if (Timer3 <= 0)//loads game over scene when countdown reaches 0
        {
            gameOverCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && dialogueActive)
        {
            if (dialogueBox.activeInHierarchy)
            {
                SetUp();
                gameCanvas3.SetActive(true);
                dialogueBox.SetActive(false);
                timer3On = true;
                StartTimer3();
                Timer3 = 160f;
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
        
       
        Capsule = GameObject.Find("Capsule");
        
        Capsule.GetComponent<OpenGame3Hard>().temp.Add(button);
         Capsule.GetComponent<OpenGame3Hard>().images.Add(button.gameObject.transform.GetChild(0).GetComponent<Image>());
        
        if(Capsule.GetComponent<OpenGame3Hard>().temp.Count >= 2)
        {
            
            Vector3 tempV = Capsule.GetComponent<OpenGame3Hard>().temp[0].gameObject.transform.position;
            Capsule.GetComponent<OpenGame3Hard>().temp[0].gameObject.transform.position = Capsule.GetComponent<OpenGame3Hard>().temp[1].gameObject.transform.position;
            Capsule.GetComponent<OpenGame3Hard>().temp[1].gameObject.transform.position = tempV;
            Points += 15;
             Capsule.GetComponent<OpenGame3Hard>().temp.RemoveAt(1);
             Capsule.GetComponent<OpenGame3Hard>().temp.RemoveAt(0);
            
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
