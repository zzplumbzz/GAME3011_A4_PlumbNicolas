using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHardScript : MonoBehaviour
{
    public GameObject game2CanvasH;
    public GameObject PlayerMovementScript;
    public bool winH;
    HardOpenGame HS;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            Debug.Log("WIN!!!");
            game2CanvasH.SetActive(false);
            winH = true;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
            //HS.TimerH = Time.timeScale = 0;
            //HS.TimerH = 15f;
            
        }
    }
}
