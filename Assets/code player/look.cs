using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look : MonoBehaviour
{
    public float mouseSensitivity; //camera turning speed
    public Transform playerBody; //player model
    public float xRotation = 0f; //start value for overall rotation

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //lock and hide cursor during control
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") /*build in key*/ * mouseSensitivity * Time.deltaTime; //mouse moves in vertical
        float mouseY = Input.GetAxis("Mouse Y") /*build in key*/ * mouseSensitivity * Time.deltaTime; //mouse moves in horizontal

        xRotation -= mouseY; //decrease xRotation base on mouseY, minus equal doesn't make the camera flip
        xRotation = Mathf.Clamp(xRotation,-90f,90f); //limit turning value, doesn't the camera flip over while turning

        transform.localRotation = Quaternion.Euler(xRotation, 0f,0f); //x-axis rotation value base on xRotation
        playerBody.Rotate(Vector3.up * mouseX); //applied turning value of the camera to player model
    
        if(Input.GetKey(KeyCode.LeftControl) == true)
        {
            transform.localPosition = new Vector3(0,-0.35f,0);
        }

        else
        {
            transform.localPosition = new Vector3(0,0,0);
        }

    }
}
