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

    [Header("Test")]
    [SerializeField] Transform liquidPlane;
    [SerializeField] Transform nextliquidHight;
    [SerializeField] float speed = 0.5f;
    float startTime;
    float journeyLength;
    Vector3 nextHight;

    public void Start()
    {
        dropletHeight = dropletOnPanChecker.position.y;     //
        nextHight = nextliquidHight.position;
    }

    public void OnTriggerEnter(Collider other)  //use trigger
    {
        if(other.tag == ("liquid")) //if hit object's tag is liquid
        {
            Destroy(GameObject.FindWithTag("liquid"));  //
            dropcount++;    //increase drop count by one for each bottle's click
            isDrop = true;  //the liquid is drop on the object
            dropletHeight = dropletHeight + 0.2f;   //the current height
            startTime = Time.time;
            nextHight = nextliquidHight.position;
        }
    }

    public void Update() 
    {
        if(isDrop == true)
        {
        //     dropletOnPan.position = Vector3.Lerp(dropletOnPan.position,dropletOnPan.position * dropletSpeed * Time.deltaTime,1);
        //     dropletSpeed = 2f;
        //     dropletOnPan.Translate (Vector3.up * dropletSpeed * Time.deltaTime);
            Lerpliquid();
            print("isDrop Update");
        //  isDrop = false;
        }

        // if(dropletOnPanChecker.position.y >= dropletHeight)
        // {
        //     isDrop = false;
        //     dropletSpeed = 0f;
        // }

        if(dropletOnPan.position.y >= nextHight.y)
        {
            isDrop = false;
            print("dropletOnPan Update");
        }
    }

    void Lerpliquid(){
        
        float disCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = disCovered / journeyLength;
        dropletOnPan.position = Vector3.Lerp(liquidPlane.position,nextHight,fractionOfJourney);
        print("Lerpliquid");
    }
}