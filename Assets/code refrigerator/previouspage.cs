using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class previouspage : MonoBehaviour
{
    public GameObject[] page;           //same function as "nextpage" script, but turn the page back
    public static int pagenumber = 1;   //doesn't have start method
    public void Awake() 
    {
        pagenumber = 1;
    }
    public void OnTriggerStay(Collider other) {
        if(other.tag == ("hand") && Input.GetKeyDown(KeyCode.Mouse0) && singlegrap.whatHoldNow == null)
        {
            Debug.Log ("previous page");        //console dialog
            pagenumber = pagenumber - 1;        //turn back page, decrease pagenumber
            nextpage.pagenumber = pagenumber;   //sync current page with another script
            if(pagenumber == 0)                 //when turn back from page 1, start again at the last page (page 3)
            {
                pagenumber = 3;                 //when pagenumber is 0, set page to page 3
                nextpage.pagenumber = 3;        //sync current page with another script
            }
            turnpage();     //change page method
        }
    }

    public void turnpage()
    {
        switch (pagenumber)
        {
            case 1: //now open page 1 and close the rest
            {
                page[0].transform.GetChild(0).gameObject.SetActive(true);   //page 1
                page[1].transform.GetChild(0).gameObject.SetActive(false);  //page 2
                page[2].transform.GetChild(0).gameObject.SetActive(false);  //page 3
                break;
            }

            case 2: //now open page 2 and close the rest
            {
                page[0].transform.GetChild(0).gameObject.SetActive(false);
                page[1].transform.GetChild(0).gameObject.SetActive(true);
                page[2].transform.GetChild(0).gameObject.SetActive(false);
                break;
            }

            case 3: //now open page 2 and close the rest
            {
                page[0].transform.GetChild(0).gameObject.SetActive(false);
                page[1].transform.GetChild(0).gameObject.SetActive(false);
                page[2].transform.GetChild(0).gameObject.SetActive(true);
                break;
            }
        }
    }
}