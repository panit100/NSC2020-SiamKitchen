using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecam : MonoBehaviour
{
    public Transform camPointer;
    void Update()
    {
        camPointer.transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.World);
    }
}
