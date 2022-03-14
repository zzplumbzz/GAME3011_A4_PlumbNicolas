using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{

    public GameObject game2CanvasE;
    public GameObject game2Canvas;
    public GameObject game2CanvasH;
    public GameObject PlayerMovementScript;

   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            Debug.Log("LOOSE!");
            game2CanvasE.SetActive(false);
            game2Canvas.SetActive(false);
            game2CanvasH.SetActive(false);
            PlayerMovementScript.GetComponent<PlayerMovementScript>().moveSpeed = 5;
       PlayerMovementScript.GetComponent<PlayerMovementScript>().rotationSpeed = 2;
            
        }
    }
}
