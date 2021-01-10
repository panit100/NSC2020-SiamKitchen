using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singlegrap : MonoBehaviour
{
    [SerializeField] Ray pickRay;
    [SerializeField] RaycastHit hitInfo;
    [SerializeField] float rayRange;
    [SerializeField] public LayerMask mask;
    [SerializeField] public Transform grapHolder;
    [SerializeField] public Transform grapPosition;
    [SerializeField] bool isPick;
    public static bool updateisPick;
    public static string whatHoldNow;
    
    public void Start()
    {
        isPick = false;     //set picking boolean to false: at start, player not holding anything
    }

    public void Update()
    {
        pickRay = new Ray (transform.position, transform.forward);                                  //setting up raycast (position of ray , direction of ray)
        if(Physics.Raycast(pickRay,out hitInfo, rayRange, mask, QueryTriggerInteraction.Ignore))    //(rayname , hit what , distance , what it can interact(layer) , aim to hit collider(ignore trigger))
        {
            if(Input.GetKeyDown(KeyCode.Mouse0) && updateisPick == false)                           //right mouse is pressed and not already picking item
            {
                hitInfo.collider.gameObject.transform.parent = grapHolder;                          //item that was hit by ray become a child of grapholder(hand)
                grapHolder.GetChild(0).GetComponent<Rigidbody>().useGravity = false;                //disable gravity, inside rigidbody component of picked up item
                grapHolder.GetChild(0).transform.position = grapPosition.position;                  //transform position to holding position
                grapHolder.GetChild(0).GetComponent<Collider>().attachedRigidbody.constraints =     //freezing rotation and position of all axises
                RigidbodyConstraints.FreezeAll;
            }
            Debug.DrawLine(pickRay.origin, hitInfo.point,Color.red);
        }

        else
        {
            Debug.DrawLine(pickRay.origin, pickRay.origin + pickRay.direction * rayRange, Color.green);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0) && updateisPick == true)
        {
            grapHolder.GetChild(0).GetComponent<Rigidbody>().useGravity = true;                   //turn on item's gravity
            grapHolder.GetChild(0).GetComponent<Collider>().attachedRigidbody.constraints = RigidbodyConstraints.None;     //unfreeze holding item's rotation and position
            grapHolder.GetChild(0).transform.parent = null;
        }
        
        if(grapHolder.childCount == 0)
        {
            isPick = false;
        }

        if(grapHolder.childCount != 0)
        {
            isPick = true;
        }
        
        updateisPick = isPick;
        whatHoldNow = checkhold.whatHold;
    }
}
