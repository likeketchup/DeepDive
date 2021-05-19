using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    //Could be changed by gears in the future
    public float speedMultiplier = 100f;
    // applied when moving backwards
    // private float waterFiction = 0.5f;

    // Update is called once per frame
    void Update()
    {
         // a = 1, d = -1
        float xMovement = Input.GetAxis("Horizontal") ;
        // w = 1, s = -1
        float zMovement = Input.GetAxis("Vertical");
        //Vector3 move = transform.right * xMovement  + transform.up*zMovement;
        Vector3 targetDirection = new Vector3(xMovement, 0f, zMovement);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        //targetDirection.y = 0.0f;
        if(transform.position.y <= -45f) {
            controller.Move(targetDirection * speedMultiplier*Time.deltaTime);
         } else {
            Vector3 newPosition = new Vector3(transform.position.x, -45f, transform.position.z);
            controller.transform.position = newPosition;
         }

        

        
        // old version: no momentum
        /* if(Input.GetKey(KeyCode.W)){
            transform.position = transform.position + Camera.main.transform.forward * speedMultiplier * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.S)){
            transform.position = transform.position - Camera.main.transform.forward * speedMultiplier * Time.deltaTime * waterFiction;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position = transform.position - Camera.main.transform.right * speedMultiplier * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.D)){
            transform.position = transform.position + Camera.main.transform.right * speedMultiplier * Time.deltaTime;
        } */
    }
}
