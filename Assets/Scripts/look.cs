using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    // passing player object
    public Transform player;
    //give the control of mouse sensitivity
    public float mouseSensitivity = 1000f;
    // rotation of  camera around x-axis --- up and down
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime *mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime *mouseSensitivity;
        // -= means the rotation follows the mouse movement. You can flip it by changing to +=
        xRotation -= mouseY;
        //restrict the angle
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        // 
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
