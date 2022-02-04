using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove == true)
        {
            if(Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
            if(Input.GetKey(KeyCode.A))
            {
                
                this.transform.Rotate(Vector3.up, -rotationSpeed);
            }
            if(Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(Vector3.back * Time.deltaTime* moveSpeed);
            }
            if(Input.GetKey(KeyCode.D))
            {
                
                this.transform.Rotate(Vector3.up, rotationSpeed);
            }
        }
        
    }
}