using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class openfridge : MonoBehaviour
{
    public GameObject[] fridgewindow;           //array of window button and pages
    public bool fridgeisopen = false;    //boolean checking if the fridge is close or not
    InputDeviceCharacteristics controllerCharacteristics;
    InputDevice targetDevice;
    public void Start() //nothing is active until the fridge is open
    {
        fridgewindow[0].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[1].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[2].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[3].transform.GetChild(0).gameObject.SetActive(false);
        fridgewindow[3].transform.GetChild(1).gameObject.SetActive(false);
        fridgewindow[3].transform.GetChild(2).gameObject.SetActive(false);
        fridgeisopen = false;

        // List<InputDevice> devices = new List<InputDevice>();
        // InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics,devices);

        // if(devices.Count > 0){
        //     targetDevice = devices[0];
        // }
    }
    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == ("hand") && fridgeisopen == false)    
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