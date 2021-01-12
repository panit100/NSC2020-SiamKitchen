using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pouring : MonoBehaviour
{
    [SerializeField] LayerMask mask;             //layer mask for raycast
    [SerializeField] Transform bottleCap;        //empty game object at bottle's cap
    [SerializeField] Transform bottleMid;        //empty game object at middle of the bottle
    [SerializeField] Transform dropletLocation;  //spawn point of prefab (bottle cap)
    [SerializeField] GameObject dropletPrefab;   //prefeb of liquid

    Ray bottleRay;
    RaycastHit hitInfo;     //
    
    void Update()
    {
        bottleRay = new Ray (transform.position, Vector3.down);     //declair raycast (original position of ray , raycast point down)
       

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
             if(Physics.Raycast(bottleRay, out hitInfo, 250, mask, QueryTriggerInteraction.Ignore))  //if(the ray name , the raycast hit object , ray range , what mask the ray will interact , not hit trigger)
            {
                if(bottleCap.transform.position.y * 1.01f < bottleMid.transform.position.y )//&& singlegrap.whatHoldNow == ("bottle"))   //if the bottle's cap is lower than middle of bottle , press right mouse , player is holding bottle item
                {
                Debug.DrawLine(bottleRay.origin, hitInfo.point, Color.green);   //display the green line of ray cast if the conditions are met
                Instantiate(dropletPrefab, dropletLocation.transform.position, Quaternion.Euler(0,0,0));   //spawn invisible prefab of droplet at bottle's cap
                }
            }
        }
    }
}