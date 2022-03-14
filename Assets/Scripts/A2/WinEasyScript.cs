using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEasyScript : MonoBehaviour
{
    public GameObject game2Canvas;
    public GameObject PlayerMovementScript;
    EasyOpenGame2Script ES;
    public bool winE;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            Debug.Log("WIN!!!");
            game2Canvas.SetActive(false);
            winE = true;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
            //ES.Timer = Time.timeScale = 0;
            //ES.Timer = 25f;
            
        }
    }
}
