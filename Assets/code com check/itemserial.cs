using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemserial : MonoBehaviour
{
    public string itemName;     //name of item
    public string itemType;     //type of item: topping , food , etc.
    public string itemLayer;    //which layer of plate that item can be place (1 = bottom layer , 1-2 = can be place on bottom or second layer)
}