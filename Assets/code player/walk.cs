using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public CharacterController controller;  /*public - declare insert gameobject
CharacterController - specific component in this code
controller - variable name for CharacterController in this code */
                                            
    public float speed; //move speed
    public float runspeed;
    public float basespeed;
    public float gravity = -9.81f;
    Vector3 velocity;
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift) == true)
        {
            speed = runspeed;
        }

        if(Input.GetKey(KeyCode.LeftShift ) == false)
        {
            speed = basespeed;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
