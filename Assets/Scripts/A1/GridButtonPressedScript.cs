using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridButtonPressedScript : MonoBehaviour
{
     float resoursePoints;
    public GameObject Game1Station;
    public Button button;
    public OpenGame1Script OGS;
    
     public int score;
    public int choice;
   
  

    void Start()
    {
        Game1Station = GameObject.Find("Game1Station");

       choice =  Random.Range(1, 7);
        
        if(choice == 1)
        {
            score = 25;
            button.GetComponent<Image>().color = Color.red;
        }

        if(choice == 2)
        {
            score = 50;
            button.GetComponent<Image>().color = Color.magenta;
        }

        if(choice == 3)
        {
            score = 100;
            button.GetComponent<Image>().color = Color.blue;
        }

        if(choice == 4)
        {
            score = 5;
            button.GetComponent<Image>().color = Color.grey;
        }

        if(choice == 5)
        {
            score = 1;
            button.GetComponent<Image>().color = Color.grey;
        }

        if(choice == 6)
        {
            score = 0;
           button.GetComponent<Image>().color = Color.grey;
        }
        if(choice == 7)
        {
            score = 0;
           button.GetComponent<Image>().color = Color.grey;
        }

        
    }

    

    public void OnGridButtonPressed()
    {
        
        
        Debug.Log("PRESSSSED");
        Game1Station.GetComponent<OpenGame1Script>().resoursePoints += score;
        button.GetComponent<Button>().interactable = false;
        Game1Station.GetComponent<OpenGame1Script>().clickCount -= 1;

        // if(OGS.clickCount <= 0)
        // {
        //     OGS.Button.SetActive(false);
        // }
        
    }
}
