using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pouring : MonoBehaviour
{
    [SerializeField] public LayerMask mask;             //layer mask for raycast
    [SerializeField] public Transform bottleCap;        //empty game object at bottle's cap
    [SerializeField] public Transform bottleMid;        //empty game object at middle of the bottle
    [SerializeField] public Transform dropletLocation;  //spawn point of prefab (bottle cap)
    [SerializeField] public GameObject dropletPrefab;   //prefeb of liquid
    [SerializeField] public GameObject dropletClone;    //clone of liquid
    void Update()
    {
        Ray bottleRay = new Ray (transform.position, Vector3.down);     //declair raycast (original position of ray , raycast point down)
        RaycastHit hitInfo;     //
        if(Physics.Raycast(bottleRay, out hitInfo, 250, mask, QueryTriggerInteraction.Ignore))  //if(the ray name , the raycast hit object , ray range , what mask the ray will interact , not hit trigger)
        {
            if((bottleCap.transform.position.y * 1.01f < bottleMid.transform.position.y) && Input.GetKeyDown(KeyCode.Mouse1) && singlegrap.whatHoldNow == ("bottle"))   
            //if the bottle's cap is lower than middle of bottle , press right mouse , player is holding bottle item
            {
                Debug.DrawLine(bottleRay.origin, hitInfo.point, Color.green);   //display the green line of ray cast if the conditions are met
                dropletClone = Instantiate(dropletPrefab, dropletLocation.transform.position, Quaternion.Euler(0,0,0)) as GameObject;   //spawn invisible prefab of droplet at bottle's cap
            }
        }
    }
}