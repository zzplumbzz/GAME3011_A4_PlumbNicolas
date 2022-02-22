using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame2Script : MonoBehaviour
{
    public GameObject game2Canvas;
    public GameObject PlayerMovementScript;
    OpenGame2Script OS;
    public bool win;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            Debug.Log("WIN!!!");
            game2Canvas.SetActive(false);
            win = true;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
            PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
            //OS.Timer = Time.timeScale = 0;
            //OS.Timer = 20f;
            
        }
    }
}
