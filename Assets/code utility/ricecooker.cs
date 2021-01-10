using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ricecooker : MonoBehaviour
{
    [SerializeField] public GameObject ricePrefab;      //rice prefeb
    [SerializeField] public Transform riceHolder;       //snap point of ladle that parent prefab rice
    [SerializeField] Transform riceItem;                //reference the clone rice to use in Update method
    public void OnTriggerEnter(Collider other)          //use trigger
    {
        if(other.name == ("ladle") && other.transform.GetChild(0).transform.childCount == 0)    //if ladle get in rice cooker and not holding any rice
        {
            GameObject riceClone = Instantiate(ricePrefab, riceHolder.transform.position,riceHolder.rotation) as GameObject;        //create cloned rice as object by (rice prefab , create at snap point's position , with snap point's angle)
            riceClone.transform.parent = riceHolder;                                    //make rice clone become a child of snap point
            riceClone.GetComponent<Rigidbody>().useGravity = false;                     //set off gravity
            riceClone.GetComponent<Collider>().attachedRigidbody.constraints =          //freeze position and rotation
            RigidbodyConstraints.FreezeAll;
            riceItem = riceClone.transform;                                             //reference the clone
        }
    }

    public void Update() 
    {
        if(riceHolder.transform.childCount != 0)            //if ladle is holding rice
        {
            riceItem.position = riceHolder.position;        //cloned rice always move with snap point
            riceItem.rotation = riceHolder.rotation;        //cloned rice always rotate with snap point
        }
    }
}