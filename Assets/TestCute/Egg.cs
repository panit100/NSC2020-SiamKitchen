using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float magnetStrength = 5f;
    public float distanceStretch = 10f;
    public int magnetDirection = 1; // 1 = attact, -1 = repel
    public bool looseMagnet = true;

    private Transform trans;
    private Rigidbody rb;
    private Transform magnetTranfrom;
    private bool magnetInZone;

    private void Awake() {
            trans = transform;
            rb = trans.GetComponent<Rigidbody>();
    }

    

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Egg2"){
            magnetTranfrom = other.transform;
            magnetInZone = true;
        }
    }
    
    private void OnTriggerStay(Collider other) {
        if(other.tag == "Egg2"){
            if(magnetInZone){
                Vector3 directionToMagnet = magnetTranfrom.position - trans.position;
                float distance = Vector3.Distance(magnetTranfrom.position, trans.position);
                float magnetDistanceStr = (distanceStretch/distance) * magnetStrength;

                rb.AddForce(magnetDistanceStr * (directionToMagnet * magnetDirection), ForceMode.Force);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Egg2" && looseMagnet){
            magnetInZone = false;
        }
    }


}
