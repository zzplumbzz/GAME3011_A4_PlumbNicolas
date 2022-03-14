using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game2EnemyScript : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
     Vector3 axis = new Vector3(0,0,1);
    protected Rigidbody rb;
    public GameObject centreE;
    public GameObject centre;
    public GameObject centreH;
    public GameObject enemy;
     public GameObject game2CanvasE;
    public GameObject game2Canvas;
     public GameObject game2CanvasH;
public GameObject PlayerMovementScript;
public WinGame2Script winS;

    void Update()
    {
        enemy.transform.RotateAround(centre.transform.position, axis, Time.deltaTime * 50);
    }

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
