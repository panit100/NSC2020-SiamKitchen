using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pancheck : MonoBehaviour
{
    [SerializeField] public int dropcount;                  //count the droplet
    [SerializeField] public Transform dropletOnPan;         //the object act as particle of liquid (move up when droplet hit trigger)
    [SerializeField] public Transform dropletOnPanChecker;  //the position of trigger
    [SerializeField] private bool isDrop;                   //is the liquid droped on the object?
    [SerializeField] private float dropletHeight;           //height of liquid
    [SerializeField] private float dropletSpeed;            //speed of lipuid increasing height
    public void Start()
    {
        dropletHeight = dropletOnPanChecker.position.y;     //
    }

    public void OnTriggerEnter(Collider other)  //use trigger
    {
        if(other.tag == ("liquid")) //if hit object's tag is liquid
        {
            Destroy(GameObject.FindWithTag("liquid"));  //
            dropcount++;    //increase drop count by one for each bottle's click
            isDrop = true;  //the liquid is drop on the object
            dropletHeight = dropletHeight + 0.2f;   //the current height
        }
    }

    public void Update() 
    {
        if(isDrop == true)
        {
            dropletSpeed = 2f;
            dropletOnPan.Translate (Vector3.up * dropletSpeed * Time.deltaTime);
        }

        if(dropletOnPanChecker.position.y > dropletHeight)
        {
            isDrop = false;
            dropletSpeed = 0f;
        }
    }
}