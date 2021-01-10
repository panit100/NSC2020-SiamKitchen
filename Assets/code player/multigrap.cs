using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multigrap : MonoBehaviour
{
    [SerializeField] public Transform grapHolder;
    [SerializeField] bool isPick;
    [SerializeField] public bool updateisPick;
    public void Start()
    {
        isPick = false;
    }

    public void OnTriggerStay(Collider other) 
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && other.tag == ("pickable") && updateisPick == false)
        {
            other.GetComponent<Rigidbody>().useGravity = false;  //disable gravity, inside rigidbody component of picked up obj
            other.transform.parent = grapHolder;                 //make picked up obj as child of holding point
            other.attachedRigidbody.constraints =                //freezing rotation and position of all axises
            RigidbodyConstraints.FreezeAll ;
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && other.tag == ("pickable") && updateisPick == true)
        {
            other.GetComponent<Rigidbody>().useGravity = true;                   //turn on item's gravity
            other.attachedRigidbody.constraints = RigidbodyConstraints.None;     //unfreeze holding item's rotation and position
            other.transform.parent = null;                                       //get picked up item of its parent(empty obj), 
        }
    }

    public void Update()
    {
        if(grapHolder.childCount == 0)
        {
            isPick = false;
        }
        if(grapHolder.childCount != 0)
        {
            isPick = true;
        }
        updateisPick = isPick;
    }
}