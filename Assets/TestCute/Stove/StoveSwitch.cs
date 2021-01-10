using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveSwitch : MonoBehaviour
{
    [SerializeField]
    FireCollider Stove = null;

    void TurnONandOFF(){
        Stove.TurnONOFF = !Stove.TurnONOFF;
    }
}
