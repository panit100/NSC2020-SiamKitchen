using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitpage : MonoBehaviour
{
    public openfridge Openfrigde;
    public GameObject[] fridgewindow;   //array of button and pages
    public void OnTriggerEnter(Collider other)   //use trigger checking
    {
        if(other.tag == ("hand") && Openfrigde.fridgeisopen == true)     
        //close the fridge if hand is in trigger , pressing left mouse , the fridge is opened , player holding anything
        {
            fridgewindow[0].transform.GetChild(0).gameObject.SetActive(false);  //close quit page
            fridgewindow[1].transform.GetChild(0).gameObject.SetActive(false);  //close next page button
            fridgewindow[2].transform.GetChild(0).gameObject.SetActive(false);  //close previous page button
            fridgewindow[3].transform.GetChild(0).gameObject.SetActive(false);  //close page 1
            fridgewindow[3].transform.GetChild(1).gameObject.SetActive(false);  //close page 2
            fridgewindow[3].transform.GetChild(2).gameObject.SetActive(false);  //close page 3
            Openfrigde.fridgeisopen = false;    //boolean tell that the fridge is closed
        }
    }
}
