using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platesnapraycast : MonoBehaviour
{
    [SerializeField] public LayerMask item;
    [SerializeField] Ray plateRay;
    [SerializeField] RaycastHit rayHit;
    [SerializeField] public Transform itemHolderBot;
    [SerializeField] public Transform itemBot;
    [SerializeField] public bool itemBotCheck;
    [SerializeField] public Transform itemHolderMid;
    [SerializeField] public Transform itemMid;
    [SerializeField] public bool itemMidCheck;
    [SerializeField] public Transform itemHolderTop;
    [SerializeField] public Transform itemTop;
    [SerializeField] public bool itemTopCheck;
    

    public void Start() 
    {
        itemBotCheck = false;
        itemTopCheck = false;
        itemMidCheck = false;
    }

    public void FixedUpdate()
    {
        plateRay = new Ray (transform.position, transform.up);
        if(Physics.Raycast(plateRay, out rayHit, 100, item, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawLine(plateRay.origin,rayHit.point, Color.red);
            
            if(rayHit.collider.gameObject.GetComponent<itemserial>() != null)
            {
                if((rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("1") ||
                 rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("1-2") ||
                 rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("1-2-3")) 
                 && itemBotCheck == false && itemMidCheck == false && itemTopCheck == false)
                {
                    if(rayHit.transform.parent != null)
                    {
                        rayHit.transform.parent = null;
                    }
                    itemBot = rayHit.transform;
                    itemBot.parent = itemHolderBot;
                    itemBot.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    itemBot.gameObject.GetComponent<Collider>().attachedRigidbody.constraints =
                    RigidbodyConstraints.FreezeAll;
                    itemBot.gameObject.layer = 0;
                }

                if((rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("1-2") ||
                 rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("2") ||
                 rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("1-2-3"))
                 && itemBotCheck == true && itemMidCheck == false && itemTopCheck == false)
                {
                    if(rayHit.transform.parent != null)
                    {
                        rayHit.transform.parent = null;
                    }
                    itemMid = rayHit.transform;
                    itemMid.parent = itemHolderMid;
                    itemMid.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    itemMid.gameObject.GetComponent<Collider>().attachedRigidbody.constraints =
                    RigidbodyConstraints.FreezeAll;
                    itemMid.gameObject.layer = 0;
                }

                if((rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("1-2-3") ||
                 rayHit.collider.gameObject.GetComponent<itemserial>().itemLayer == ("3"))
                 && itemBotCheck == true && itemMidCheck == true && itemTopCheck == false)
                {
                    if(rayHit.transform.parent != null)
                    {
                        rayHit.transform.parent = null;
                    }
                    itemTop = rayHit.transform;
                    itemTop.parent = itemHolderTop;
                    itemTop.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    itemTop.gameObject.GetComponent<Collider>().attachedRigidbody.constraints =
                    RigidbodyConstraints.FreezeAll;
                    itemTop.gameObject.layer = 0;
                }
            }
        }

        else
        {
            Debug.DrawLine(plateRay.origin, plateRay.origin + plateRay.direction * 20, Color.green);
        }
        
        if(itemHolderBot.childCount != 0)
        {
            itemBot.position = itemHolderBot.position;
            itemBot.rotation = itemHolderBot.rotation;
            itemBotCheck = true;
        }

        if(itemHolderMid.childCount != 0)
        {
            itemMid.position = itemHolderMid.position;
            itemMid.rotation = itemHolderMid.rotation;
            itemMidCheck = true;
        }

        if(itemHolderTop.childCount != 0)
        {
            itemTop.position = itemHolderTop.position;
            itemTop.rotation = itemHolderTop.rotation;
            itemTopCheck = true;
        }
    }
}