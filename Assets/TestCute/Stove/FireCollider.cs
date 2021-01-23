using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    public bool TurnONOFF = false;


    private void OnTriggerStay(Collider other) {
        if(other.GetComponent<Fired>() != null){
            other.GetComponent<Fired>().readyToCook = TurnONOFF;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<Fired>() != null){
            other.GetComponent<Fired>().readyToCook = false;
        }
    }
}
