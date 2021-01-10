using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platefoodsnap : MonoBehaviour
{
    [SerializeField] public Transform snapPointBot;
    [SerializeField] public Transform snapPointTop;
    [SerializeField] public Transform snapItemBot;
    [SerializeField] public Transform snapItemTop;
    [SerializeField] public GameObject snapItemEnter;
    [SerializeField] itemserial itemGet;
    [SerializeField] string itemNameGet;
    [SerializeField] public bool itemBot;
    [SerializeField] public bool itemTop;
    [SerializeField] public bool itemBotUpdate;
    [SerializeField] public bool itemTopUpdate;

    public void Start()
    {
        itemBot = false;
        itemTop = false;
    }

    public void OnTriggerEnter(Collider other) 
    {
        if((other.tag == ("pickable") || other.tag == ("pickablesingle")) && other.GetComponent<itemserial>() != null)
        {
            itemGet = other.GetComponent<itemserial>();
            snapItemEnter = other.gameObject;
            itemNameGet = other.GetComponent<itemserial>().itemName;
        }

        if((itemNameGet == ("rice") || itemNameGet == ("stir egg")) && (itemBotUpdate == false || itemTopUpdate == false) && (other.tag == ("pickable") || other.tag == ("pickablesingle"))) //bottom snap
        {
            if(itemBotUpdate == false)
            {
                Debug.Log("bot catch");
                snapItemBot = other.transform;
                itemBot = true;
                snapItemBot.gameObject.layer = 0;
                freezingitem();
            }
            
            if(itemTopUpdate == false && itemBotUpdate == true && itemNameGet != ("rice"))
            {
                Debug.Log("top catch");
                snapItemTop = other.transform;
                itemTop = true;
                snapItemTop.gameObject.layer = 0;
                freezingitem();
            }
        }
    }

    public void freezingitem()
    {
        snapItemEnter.gameObject.GetComponent<Rigidbody>().useGravity = false;
        snapItemEnter.gameObject.GetComponent<Collider>().attachedRigidbody.constraints =
        RigidbodyConstraints.FreezeAll;
        snapItemEnter.transform.parent = null;
    }

    public void Update()
    {
        itemBotUpdate = itemBot;
        itemTopUpdate = itemTop;
    }
}
