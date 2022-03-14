using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerGame2 : MonoBehaviour
{
    public float speed = 1f;
    public float angularSpeed;
    
    Vector3 axis = new Vector3(0,0,1);
    Vector3 otheraxis = new Vector3(0,0,-1);
    Vector3 pForward = new Vector3(1, 1, 0);
    protected Rigidbody rb;
    public GameObject centreE;
    public GameObject centre;
    public GameObject centreH;
    public GameObject enemy;
    public GameObject player;


    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(pForward);
            }
            if(Input.GetKey(KeyCode.A))
            {
                
                player.transform.RotateAround(centre.transform.position, otheraxis, Time.deltaTime * 50);
            }
            if(Input.GetKey(KeyCode.D))
            {
                
                player.transform.RotateAround(centre.transform.position, axis, Time.deltaTime * 50);
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Toched Blocker!!!!");
    }
}
