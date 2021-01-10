using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.GetComponent<food>() != null && other.gameObject.GetComponent<food>().isSlice){
            Instantiate(other.gameObject.GetComponent<food>().SliceObject,other.transform.position,other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
