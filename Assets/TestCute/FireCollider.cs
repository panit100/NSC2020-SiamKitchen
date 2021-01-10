using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Fired>() != null){
            other.GetComponent<Fired>().readyToCook = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<Fired>() != null){
            other.GetComponent<Fired>().readyToCook = false;
        }
    }
}
