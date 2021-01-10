using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pestle : MonoBehaviour
{
    [SerializeField]
    List<GameObject> pestleItem = new List<GameObject>();
    [SerializeField]
    GameObject m = null;
    int checkTime = 0;


    void checkPound(){
        if(checkTime >= 5){
            foreach(GameObject n in pestleItem){
                Destroy(n);
            }
            
            Instantiate(m,transform.position,transform.rotation);
            checkTime = 0;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<food>() != null){
            pestleItem.Add(other.gameObject);
        }

        if(other.tag == "Pestle" && pestleItem != null){
            checkTime++;
            checkPound();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<food>() != null){
            pestleItem.Remove(other.gameObject);
        }
    }
}
