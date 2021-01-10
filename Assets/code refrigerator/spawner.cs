using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform[] ItemSpawnLocation;   //add empty gameobj as spawn location
    public GameObject[] ItemSpawnPrefab;    //add prefab item
    public GameObject[] ItemSpawnClone;     //same as prefab

    public void OnTriggerStay(Collider other) {     //work with press left mouse within area and player not holding anything
        if(other.tag == ("hand") && Input.GetKeyDown(KeyCode.Mouse0) && singlegrap.whatHoldNow == null)
        {
            ItemSpawnClone[0] = Instantiate(ItemSpawnPrefab[0],ItemSpawnLocation[0].transform.position,Quaternion.Euler(0,0,0)) as GameObject;
            //clone prefab, at specific position and with specific a rotation, as a gameobject
        }
    }
}
