using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkhold : MonoBehaviour
{
    public static string whatHold; 
    public void OnTriggerStay(Collider other)
    {
        if(other.name == ("spatula") && singlegrap.updateisPick == true)
            whatHold = other.name;

        if(other.name == ("bottle") && singlegrap.updateisPick == true)
            whatHold = other.name;

        if(other.name == ("ladle") && singlegrap.updateisPick == true)
            whatHold = other.name;

        if(singlegrap.updateisPick == false)
            whatHold = null;
        
    }
}
