using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextpage : MonoBehaviour
{
    public GameObject[] page;           //array that contained pages, and children with a page
    public static int pagenumber;   //page count number, start with page 1, also share value to previouspage script
    public void Awake() 
    {
        pagenumber = 1;
    }

    public void OnTriggerStay(Collider other) {     //next page button method
        if(other.tag == ("hand") && Input.GetKeyDown(KeyCode.Mouse0) && singlegrap.whatHoldNow == null)     //active within area then press E
        {
            pagenumber = (pagenumber%3)+1;          //turn next page equation, if at the last page, back to page 1
            previouspage.pagenumber = pagenumber;   //sync current pagenumber with prevoiuspage script
            Debug.Log ("next page");                //console dialog
            turnpage();                             //active turnpage method
        }
    }

    public void turnpage()              //this method will SetActive true and false to each page object
    {                                   //use current page(pagenumber) as condition in switch case
        switch (pagenumber)
        {
            case 1:                     //current page is page 1
            {
                page[0].transform.GetChild(0).gameObject.SetActive(true);   //page 1 object is now active
                page[1].transform.GetChild(0).gameObject.SetActive(false);  //page 2 is inactive
                page[2].transform.GetChild(0).gameObject.SetActive(false);  //page 3 is inactive
                break;
            }

            case 2:
            {
                page[0].transform.GetChild(0).gameObject.SetActive(false);  //not current page is 2 so page 1 is inactive
                page[1].transform.GetChild(0).gameObject.SetActive(true);   //page 2 is active
                page[2].transform.GetChild(0).gameObject.SetActive(false);  //same as page 1
                break;
            }

            case 3:
            {
                page[0].transform.GetChild(0).gameObject.SetActive(false);
                page[1].transform.GetChild(0).gameObject.SetActive(false);
                page[2].transform.GetChild(0).gameObject.SetActive(true);
                break;
            }
        }
        
    }
}