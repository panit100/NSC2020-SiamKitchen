using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class TestJoy : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    InputDevice targetDevice;

    private void Start() {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics,devices);

        if(devices.Count > 0){
            targetDevice = devices[0];
        }
    }


    void Update()
    {
        
        if(targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue){
            Debug.Log("press");
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f){
            Debug.Log("trigger pressed" + triggerValue);
        }

        if(targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f){
            Debug.Log("trigger pressed" + gripValue);
        }
        
    }
}
