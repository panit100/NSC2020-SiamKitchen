using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolreset : MonoBehaviour
{
    public Transform toolToReset;
    public Transform toolHolder;
    public void OnTriggerStay(Collider other) {
        if(other.tag == ("hand") && Input.GetKeyDown(KeyCode.Mouse0) && singlegrap.updateisPick == false)
        {
            toolToReset.transform.parent = toolHolder;
            toolToReset.GetComponent<Rigidbody>().useGravity = false;  //disable gravity, inside rigidbody component of picked up obj
            toolToReset.transform.position = toolHolder.position;  //transform position to holding position
            toolToReset.transform.rotation = Quaternion.Euler(0f,-90f,45f);
            toolToReset.GetComponent<Collider>().attachedRigidbody.constraints =                //freezing rotation and position of all axises
            RigidbodyConstraints.FreezeAll;
        }
    }
}