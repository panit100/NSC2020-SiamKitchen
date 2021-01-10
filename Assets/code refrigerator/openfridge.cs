using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openfridge : MonoBehaviour
{
    public GameObject[] fridgewindow;           //array of window button and pages
    public static bool fridgeisopen = false;    //boolean checking if the fridge is close or not
    public void Start() //nothing is active until the fridge is open
    {
        fridgewindow[0].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[1].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[2].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[3].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[3].transform.GetChild(1).gameObject.SetActive(false);
        fridgewindow[3].transform.GetChild(2).gameObject.SetActive(false);
        fridgeisopen = false;
    }
    public void OnTriggerStay(Collider other) 
    {
        if(other.tag == ("hand") && Input.GetKeyDown(KeyCode.Mouse0) && fridgeisopen == false && singlegrap.whatHoldNow == null)    
        //can be open when hand is in trigger , press left mouse , firdge is not opened , player not holding anything
        {
            fridgeisopen = true;
            fridgewindow[0].transform.GetChild(0).gameObject.SetActive(true);    //when start the game, page is start with page 1
            fridgewindow[1].transform.GetChild(0).gameObject.SetActive(false);
            fridgewindow[2].transform.GetChild(0).gameObject.SetActive(false);
            fridgewindow[3].transform.GetChild(0).gameObject.SetActive(true);
            fridgewindow[3].transform.GetChild(1).gameObject.SetActive(true);
            fridgewindow[3].transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}