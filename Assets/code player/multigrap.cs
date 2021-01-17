using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class multigrap : MonoBehaviour
{
    [SerializeField] public Transform grapHolder;
    [SerializeField] bool isPick;
    [SerializeField] public bool updateisPick;

    public InputDeviceCharacteristics controllerCharacteristics;
    InputDevice targetDevice;
    public void Start()
    {
        isPick = false;

        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics,devices);

        if(devices.Count > 0){
            targetDevice = devices[0];
        }
    }

    public void OnTriggerStay(Collider other) 
    {
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool gripValue);
        if(gripValue && other.tag == ("pickable") && updateisPick == false)
        {
            other.GetComponent<Rigidbody>().useGravity = false;  //disable gravity, inside rigidbody component of picked up obj
            other.transform.parent = grapHolder;                 //make picked up obj as child of holding point
            other.attachedRigidbody.constraints =                //freezing rotation and position of all axises
            RigidbodyConstraints.FreezeAll ;
        }

        if(gripValue && other.tag == ("pickable") && updateisPick == true)
        {
            other.transform.parent = null;                                       //get picked up item of its parent(empty obj), 
            other.GetComponent<Rigidbody>().useGravity = true;                   //turn on item's gravity
            other.attachedRigidbody.constraints = RigidbodyConstraints.None;     //unfreeze holding item's rotation and position
        }
    }

    public void Update()
    {
        if(grapHolder.childCount == 0)
        {
            isPick = false;
        }
        if(grapHolder.childCount != 0)
        {
            isPick = true;
        }
        updateisPick = isPick;
    }
}