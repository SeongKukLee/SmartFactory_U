using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSensor : MonoBehaviour
{
    public bool isObjectDetected = false;
    public bool isMetalObject = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("MetalObject"))
        {
            isObjectDetected = true;
        }
    }
}
