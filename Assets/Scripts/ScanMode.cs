using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanMode : MonoBehaviour
{
    public GameObject Game1Station;
    public OpenGame1Script OGS;
    public GridButtonPressedScript GBS;
    public bool toggleButton;

    public GameObject[] buttonArray;
    
    
    //int[] buttonArray = new int[32];
    //List<Button> buttonList

    public void Start()
    {
        toggleButton = true;
    }

    void Update()
    {
        for(int b = 0; b < buttonArray.Length; b++)
        {
            
            for(int s = 0; s < GBS.score; s++)
            {
                if(GBS.score == 100)
                {
                    //GBS.button.GetComponent<Image>().color = Color.blue;
                }
            }
        }
    }
    public void ScanButtonPressed()
    {
        // toggleButton = false;

        // if(toggleButton == true)
        // {
        //     OGS.scanModeTXT.IsActive = false;
        //     OGS.extractModeTXT.enabled = true;
        // }
        // else if(toggleButton == false)
        // {
        //     OGS.scanModeTXT.enabled = true;
        //     OGS.extractModeTXT.enabled = false;
        // }
        
        // if(toggleButton == false)
        // {

        // }

    }

}
